using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class demo_19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 11, 15, 16, 3, 610, DateTimeKind.Local).AddTicks(7353), new DateTime(2023, 6, 11, 15, 16, 3, 610, DateTimeKind.Local).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "ProductCreatedDate", "ProductRating", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 11, 15, 16, 3, 610, DateTimeKind.Local).AddTicks(7373), 3.0, new DateTime(2023, 6, 11, 15, 16, 3, 610, DateTimeKind.Local).AddTicks(7374) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 11, 14, 56, 50, 749, DateTimeKind.Local).AddTicks(7813), new DateTime(2023, 6, 11, 14, 56, 50, 749, DateTimeKind.Local).AddTicks(7828) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "ProductCreatedDate", "ProductRating", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 11, 14, 56, 50, 749, DateTimeKind.Local).AddTicks(7835), 4.0, new DateTime(2023, 6, 11, 14, 56, 50, 749, DateTimeKind.Local).AddTicks(7836) });
        }
    }
}
