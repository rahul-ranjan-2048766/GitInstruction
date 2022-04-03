using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web_UI__Report__Application.Models;

namespace Web_UI__Report__Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Bill> bills = new List<Bill>();
            string query = @"select * from Bill";
            using (MySqlConnection mySqlConnection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                mySqlConnection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                {
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    while(mySqlDataReader.Read())
                    {
                        bills.Add(new Bill 
                        { 
                            Id = int.Parse(mySqlDataReader["Id"].ToString()),
                            CreditCardNumber = decimal.Parse(mySqlDataReader["CreditCardNumber"].ToString()),
                            CreditCardType = mySqlDataReader["CreditCardType"].ToString(),
                            TransactionAmount = double.Parse(mySqlDataReader["Amount"].ToString()),
                            TransactionDate = DateTime.Parse(mySqlDataReader["TransactionDate"].ToString()),
                            TransactionId = mySqlDataReader["TransactionId"].ToString()
                        });
                    }
                }
            }
                
            return View(bills);
        }

        public IActionResult DeleteAll()
        {
            var query = @"delete from Bill";
            using (MySqlConnection mySqlConnection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                mySqlConnection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                {
                    mySqlCommand.ExecuteNonQuery();
                    mySqlConnection.Close();
                }
            }
                
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
