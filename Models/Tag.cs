using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public int UserId { get; set; }
        public DateOnly CreatedAt { get; set; } 
        public int T_id { get; set; }
        

    }
}
