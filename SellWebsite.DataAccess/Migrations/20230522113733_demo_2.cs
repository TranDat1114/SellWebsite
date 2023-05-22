using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class demo_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Products",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValueSql: "'~/assets/dev.png'");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryImage",
                table: "Catagories",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValueSql: "'~/assets/avatar.jpg'",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 16,
                column: "CategoryImage",
                value: "~/assets/avatar.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductCreatedDate",
                value: new DateTime(2023, 5, 22, 18, 37, 33, 245, DateTimeKind.Local).AddTicks(5626));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryImage",
                table: "Catagories",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256,
                oldDefaultValueSql: "'~/assets/avatar.jpg'");

            migrationBuilder.UpdateData(
                table: "Catagories",
                keyColumn: "CategoryId",
                keyValue: 16,
                column: "CategoryImage",
                value: "No img");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductCreatedDate",
                value: new DateTime(2023, 5, 21, 18, 1, 45, 298, DateTimeKind.Local).AddTicks(3274));
        }
    }
}
