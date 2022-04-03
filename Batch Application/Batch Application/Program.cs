using Batch_Application.Helpers;

namespace Batch_Application
{
    class Program
    {
        // Main Program
        static void Main(string[] args)
        {
            // Creating an instance of Manager class
            IManager manager = new Manager();

            // Getting the list of transaction details from the database
            var tuple = manager.GetTransactions();

            // Verifying if the data is fetched successfully
            if(tuple.Item2 == true)
            {
                // Converting the list of transaction to string separated by comas and semicolons
                var text = manager.ConvertListOfTransactionsToString(tuple.Item1);

                // Saving the string to rabbitMQ image of docker
                var result = manager.SaveStringToRabbitMQ(text);

                if(result == true)
                {
                    // Printing the success message to the console screen
                    manager.PrintMessage();
                }
                else
                {
                    // RabbitMQ unoperational
                    manager.PrintRabbitMQUnoperational();
                }                
            }
            else
            {
                // Transaction Application Microservice Unoperational
                manager.PrintTransactionApplicationalUnoperational();
            }                       
        }
    }
}
