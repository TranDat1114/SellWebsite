using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class demo_17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 16);

            migrationBuilder.AddColumn<double>(
                name: "ProductRating",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that provide information on a specific topic, such as news websites, educational websites, or government websites.", "Đây là trang web cung cấp thông tin về một chủ đề cụ thể, chẳng hạn như trang web tin tức, trang web giáo dục hoặc trang web chính phủ.", "Informational", "Thông tin" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that allow users to purchase items online, such as online shopping websites or auction websites.", "Đây là trang web cho phép người dùng mua hàng trực tuyến, chẳng hạn như trang web bán hàng trực tuyến hay trang web đấu giá.", "E-commerce", "Thương mại điện tử" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that provide entertainment content, such as movie streaming websites, gaming websites, or music streaming websites.", "Đây là trang web cung cấp các nội dung giải trí, chẳng hạn như trang web xem phim, trang web chơi game hoặc trang web nghe nhạc.", "Entertainment", "Giải trí" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that allow users to interact and connect with each other, such as Facebook, Twitter, or Instagram.", "Đây là trang web cho phép người dùng tương tác và kết nối với nhau, chẳng hạn như Facebook, Twitter, Instagram.", "Social-media", "Mạng xã hội" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are personal or business websites that provide the latest posts and information on a specific topic.", "Đây là trang web cá nhân hoặc doanh nghiệp cung cấp các bài viết và thông tin mới nhất về chủ đề cụ thể.", "Blog", "Blog" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that allow users to discuss a specific topic and share their opinions with others.", "Đây là trang web cho phép người dùng thảo luận về một chủ đề cụ thể và chia sẻ ý kiến của mình với những người khác.", "Forum", "Diễn đàn" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that provide online tools or services for users, such as Google, Dropbox, or GitHub.", "Đây là trang web cung cấp các công cụ hoặc dịch vụ trực tuyến cho người dùng, chẳng hạn như Google, Dropbox hay GitHub.", "Tool", "Công cụ" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that provide online courses or study materials, such as Coursera, edX, or Udemy.", "Đây là trang web cung cấp các khóa học hoặc tài liệu học tập trực tuyến, chẳng hạn như Coursera, edX hay Udemy.", "Online-learning", "Học tập trực tuyến" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "I'm too lazy to write it down, I can't edit it anymore", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "Food", "Ẩm thực" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "Phòng trưng bày", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "Exhibition", "Trưng bày" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "Travel", "Du lịch" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "I'm too lazy to write it down, I can't edit it anymore", "Sports", "Thể thao" });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "CategoryId", "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryImage", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { 13, "A huge list of the best business website templates is built to serve any company, from construction to business consulting and financial services. All templates are mobile-friendly and feature both one-page and multi-page setups. Whether you are bringing a fresh project or redesigning your current website, these templates have you covered. They are powerful enough to meet any firm and organization owner’s needs and requirements.", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "/assets/dev.png", "Business", "Kinh doanh" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductRating", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 11, 14, 39, 52, 614, DateTimeKind.Local).AddTicks(852), 4.0, new DateTime(2023, 6, 11, 14, 39, 52, 614, DateTimeKind.Local).AddTicks(867) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "ProductRating",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "Nước uống có gas cực ngon", "", "Thử nghiệm 2", "" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "Nước uống có gas cực ngon", null, "Thử nghiệm 1", "" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that provide information on a specific topic, such as news websites, educational websites, or government websites.", "Đây là trang web cung cấp thông tin về một chủ đề cụ thể, chẳng hạn như trang web tin tức, trang web giáo dục hoặc trang web chính phủ.", "Informational", "Thông tin" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that allow users to purchase items online, such as online shopping websites or auction websites.", "Đây là trang web cho phép người dùng mua hàng trực tuyến, chẳng hạn như trang web bán hàng trực tuyến hay trang web đấu giá.", "E-commerce", "Thương mại điện tử" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that provide entertainment content, such as movie streaming websites, gaming websites, or music streaming websites.", "Đây là trang web cung cấp các nội dung giải trí, chẳng hạn như trang web xem phim, trang web chơi game hoặc trang web nghe nhạc.", "Entertainment", "Giải trí" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that allow users to interact and connect with each other, such as Facebook, Twitter, or Instagram.", "Đây là trang web cho phép người dùng tương tác và kết nối với nhau, chẳng hạn như Facebook, Twitter, Instagram.", "Social-media", "Mạng xã hội" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are personal or business websites that provide the latest posts and information on a specific topic.", "Đây là trang web cá nhân hoặc doanh nghiệp cung cấp các bài viết và thông tin mới nhất về chủ đề cụ thể.", "Blog", "Blog" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that allow users to discuss a specific topic and share their opinions with others.", "Đây là trang web cho phép người dùng thảo luận về một chủ đề cụ thể và chia sẻ ý kiến của mình với những người khác.", "Forum", "Diễn đàn" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that provide online tools or services for users, such as Google, Dropbox, or GitHub.", "Đây là trang web cung cấp các công cụ hoặc dịch vụ trực tuyến cho người dùng, chẳng hạn như Google, Dropbox hay GitHub.", "Tool", "Công cụ" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "These are websites that provide online courses or study materials, such as Coursera, edX, or Udemy.", "Đây là trang web cung cấp các khóa học hoặc tài liệu học tập trực tuyến, chẳng hạn như Coursera, edX hay Udemy.", "Online-learning", "Học tập trực tuyến" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "Food", "Ẩm thực" });

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 12,
                columns: new[] { "CategoryDescriptionEnglish", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[] { "Phòng trưng bày", "Exhibition", "Trưng bày" });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "CategoryId", "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryImage", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[,]
                {
                    { 14, "I'm too lazy to write it down, I can't edit it anymore", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "no Img", "Travel", "Du lịch" },
                    { 15, "I'm too lazy to write it down, I can't edit it anymore", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "no Img", "Sports", "Thể thao" },
                    { 16, "A huge list of the best business website templates is built to serve any company, from construction to business consulting and financial services. All templates are mobile-friendly and feature both one-page and multi-page setups. Whether you are bringing a fresh project or redesigning your current website, these templates have you covered. They are powerful enough to meet any firm and organization owner’s needs and requirements.", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "/assets/dev.png", "Business", "Kinh doanh" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 16, 55, 51, 414, DateTimeKind.Local).AddTicks(8620), new DateTime(2023, 6, 6, 16, 55, 51, 414, DateTimeKind.Local).AddTicks(8639) });
        }
    }
}
