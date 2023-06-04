using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class demo_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 5, 4, 26, 35, 252, DateTimeKind.Local).AddTicks(342), new DateTime(2023, 6, 5, 4, 26, 35, 252, DateTimeKind.Local).AddTicks(356) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "OrderHeaders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductCreatedDate", "ProductUpdatedDate" },
                values: new object[] { new DateTime(2023, 6, 5, 2, 46, 7, 460, DateTimeKind.Local).AddTicks(8765), new DateTime(2023, 6, 5, 2, 46, 7, 460, DateTimeKind.Local).AddTicks(8781) });
        }
    }
}
