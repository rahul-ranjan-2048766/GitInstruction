using RabbitMQ.Client;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;
using Bill_Generator.Models;
using Bill_Generator.Helpers;

namespace Bill_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            IManager manager = new Manager();

            var data = manager.GetStringFromRabbitMQ();
            if(data.Item2 == true)
            {
                if(data.Item1.Length != 0)
                {
                    var bills = manager.ConvertStringToListOfBills(data.Item1);
                    if(bills.Item2 == true && bills.Item1.Count() != 0)
                    {
                        var result = manager.SaveBillsToDatabase(bills.Item1);
                        if (result == true)
                        {
                            manager.PrintMessage();
                        }
                        else
                        {
                            manager.PrintMySqlDatabaseUnoperational();
                        }
                    }
                    else
                    {
                        manager.PrintStringToListOfBillError();
                    }
                }
                else
                {
                    manager.PrintStringReceivedFromRabbitMQIsNull();
                }
            }
            else
            {
                manager.PrintMySqlDatabaseUnoperational();
            }
        }
    }
}
