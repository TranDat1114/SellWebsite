using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWebsite.Models.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? State { get; set; } 
        public string? Address { get; set; }
        public string? Region { get; set; }
        public string? Zipcode { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
