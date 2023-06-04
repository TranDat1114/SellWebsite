using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class demo_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 4, 14, 4, 8, 252, DateTimeKind.Local).AddTicks(2821), new DateTime(2023, 6, 4, 14, 4, 8, 252, DateTimeKind.Local).AddTicks(2841) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 4, 13, 49, 16, 546, DateTimeKind.Local).AddTicks(442), new DateTime(2023, 6, 4, 13, 49, 16, 546, DateTimeKind.Local).AddTicks(451) });
        }
    }
}
