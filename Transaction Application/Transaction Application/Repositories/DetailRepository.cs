using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using Transaction_Application.Helpers;
using Transaction_Application.Models;

namespace Transaction_Application.Repositories
{
    public class DetailRepository : IDetailRepository
    {
        private readonly string sqlDataSource;
        private readonly IManager manager;
        public DetailRepository(IConfiguration configuration, IManager manager)
        {
            sqlDataSource = configuration.GetConnectionString("DefaultConnection");
            this.manager = manager;
        }




        // Function to add a row to a table Transaction
        public void AddDetail(Transaction transaction)
        {
            // Converting datetime format to mysql type datetime format
            var date = manager.ChangeDateFormatToSqlFormat(transaction.TransactionDate);

            // MySql query to add data into table Transaction
            string query = @"insert into Transaction(CreditCardNumber, CreditCardType, Amount, TransactionDate, TransactionId) values('" + transaction.CreditCardNumber + "', '" + transaction.CreditCardType + "', '" + transaction.TransactionAmount + "', '" + date + "', '" + transaction.TransactionId + "')";
            
            // Connecting with mysql database
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                // Opening the database connection
                connection.Open();

                // Creating the mysql command for executing the mysql query
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Executing the mysql query
                    command.ExecuteNonQuery();

                    // Closing the database connection
                    connection.Close();
                }
            }
        }




        // Function to delete all rows from table Transaction
        public void DeleteAll()
        {
            // MySql query to delete all rows from table Transaction
            string query = @"delete from Transaction";

            // Connecting with mysql database
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                // Opening the database connection
                connection.Open();

                // Creating the mysql command for executing the mysql query
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Executing the mysql command
                    command.ExecuteNonQuery();

                    // Closing the database connection
                    connection.Close();
                }
            }
        }


        
        
        // Function to delete row having a specific id from table Transaction
        public void DeleteDetailById(int id)
        {
            // MySql query to delete a row from table Transaction having a specific id 
            string query = @"delete from Transaction where Id='" + id + "'";

            //Connecting with mysql database
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                // Opening the database connection
                connection.Open();

                // Creating the mysql command for executing the mysql query
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Executing the mysql command
                    command.ExecuteNonQuery();

                    // Closing the database connection
                    connection.Close();
                }
            }
        }




        // Function to fetch a row having a specific id from table Transaction
        public Transaction GetDetailById(int id)
        {
            // MySql query to get a row from table Transaction
            string query = @"select * from Transaction where id='" + id + "'";

            // Variables
            MySqlDataReader reader;
            Transaction transaction = new Transaction();

            // Connecting with mysql database
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                // Opening the database connection
                connection.Open();

                // Creating the mysql command for executing the mysql query
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    reader.Read();
                    transaction.Id = int.Parse(reader["Id"].ToString());
                    transaction.CreditCardNumber = decimal.Parse(reader["CreditCardNumber"].ToString());
                    transaction.CreditCardType = reader["CreditCardType"].ToString();
                    transaction.TransactionAmount = float.Parse(reader["Amount"].ToString());
                    transaction.TransactionDate = DateTime.Parse(reader["TransactionDate"].ToString());
                    transaction.TransactionId = reader["TransactionId"].ToString();
                }
            }

            // Returning the transaction detail having the desired id
            return transaction;
        }




        // Function to fetch all rows from table Transaction
        public List<Transaction> GetDetails()
        {
            // MySql query to fetch all rows from table Transaction
            string query = @"select * from Transaction";

            // Variables
            MySqlDataReader myReader;
            List<Transaction> transactions = new List<Transaction>();

            // Connecting with mysql database
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                // Opening the database connection
                connection.Open();

                // Creating the mysql command for executing the mysql query
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Fetching data
                    myReader = command.ExecuteReader();

                    // Reading data
                    while(myReader.Read())
                    {
                        // Adding data to list
                        transactions.Add(new Transaction
                        {
                            Id = int.Parse(myReader["Id"].ToString()),
                            CreditCardNumber = decimal.Parse(myReader["CreditCardNumber"].ToString()),
                            CreditCardType = myReader["CreditCardType"].ToString(),
                            TransactionAmount = double.Parse(myReader["Amount"].ToString()),
                            TransactionDate = DateTime.Parse(myReader["TransactionDate"].ToString()),
                            TransactionId = myReader["TransactionId"].ToString()
                        });
                    }
                    myReader.Close();

                    // Closing the database connection
                    connection.Close();
                }
            }
            
            // Returning the list of transaction details
            return transactions;
        }




        // Function to update a row from table Transaction having a specific id
        public void UpdateDetail(Transaction transaction)
        {
            // Converting datetime format to mysql type datetime format
            var date = manager.ChangeDateFormatToSqlFormat(transaction.TransactionDate);

            // MySql query to update a row having a specific id of table Transaction
            string query = @"update Transaction set CreditCardNumber='" + transaction.CreditCardNumber + "', CreditCardType='" + transaction.CreditCardType + "', Amount='" + transaction.TransactionAmount + "', TransactionDate='" + date + "', TransactionId='" + transaction.TransactionId + "' where Id='" + transaction.Id + "'";
            
            // Connecting with mysql database
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                // Opening the database connection
                connection.Open();

                // Creating the mysql command for executing the mysql query 
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Executing the mysql command
                    command.ExecuteNonQuery();

                    // Closing the mysql connection
                    connection.Close();
                }
            }
        }
    }
}
