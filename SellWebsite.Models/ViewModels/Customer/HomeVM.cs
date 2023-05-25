using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.Models.Models;

namespace SellWebsite.Models.ViewModels.Customer
{
    public class HomeVM
    {
        public List<Product>? Products { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
