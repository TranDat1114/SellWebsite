using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;

namespace SellWebsite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class DetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(int? id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == id, p => p.Categories!);

            return View(product);
        }
    }
}
