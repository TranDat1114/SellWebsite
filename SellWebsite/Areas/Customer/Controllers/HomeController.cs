using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels;
using SellWebsite.Models.ViewModels.Customer;

namespace SellWebsite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var homeVM = new HomeVM()
            {
                Products = _unitOfWork.Product.GetAll(includes: p => p.Categories!).ToList(),
                Categories = _unitOfWork.Category.GetAll().ToList(),
            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}