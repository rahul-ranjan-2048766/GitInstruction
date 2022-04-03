using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_UI__Report__Application.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public decimal CreditCardNumber { get; set; }
        public double TransactionAmount { get; set; }
        public string CreditCardType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionId { get; set; }
    }
}
