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

                // Những dữ liệu khác
                var categories = new List<Category>()
            {
                    new Category()
                    {
                        NameEnglish = "Informational",
                        NameVietnamese = "Thông tin",
                        DescriptionEnglish = "These are websites that provide information on a specific topic, such as news websites, educational websites, or government websites.",
                        DescriptionVietnamese = "Đây là trang web cung cấp thông tin về một chủ đề cụ thể, chẳng hạn như trang web tin tức, trang web giáo dục hoặc trang web chính phủ.",

                    },
                    new Category()
                    {
                        NameEnglish = "E-commerce",
                        NameVietnamese = "Thương mại điện tử",
                        DescriptionEnglish = "These are websites that allow users to purchase items online, such as online shopping websites or auction websites.",
                        DescriptionVietnamese = "Đây là trang web cho phép người dùng mua hàng trực tuyến, chẳng hạn như trang web bán hàng trực tuyến hay trang web đấu giá.",

                    },
                    new Category()
                    {
                        NameEnglish = "Entertainment",
                        NameVietnamese = "Giải trí",
                        DescriptionEnglish = "These are websites that provide entertainment content, such as movie streaming websites, gaming websites, or music streaming websites.",
                        DescriptionVietnamese = "Đây là trang web cung cấp các nội dung giải trí, chẳng hạn như trang web xem phim, trang web chơi game hoặc trang web nghe nhạc.",

                    },
                    new Category()
                    {
                        NameEnglish = "Social-media",
                        NameVietnamese = "Mạng xã hội",
                        DescriptionEnglish = "These are websites that allow users to interact and connect with each other, such as Facebook, Twitter, or Instagram.",
                        DescriptionVietnamese = "Đây là trang web cho phép người dùng tương tác và kết nối với nhau, chẳng hạn như Facebook, Twitter, Instagram.",

                    },
                    new Category()
                    {
                        NameEnglish = "Blog",
                        NameVietnamese = "Blog",
                        DescriptionEnglish = "These are personal or business websites that provide the latest posts and information on a specific topic.",
                        DescriptionVietnamese = "Đây là trang web cá nhân hoặc doanh nghiệp cung cấp các bài viết và thông tin mới nhất về chủ đề cụ thể.",

                    },
                    new Category()
                    {
                        NameEnglish = "Forum",
                        NameVietnamese = "Diễn đàn",
                        DescriptionEnglish = "These are websites that allow users to discuss a specific topic and share their opinions with others.",
                        DescriptionVietnamese = "Đây là trang web cho phép người dùng thảo luận về một chủ đề cụ thể và chia sẻ ý kiến của mình với những người khác.",

                    },
                    new Category()
                    {
                        NameEnglish = "Tool",
                        NameVietnamese = "Công cụ",
                        DescriptionEnglish = "These are websites that provide online tools or services for users, such as Google, Dropbox, or GitHub.",
                        DescriptionVietnamese = "Đây là trang web cung cấp các công cụ hoặc dịch vụ trực tuyến cho người dùng, chẳng hạn như Google, Dropbox hay GitHub.",

                    },
                    new Category()
                    {
                        NameEnglish = "Online-learning",
                        NameVietnamese = "Học tập trực tuyến",
                        DescriptionEnglish = "These are websites that provide online courses or study materials, such as Coursera, edX, or Udemy.",
                        DescriptionVietnamese = "Đây là trang web cung cấp các khóa học hoặc tài liệu học tập trực tuyến, chẳng hạn như Coursera, edX hay Udemy.",

                    },
                    new Category()
                    {
                        NameEnglish = "Food",
                        NameVietnamese = "Ẩm thực",
                        DescriptionEnglish = "I'm too lazy to write it down, I can't edit it anymore",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",

                    },
                    new Category()
                    {
                        NameEnglish = "Exhibition",
                        NameVietnamese = "Trưng bày",
                        DescriptionEnglish = "Phòng trưng bày",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",

                    },
                    new Category()
                    {
                        NameEnglish = "Travel",
                        NameVietnamese = "Du lịch",
                        DescriptionEnglish = "I'm too lazy to write it down, I can't edit it anymore",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                    },
                    new Category()
                    {
                        NameEnglish = "Sports",
                        NameVietnamese = "Thể thao",
                        DescriptionEnglish = "I'm too lazy to write it down, I can't edit it anymore",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",

                    },
                    new Category()
                    {
                        NameEnglish = "Business",
                        NameVietnamese = "Kinh doanh",
                        DescriptionEnglish = "A huge list of the best business website templates is built to serve any company, from construction to business consulting and financial services. All templates are mobile-friendly and feature both one-page and multi-page setups. Whether you are bringing a fresh project or redesigning your current website, these templates have you covered. They are powerful enough to meet any firm and organization owner’s needs and requirements.",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",


                    }
            };
                _db.Categories.AddRangeAsync(categories).GetAwaiter().GetResult();
                _db.SaveChangesAsync().GetAwaiter().GetResult();
                var products = new List<Product>()
            {
                new Product()
                {
                    Title = "DarkAndLight",
                    Author = "TranPhuDat",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    PostsBy = "ADminTPD",
                    Credits = "Images from Unsplash;Boostrap",
                    Description = "Glint is a modern and stylish digital agency HTML template. Designed for creative designers, agencies, freelancers, photographers, or any creative profession.",
                    DownloadCount = 0,
                    DownloadUrl = "https://github.com/TranDat1114/MoonLightSunLight",
                    PreviewUrl = "https://trandat1114.github.io/MoonLightSunLight/",
                    License = "",
                    Price = 50,
                    Rating= 4,
                    Image = "/assets/Images/products/DarkAndLight.png",
                    Categories= _db.Categories.Where(p=>p.NameEnglish == "Tool"|| p.NameEnglish =="Blog"||p.NameEnglish == "Exhibition"||p.NameEnglish=="Entertainment" ).ToList(),

                },
                new Product()
                {
                    Title = "Dotnet Universe",
                    Author = "TranPhuDat",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    PostsBy = "ADminTPD",
                    Credits = "Images from Unsplash;Boostrap",
                    Description = "Glint is a modern and stylish digital agency HTML template. Designed for creative designers, agencies, freelancers, photographers, or any creative profession.",
                    DownloadCount = 3,
                    DownloadUrl = "https://github.com/TranDat1114/DotnetuniverseProject",
                    PreviewUrl = "https://trandat1114.github.io/DotnetuniverseProject/#!/",
                    License = "",
                    Price = 99,
                    Rating= 5,
                    Image = "/assets/Images/products/DotnetUniverse.png",
                    Categories= _db.Categories.Where(p=>p.NameEnglish == "Informational"|| p.NameEnglish =="Social-media"||p.NameEnglish == "Forum"||p.NameEnglish=="Online-learning"||p.NameEnglish=="Blog" ).ToList(),

                },
                 new Product()
                {
                    Title = "Food Shop",
                    Author = "TranPhuDat",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    PostsBy = "ADminTPD",
                    Credits = "Images from Unsplash;Boostrap",
                    Description = "Glint is a modern and stylish digital agency HTML template. Designed for creative designers, agencies, freelancers, photographers, or any creative profession.",
                    DownloadCount = 3,
                    DownloadUrl = "none",
                    PreviewUrl = "none",
                    License = "",
                    Price = 49,
                    Rating= 3,
                    Image = "/assets/Images/products/FoodShop.png",
                    Categories= _db.Categories.Where(p=>p.NameEnglish == "Food"|| p.NameEnglish =="Business"||p.NameEnglish == "Exhibition" ).ToList(),

                },
                  new Product()
                {
                    Title = "Start Boostrap",
                    Author = "TranPhuDat",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    PostsBy = "ADminTPD",
                    Credits = "Images from Unsplash;Boostrap",
                    Description = "Glint is a modern and stylish digital agency HTML template. Designed for creative designers, agencies, freelancers, photographers, or any creative profession.",
                    DownloadCount = 3,
                    DownloadUrl = "https://github.com/TranDat1114/demoPreview",
                    PreviewUrl = "https://trandat1114.github.io/demoPreview/",
                    License = "",
                    Price = 49,
                    Rating= 2,
                    Image = "/assets/Images/products/StartBoostrap.png",
                    Categories= _db.Categories.Where(p=>p.NameEnglish == "Tool"|| p.NameEnglish =="E-commerce"||p.NameEnglish == "Business"||p.NameEnglish=="Exhibition" ).ToList(),

                },
                   new Product()
                {
                    Title = "Cyborg",
                    Author = "TranPhuDat",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    PostsBy = "ADminTPD",
                    Credits = "Images from Unsplash;Boostrap",
                    Description = "Glint is a modern and stylish digital agency HTML template. Designed for creative designers, agencies, freelancers, photographers, or any creative profession.",
                    DownloadCount = 3,
                    DownloadUrl = "https://github.com/TranDat1114/demoWEB",
                    PreviewUrl = "https://trandat1114.github.io/demoWEB/",
                    License = "",
                    Price = 69,
                    Rating= 5,
                    Image = "/assets/Images/products/Cyborg.png",
                    Categories = _db.Categories.Where(p=>p.NameEnglish == "Entertainment"|| p.NameEnglish =="Social-media"||p.NameEnglish == "Forum" ).ToList(),
                }
            };
                _db.Products.AddRangeAsync(products).GetAwaiter().GetResult();
                _db.SaveChangesAsync().GetAwaiter().GetResult();

            }
            return;
        }
    }
}
