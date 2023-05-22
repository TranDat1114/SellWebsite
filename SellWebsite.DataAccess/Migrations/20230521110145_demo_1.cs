using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class demo_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryNameEnglish = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    CategoryImage = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    CategoryDescriptionEnglish = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    CategoryNameVietnamese = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CategoryDescriptionVietnamese = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProductAuthor = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ProductCreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GETDATE()"),
                    ProductUpdatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GETDATE()"),
                    ProductLicense = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    ProductCredits = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ProductPreviewUrl = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProductDownloadCount = table.Column<int>(type: "int", nullable: false),
                    ProductDownloadUrl = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProductPostsBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Catagories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Catagories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Catagories",
                columns: new[] { "CategoryId", "CategoryDescriptionEnglish", "CategoryDescriptionVietnamese", "CategoryImage", "CategoryNameEnglish", "CategoryNameVietnamese" },
                values: new object[,]
                {
                    { 1, "Nước uống có gas cực ngon", "", "no Img", "Thử nghiệm 2", "" },
                    { 2, "Nước uống có gas cực ngon", null, "no Img", "Thử nghiệm 1", "" },
                    { 3, "These are websites that provide information on a specific topic, such as news websites, educational websites, or government websites.", "Đây là trang web cung cấp thông tin về một chủ đề cụ thể, chẳng hạn như trang web tin tức, trang web giáo dục hoặc trang web chính phủ.", "no Img", "Informational", "Thông tin" },
                    { 4, "These are websites that allow users to purchase items online, such as online shopping websites or auction websites.", "Đây là trang web cho phép người dùng mua hàng trực tuyến, chẳng hạn như trang web bán hàng trực tuyến hay trang web đấu giá.", "no Img", "E-commerce", "Thương mại điện tử" },
                    { 5, "These are websites that provide entertainment content, such as movie streaming websites, gaming websites, or music streaming websites.", "Đây là trang web cung cấp các nội dung giải trí, chẳng hạn như trang web xem phim, trang web chơi game hoặc trang web nghe nhạc.", "no Img", "Entertainment", "Giải trí" },
                    { 6, "These are websites that allow users to interact and connect with each other, such as Facebook, Twitter, or Instagram.", "Đây là trang web cho phép người dùng tương tác và kết nối với nhau, chẳng hạn như Facebook, Twitter, Instagram.", "no Img", "Social media", "Mạng xã hội" },
                    { 7, "These are personal or business websites that provide the latest posts and information on a specific topic.", "Đây là trang web cá nhân hoặc doanh nghiệp cung cấp các bài viết và thông tin mới nhất về chủ đề cụ thể.", "no Img", "Blog", "Blog" },
                    { 8, "These are websites that allow users to discuss a specific topic and share their opinions with others.", "Đây là trang web cho phép người dùng thảo luận về một chủ đề cụ thể và chia sẻ ý kiến của mình với những người khác.", "no Img", "Forum", "Diễn đàn" },
                    { 9, "These are websites that provide online tools or services for users, such as Google, Dropbox, or GitHub.", "Đây là trang web cung cấp các công cụ hoặc dịch vụ trực tuyến cho người dùng, chẳng hạn như Google, Dropbox hay GitHub.", "no Img", "Tool", "Công cụ" },
                    { 10, "These are websites that provide online courses or study materials, such as Coursera, edX, or Udemy.", "Đây là trang web cung cấp các khóa học hoặc tài liệu học tập trực tuyến, chẳng hạn như Coursera, edX hay Udemy.", "no Img", "Online learning", "Học tập trực tuyến" },
                    { 11, "I'm too lazy to write it down, I can't edit it anymore", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "no Img", "Food", "Ẩm thực" },
                    { 12, "Phòng trưng bày", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "no Img", "Exhibition", "Trưng bày" },
                    { 14, "I'm too lazy to write it down, I can't edit it anymore", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "no Img", "Travel", "Du lịch" },
                    { 15, "I'm too lazy to write it down, I can't edit it anymore", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "no Img", "Sports", "Thể thao" },
                    { 16, "A huge list of the best business website templates is built to serve any company, from construction to business consulting and financial services. All templates are mobile-friendly and feature both one-page and multi-page setups. Whether you are bringing a fresh project or redesigning your current website, these templates have you covered. They are powerful enough to meet any firm and organization owner’s needs and requirements.", "Lười quá hông có ghi nữa, nào hết lười sửa lại", "No img", "Business", "Kinh doanh" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductAuthor", "ProductCreatedDate", "ProductCredits", "ProductDescription", "ProductDownloadCount", "ProductDownloadUrl", "ProductLicense", "ProductPostsBy", "ProductPreviewUrl", "ProductTitle" },
                values: new object[] { 1, "TranPhuDat", new DateTime(2023, 5, 21, 18, 1, 45, 298, DateTimeKind.Local).AddTicks(3274), "Images from Unsplash;Boostrap", "Glint is a modern and stylish digital agency HTML template. Designed for creative designers, agencies, freelancers, photographers, or any creative profession.", 0, "linkdownloadFIle", "", "ADminTPD", "LinkPreviewUrl", "Glint" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Catagories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
