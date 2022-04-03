using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bill_Generator.Models;

namespace Bill_Generator.Helpers
{
    public interface IManager
    {
        // Virtual function to get string from RabbitMQ
        public Tuple<string, bool> GetStringFromRabbitMQ();

        // Virtual function to convert string to the list of bill
        public Tuple<List<Bill>, bool> ConvertStringToListOfBills(string text);

        // Virtual function to save the list of bill into BillDB
        public bool SaveBillsToDatabase(List<Bill> bills);

        // Virtual function to print that RabbitMQ is unoperational
        public void PrintRabbitMQUnoperational();

        // Virtual function to print that MySql database is unoperational
        public void PrintMySqlDatabaseUnoperational();

        // Virtual function to print that the data is saved successfully into BillDB
        public void PrintMessage();

        // Virtual function to print that the string received from RabbitMQ is null
        public void PrintStringReceivedFromRabbitMQIsNull();

        // Virtual function to print that string to list conversion an ended in an error
        public void PrintStringToListOfBillError();
    }
}
