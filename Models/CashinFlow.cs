using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class CashinFlow{
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public string SourceofIncome { get; set; } 
        public string Note { get; set; }
        public string Tag { get; set; }
        public int UserId { get; set; }
    }
}
