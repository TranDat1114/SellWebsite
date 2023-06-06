using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class demo_15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "OrderHeaders",
                newName: "PaymentId");

            migrationBuilder.RenameColumn(
                name: "PaymentIntendId",
                table: "OrderHeaders",
                newName: "PayerId");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 16, 55, 51, 414, DateTimeKind.Local).AddTicks(8620), new DateTime(2023, 6, 6, 16, 55, 51, 414, DateTimeKind.Local).AddTicks(8639) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "OrderHeaders",
                newName: "SessionId");

            migrationBuilder.RenameColumn(
                name: "PayerId",
                table: "OrderHeaders",
                newName: "PaymentIntendId");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 5, 4, 26, 35, 252, DateTimeKind.Local).AddTicks(342), new DateTime(2023, 6, 5, 4, 26, 35, 252, DateTimeKind.Local).AddTicks(356) });
        }
    }
}
