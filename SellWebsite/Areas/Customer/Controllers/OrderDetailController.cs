using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;

namespace SellWebsite.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class OrderDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var orderList = _unitOfWork.OrderHeader.GetAll(p => p.ApplicationUserId == userId, p => p.OrderDetails!);



            return View(orderList);
        }
    }
}
