using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Utility;

namespace SellWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Boss}")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            return View();
        }

        #region API Call
        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrderHeader> orderHeaders = _unitOfWork.OrderHeader.GetAll(includes: p => p.ApplicationUser).ToList();
            return Json(new { data = orderHeaders });
        }

        #endregion
    }
}
