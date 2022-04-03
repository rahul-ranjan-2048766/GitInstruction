using Bill_Generator.Models;
using MySqlConnector;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Generator.Helpers
{
    public class Manager : IManager
    {
        // Function to convert string separated by comas to list of Bill
        public Tuple<List<Bill>, bool> ConvertStringToListOfBills(string text)
        {
            List<Bill> bills = new List<Bill>();
            try
            {                
                var lines = text.Split('\n');
                foreach (var line in lines)
                {
                    var list = line.Split(',').ToList();
                    bills.Add(new Bill
                    {
                        Id = 0,
                        CreditCardNumber = decimal.Parse(list.ElementAt(1).ToString()),
                        CreditCardType = list.ElementAt(2).ToString(),
                        TransactionAmount = double.Parse(list.ElementAt(3).ToString()),
                        TransactionDate = DateTime.Parse(list.ElementAt(4).ToString()),
                        TransactionId = list.ElementAt(5).ToString()
                    });
                }
                return new Tuple<List<Bill>, bool>(bills, true);
            }
            catch
            {
                return new Tuple<List<Bill>, bool>(bills, false);
            }
        }


        // Function to get string from RabbitMQ
        public Tuple<string, bool> GetStringFromRabbitMQ()
        {
            try
            {
                var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                BasicGetResult result = channel.BasicGet("queue", false);
                string text = null;
                if (result != null)
                {
                    text = Encoding.ASCII.GetString(result.Body.ToArray());
                    channel.BasicAck(result.DeliveryTag, false);
                }
                return new Tuple<string, bool>(text, true);
            }
            catch
            {
                return new Tuple<string, bool>(null, false);
            }
        }


        // Function to print that data is saved successfully into BillDB
        public void PrintMessage()
        {
            Console.WriteLine("The data has been saved into BillDB successfully.");
        }


        // Function to print that MySql database is not operational
        public void PrintMySqlDatabaseUnoperational()
        {
            Console.WriteLine("The MySql database is not operational.");
        }


        // Function to print that the RabbitMQ image of docker is not operational
        public void PrintRabbitMQUnoperational()
        {
            Console.WriteLine("The docker image of RabbitMQ is not operational.");
        }


        // Function to save the list of bill in BillDB successfully
        public bool SaveBillsToDatabase(List<Bill> bills)
        {
            try
            {
                string sqlDataSource = @"server=localhost; port=3306; userid=root; password=root; Initial Catalog=BillDB;";
                string query = null;
                using (MySqlConnection mySqlConnection = new MySqlConnection(sqlDataSource))
                {
                    mySqlConnection.Open();
                    foreach (var bill in bills)
                    {
                        var date = bill.TransactionDate.Year + "-" + bill.TransactionDate.Month + "-" + bill.TransactionDate.Day + " " + bill.TransactionDate.Hour + ":" + bill.TransactionDate.Minute + ":" + bill.TransactionDate.Second;
                        query = @"insert into Bill (CreditCardNumber, CreditCardType, Amount, TransactionDate, TransactionId) values('" + bill.CreditCardNumber + "', '" + bill.CreditCardType + "', '" + bill.TransactionAmount + "', '" + date + "', '" + bill.TransactionId + "')";
                        using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                        {
                            mySqlCommand.ExecuteNonQuery();
                        }
                    }
                    mySqlConnection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        // Function to print that the string received from RabbitMQ is null and the database is not updated
        public void PrintStringReceivedFromRabbitMQIsNull()
        {
            Console.WriteLine("The string received from RabbitMQ is null. The database is not updated.");
        }

        public void PrintStringToListOfBillError()
        {
            Console.WriteLine("The conversion of string to the list of bills has ended in an error. I guess the list is empty.");
        }
    }
}
