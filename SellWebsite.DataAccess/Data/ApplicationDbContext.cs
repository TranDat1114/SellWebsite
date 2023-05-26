using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SellWebsite.Models.Models;

namespace SellWebsite.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = new List<Category>()
            {
                    new Category()
                    {
                        Id = 1,
                        NameEnglish = "Thử nghiệm 2",
                        NameVietnamese = "",
                        DescriptionEnglish = "Nước uống có gas cực ngon",
                        DescriptionVietnamese = "",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 2,
                        NameEnglish = "Thử nghiệm 1",
                        NameVietnamese = "",
                        DescriptionEnglish = "Nước uống có gas cực ngon",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 3,
                        NameEnglish = "Informational",
                        NameVietnamese = "Thông tin",
                        DescriptionEnglish = "These are websites that provide information on a specific topic, such as news websites, educational websites, or government websites.",
                        DescriptionVietnamese = "Đây là trang web cung cấp thông tin về một chủ đề cụ thể, chẳng hạn như trang web tin tức, trang web giáo dục hoặc trang web chính phủ.",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 4,
                        NameEnglish = "E-commerce",
                        NameVietnamese = "Thương mại điện tử",
                        DescriptionEnglish = "These are websites that allow users to purchase items online, such as online shopping websites or auction websites.",
                        DescriptionVietnamese = "Đây là trang web cho phép người dùng mua hàng trực tuyến, chẳng hạn như trang web bán hàng trực tuyến hay trang web đấu giá.",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 5,
                        NameEnglish = "Entertainment",
                        NameVietnamese = "Giải trí",
                        DescriptionEnglish = "These are websites that provide entertainment content, such as movie streaming websites, gaming websites, or music streaming websites.",
                        DescriptionVietnamese = "Đây là trang web cung cấp các nội dung giải trí, chẳng hạn như trang web xem phim, trang web chơi game hoặc trang web nghe nhạc.",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 6,
                        NameEnglish = "Social-media",
                        NameVietnamese = "Mạng xã hội",
                        DescriptionEnglish = "These are websites that allow users to interact and connect with each other, such as Facebook, Twitter, or Instagram.",
                        DescriptionVietnamese = "Đây là trang web cho phép người dùng tương tác và kết nối với nhau, chẳng hạn như Facebook, Twitter, Instagram.",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 7,
                        NameEnglish = "Blog",
                        NameVietnamese = "Blog",
                        DescriptionEnglish = "These are personal or business websites that provide the latest posts and information on a specific topic.",
                        DescriptionVietnamese = "Đây là trang web cá nhân hoặc doanh nghiệp cung cấp các bài viết và thông tin mới nhất về chủ đề cụ thể.",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 8,
                        NameEnglish = "Forum",
                        NameVietnamese = "Diễn đàn",
                        DescriptionEnglish = "These are websites that allow users to discuss a specific topic and share their opinions with others.",
                        DescriptionVietnamese = "Đây là trang web cho phép người dùng thảo luận về một chủ đề cụ thể và chia sẻ ý kiến của mình với những người khác.",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 9,
                        NameEnglish = "Tool",
                        NameVietnamese = "Công cụ",
                        DescriptionEnglish = "These are websites that provide online tools or services for users, such as Google, Dropbox, or GitHub.",
                        DescriptionVietnamese = "Đây là trang web cung cấp các công cụ hoặc dịch vụ trực tuyến cho người dùng, chẳng hạn như Google, Dropbox hay GitHub.",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 10,
                        NameEnglish = "Online-learning",
                        NameVietnamese = "Học tập trực tuyến",
                        DescriptionEnglish = "These are websites that provide online courses or study materials, such as Coursera, edX, or Udemy.",
                        DescriptionVietnamese = "Đây là trang web cung cấp các khóa học hoặc tài liệu học tập trực tuyến, chẳng hạn như Coursera, edX hay Udemy.",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 11,
                        NameEnglish = "Food",
                        NameVietnamese = "Ẩm thực",
                        DescriptionEnglish = "I'm too lazy to write it down, I can't edit it anymore",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 12,
                        NameEnglish = "Exhibition",
                        NameVietnamese = "Trưng bày",
                        DescriptionEnglish = "Phòng trưng bày",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 14,
                        NameEnglish = "Travel",
                        NameVietnamese = "Du lịch",
                        DescriptionEnglish = "I'm too lazy to write it down, I can't edit it anymore",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 15,
                        NameEnglish = "Sports",
                        NameVietnamese = "Thể thao",
                        DescriptionEnglish = "I'm too lazy to write it down, I can't edit it anymore",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                        Image = "no Img",
                    },
                    new Category()
                    {
                        Id = 16,
                        NameEnglish = "Business"
                        ,
                        NameVietnamese = "Kinh doanh",
                        DescriptionEnglish = "A huge list of the best business website templates is built to serve any company, from construction to business consulting and financial services. All templates are mobile-friendly and feature both one-page and multi-page setups. Whether you are bringing a fresh project or redesigning your current website, these templates have you covered. They are powerful enough to meet any firm and organization owner’s needs and requirements.",
                        DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                        Image = @"/assets/dev.png",

                    }
            };

            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Title = "Glint",
                    Author = "TranPhuDat",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    PostsBy = "ADminTPD",
                    Credits = "Images from Unsplash;Boostrap",
                    Description = "Glint is a modern and stylish digital agency HTML template. Designed for creative designers, agencies, freelancers, photographers, or any creative profession.",
                    DownloadCount = 0,
                    DownloadUrl = "linkdownloadFIle",
                    PreviewUrl = "LinkPreviewUrl",
                    License = "",
                    Price = 500000,
                }
            };

            //

            modelBuilder.Entity<Category>()
             .Property(e => e.Image)
             .HasDefaultValueSql("'/assets/avatar.jpg'");

            modelBuilder.Entity<Category>().HasData(
                categories
            );

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
                .Property(e => e.UpdatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
              .Property(e => e.Price)
              .HasDefaultValueSql("0");

            modelBuilder.Entity<Product>()
               .Property(e => e.Credits)
               .HasDefaultValueSql("'JADY'");

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .HasDefaultValueSql("'/assets/dev.png'");

            modelBuilder.Entity<Product>()
                .Property(e => e.UpdatedDate)
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<Product>().HasData(
                products
            );

            base.OnModelCreating(modelBuilder);

        }
    }
}
