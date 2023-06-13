using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class demo_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "OrderHeaders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 5, 2, 46, 7, 460, DateTimeKind.Local).AddTicks(8765), new DateTime(2023, 6, 5, 2, 46, 7, 460, DateTimeKind.Local).AddTicks(8781) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "OrderHeaders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 4, 21, 31, 36, 683, DateTimeKind.Local).AddTicks(7977), new DateTime(2023, 6, 4, 21, 31, 36, 683, DateTimeKind.Local).AddTicks(7991) });
        }
    }
}
