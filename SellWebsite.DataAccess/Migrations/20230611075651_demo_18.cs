using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class demo_18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductPrice", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 11, 14, 56, 50, 749, DateTimeKind.Local).AddTicks(7813), 50m, new DateTime(2023, 6, 11, 14, 56, 50, 749, DateTimeKind.Local).AddTicks(7828) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductAuthor", "ProductCreatedDate", "ProductCredits", "ProductDescription", "ProductDownloadCount", "ProductDownloadUrl", "ProductLicense", "ProductPostsBy", "ProductPreviewUrl", "ProductPrice", "ProductRating", "ProductTitle", "ProductUpdatedDate" },
                values: new object[] { 2, "TranPhuDat", new DateTime(2023, 6, 11, 14, 56, 50, 749, DateTimeKind.Local).AddTicks(7835), "Images from Unsplash;Boostrap", "Glint is a modern and stylish digital agency HTML template. Designed for creative designers, agencies, freelancers, photographers, or any creative profession.", 3, "https://trandat1114.github.io/DotnetuniverseProject/#!/", "", "ADminTPD", "https://trandat1114.github.io/DotnetuniverseProject/#!/", 999m, 4.0, "Dotnet Universe", new DateTime(2023, 6, 11, 14, 56, 50, 749, DateTimeKind.Local).AddTicks(7836) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductPrice", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 11, 14, 39, 52, 614, DateTimeKind.Local).AddTicks(852), 500000m, new DateTime(2023, 6, 11, 14, 39, 52, 614, DateTimeKind.Local).AddTicks(867) });
        }
    }
}
