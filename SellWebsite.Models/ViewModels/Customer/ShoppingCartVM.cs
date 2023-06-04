using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.Models.Models;

namespace SellWebsite.Models.ViewModels.Customer
{
    public class ShoppingCartVM
    {
        public List<ShoppingCart> Carts { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
