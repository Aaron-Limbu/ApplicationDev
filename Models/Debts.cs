using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Debts
    {
        public int DebtId { get; set; }
        public string Source { get; set; } = string.Empty;
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateOnly DueDate { get; set; }
        public bool IsCleared { get; set; }
        public int ClearedByTransactionId { get; set; }
    }

}


