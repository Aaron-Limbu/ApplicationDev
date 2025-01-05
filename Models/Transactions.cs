using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Transactions
    {
        public int TransactionId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public DateOnly Date { get; set; }
        public int UserId { get; set; }
    }
}
