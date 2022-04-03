using Batch_Application.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Batch_Application.Helpers
{
    public class Manager : IManager
    {
        // Function to convert the list of transactions to string
        public string ConvertListOfTransactionsToString(List<Transaction> transactions)
        {
            string text = "";
            foreach (var transaction in transactions)
            {
                text += transaction.Id + "," + transaction.CreditCardNumber + "," + transaction.CreditCardType + "," + transaction.TransactionAmount +
                    "," + transaction.TransactionDate + "," + transaction.TransactionId + "\n";
            }

            text = text.Substring(0, text.Length - 1);
            return text;
        }


        // Function to fetch the list of transaction details from the MySql database using the Transaction Application (microservice)
        public Tuple<List<Transaction>, bool> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44368/api/Transaction/");
                    var responseTask = client.GetAsync("GetDetails");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var reader = result.Content.ReadAsAsync<List<Transaction>>();
                        reader.Wait();
                        transactions = reader.Result;
                    }
                }
                return new Tuple<List<Transaction>, bool>(transactions, true);
            }
            catch
            {
                return new Tuple<List<Transaction>, bool>(transactions, false);
            }
        }


        // Function to print the success message to the console screen
        public void PrintMessage()
        {
            Console.WriteLine("The details are successfully saved to rabbitmq.");
        }


        // Function to save the string to rabbitmq image of docker
        public bool SaveStringToRabbitMQ(string text)
        {
            try
            {
                var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
                var connection = factory.CreateConnection();
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("queue", true, false, false, null);
                    channel.BasicPublish("", "queue", null, Encoding.ASCII.GetBytes(text));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void PrintRabbitMQUnoperational()
        {
            Console.WriteLine("The rabbitMQ image is not operational.");
        }

        public void PrintTransactionApplicationalUnoperational()
        {
            Console.WriteLine("The microservice transaction application is not operational.");
        }
    }
}
