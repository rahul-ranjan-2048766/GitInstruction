using Batch_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Application.Helpers
{
    public interface IManager
    {
        // Virtual function that fetches the list of details of transactions from the mysql database
        public Tuple<List<Transaction>, bool> GetTransactions();

        // Virtual function that converts the list of transactions to string
        public string ConvertListOfTransactionsToString(List<Transaction> transactions);

        // Virtual function that saves the string to rabbitMQ after encrypting the string
        public bool SaveStringToRabbitMQ(string text);

        // Virtual function that prints the success message to the console screen
        public void PrintMessage();

        // Virtual function that prints the rabbitMQ unoperational message 
        public void PrintRabbitMQUnoperational();

        // Virtual function that prints the microservice unoperational message
        public void PrintTransactionApplicationalUnoperational();
    }
}
