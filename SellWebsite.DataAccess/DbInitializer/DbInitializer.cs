using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using SellWebsite.DataAccess.Data;
using SellWebsite.Models.Models;
using SellWebsite.Utility;

namespace SellWebsite.DataAccess.DbInitializer
{
    //Đây là một cách thức để tạo những database cần thiết ở đây thì ta tạo ra các role
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public DbInitializer(ApplicationDbContext applicationDbContext, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _db = applicationDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //Tạo dữ liệu trong database nếu dữ liệu chưa được tạo 
        public async void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }

            //Dòng if dưới đây kiểm tra xem trong database đã có role phù hợp hay chưa. Nếu chưa sẽ tự động tạo các role trong database khi mở trang register
            //Ở đây chọn 1 role mồi là customer nếu không có role customer thì tạo hết :v xử lý vậy cho lẹ ứng dụng nào mà chẳng có khách hàng
            if (!_roleManager.RoleExistsAsync(SD.Role_Employee).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Boss)).GetAwaiter().GetResult();

                //Tạo thêm một tài khoản Admin ban đầu để tránh việc không có ai để tạo người dùng
                _userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = "dattranphu1114@gmail.com",
                    Email = "dattranphu1114@gmail.com",
                    Name = "Trần Phú Đạt",
                    PhoneNumber = "0985950723",
                    StreetAddress = "Tăng Bạc Hổ",
                    City = "Quy Nhơn",
                    State = "Bình Định",
                    Country = "Việt Nam",
                    Zipcode = "70500",
                    LockoutEnabled = false,
                }, @"Iloveuzienoi1114@").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(p => p.Email == "dattranphu1114@gmail.com");

                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }
            return;
        }
    }
}
