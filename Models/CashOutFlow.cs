using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class CashOutFlow
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateOnly DateofTransaction { get; set; }
        public string Category { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
    }
}
