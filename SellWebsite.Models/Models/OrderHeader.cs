using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SellWebsite.Models.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderTime { get; set; }
        public DateTime ShipingDate { get; set; }

        public double OrderTotal { get; set; }
        public double Discount { get; set; }

        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntendId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; } //State Là tiểu bang nha qua Việt Nam thì là tỉnh thành tại paypal nó biểu cần có
        [Required]
        public string Zipcode { get; set; }
    }
}
