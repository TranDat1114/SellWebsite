using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using NuGet.ContentModel;

using SellWebsite.DataAccess.Data;
using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels.Admin;
using SellWebsite.Utility;

namespace SellWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Boss},{SD.Role_Employee}")]
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View();
        }

        #region API Call

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _db.ApplicationUsers.ToList();

            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in users)
            {
                var roleId = userRole.FirstOrDefault(p => p.UserId == user.Id).RoleId;
                user.Role = _db.Roles.FirstOrDefault(p => p.Id == roleId).Name;
            }

            return Json(new { data = users }, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
        }

       
        //Chưa thực hiện
        public IActionResult LockUnlockUser(int? id)
        {

            return Json(new { success = true, message = "Lock successful" });
        }

        #endregion
    }
}
