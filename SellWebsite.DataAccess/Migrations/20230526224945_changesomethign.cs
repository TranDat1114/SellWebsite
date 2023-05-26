using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changesomethign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "AspNetUsers",
                newName: "State");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductCreatedDate",
                value: new DateTime(2023, 5, 27, 5, 49, 45, 123, DateTimeKind.Local).AddTicks(1822));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "AspNetUsers",
                newName: "City");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductCreatedDate",
                value: new DateTime(2023, 5, 27, 5, 20, 27, 248, DateTimeKind.Local).AddTicks(9517));
        }
    }
}
