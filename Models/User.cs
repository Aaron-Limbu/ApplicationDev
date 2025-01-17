using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty ;
        public string Email { get; set; } = string.Empty;
        public string PreferredCurrency { get; set; } = string.Empty;
        public DateOnly createdAt { get; set; } 
        public decimal balance { get; set; }
    }
}
