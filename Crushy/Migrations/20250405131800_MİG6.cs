using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Crushy.Migrations
{
    /// <inheritdoc />
    public partial class MİG6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubscriptionPlans",
                columns: new[] { "Id", "DurationInDays", "Features", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 0, "Premium üyelik paketi", "Premium", 29.99m },
                    { 2, 0, "EVO üyelik paketi", "EVO", 49.99m }
                });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Coin", "Email", "Fullname", "ImageUrl", "Map" },
                values: new object[] { 1000, "admin@crushy.com", "Admin User", "https://randomuser.me/api/portraits/men/1.jpg", "40.7128,-74.0060" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Role", "Username" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$E/Fepzvh6k7IoC9yix7f0.WLj5rSuKtsdZPJt7zoRYQI4t1XhiKD6", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Password", "RefreshToken", "RefreshTokenExpiryTime", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$2RIcz0nRnuwBoCheLKmD2.aHS3/IBfurrapmMHqQyii9TJxBB7Z6a", null, null, "VerifiedUser", null, "emma.wilson" },
                    { 3, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$Qwtn8q4aJdV1zQClOk5MPeI6DUuwoQrFzWiZ76dXRx2lve5dwkOJ.", null, null, "VerifiedUser", null, "james.smith" },
                    { 4, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$Dnb2M0kDpwl/EFEBaN1.D.hYojvbNixIkXn0l5E3iXxYQsayeKbFi", null, null, "VerifiedUser", null, "sophia.brown" },
                    { 5, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$JWOxfDQg4GMVV1yDMB4RyuUD3nwoG8u6rJyqmnYJZ/YhZ20Btotnu", null, null, "VerifiedUser", null, "oliver.taylor" }
                });

            migrationBuilder.InsertData(
                table: "BlockedUsers",
                columns: new[] { "Id", "BlockedAt", "BlockedUserId", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 4, 3, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(875), false, null, 2 });

            migrationBuilder.InsertData(
                table: "MatchedUsers",
                columns: new[] { "Id", "MatchedAt", "User1Id", "User2Id" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 26, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(782), 2, 3 },
                    { 2, new DateTime(2025, 3, 31, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(784), 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "CreatedAt", "IsDeleted", "ReceiverId", "SenderId", "SentAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Merhaba, nasılsın?", new DateTime(2025, 3, 27, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(829), false, 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "İyiyim, teşekkürler! Sen nasılsın?", new DateTime(2025, 3, 27, 13, 22, 58, 984, DateTimeKind.Utc).AddTicks(832), false, 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "Selam! Profilini çok beğendim.", new DateTime(2025, 4, 1, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(835), false, 5, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserId", "Coin", "Email", "Fullname", "Gender", "ImageUrl", "Map" },
                values: new object[,]
                {
                    { 2, 50, "emma@example.com", "Emma Wilson", false, "https://randomuser.me/api/portraits/women/2.jpg", "51.5074,-0.1278" },
                    { 3, 75, "james@example.com", "James Smith", true, "https://randomuser.me/api/portraits/men/3.jpg", "48.8566,2.3522" },
                    { 4, 30, "sophia@example.com", "Sophia Brown", false, "https://randomuser.me/api/portraits/women/4.jpg", "52.5200,13.4050" },
                    { 5, 45, "oliver@example.com", "Oliver Taylor", true, "https://randomuser.me/api/portraits/men/5.jpg", "41.9028,12.4964" }
                });

            migrationBuilder.InsertData(
                table: "UserSubscriptions",
                columns: new[] { "Id", "EndDate", "PlanId", "StartDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 4, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(689), 1, new DateTime(2025, 3, 6, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(672), "active", 2 },
                    { 2, new DateTime(2025, 6, 19, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(692), 2, new DateTime(2025, 3, 21, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(691), "active", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Coin", "Email", "Fullname", "ImageUrl", "Map" },
                values: new object[] { 20, "string@gmail.com", "string", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Role", "Username" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$6SUQkhKf5jN.2aGd1zcPhu99OSYPzWvuE2BjJsO/Nl16a723Uy14i", "VerifiedUser", "string" });
        }
    }
}
