using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addGet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductCreatedDate",
                table: "Products",
                type: "Date",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductCreatedDate",
                value: new DateTime(2023, 5, 17, 13, 23, 8, 14, DateTimeKind.Local).AddTicks(9216));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductCreatedDate",
                table: "Products",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 5, 17, 12, 28, 42, 62, DateTimeKind.Local).AddTicks(1921), new DateTime(2023, 5, 17, 12, 28, 42, 62, DateTimeKind.Local).AddTicks(1930) });
        }
    }
}
