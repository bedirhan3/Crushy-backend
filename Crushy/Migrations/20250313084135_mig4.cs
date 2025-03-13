using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crushy.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Password", "RefreshToken", "RefreshTokenExpiryTime", "Role", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2025, 3, 13, 11, 41, 33, 667, DateTimeKind.Local).AddTicks(4854), false, "$2a$11$lpH5UgRf/mehKYm0n2HRPuIObu0E6MYwtbJOEVmmqwBnnbdjrnz5W", null, null, "VerifiedUser", null, "string" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserId", "Coin", "Email", "Fullname", "Gender", "ImageUrl", "Map" },
                values: new object[] { 1, 20, "string@gmail.com", "string", true, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
