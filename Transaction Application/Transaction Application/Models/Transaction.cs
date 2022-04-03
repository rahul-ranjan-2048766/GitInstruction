using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transaction_Application.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.CreditCard)]
        public decimal CreditCardNumber { get; set; }

        public double TransactionAmount { get; set; }
        public string CreditCardType { get; set; }        
        public DateTime TransactionDate { get; set; }
        public string TransactionId { get; set; }
    }
}
