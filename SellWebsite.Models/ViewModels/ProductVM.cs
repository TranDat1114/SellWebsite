using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

using SellWebsite.Models.Models;

namespace SellWebsite.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<CategoryListVM> CategoryList { get; set; }
        [ValidateNever]
        public List<int> CategoryIdList { get; set; }
    }

    public class CategoryListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
