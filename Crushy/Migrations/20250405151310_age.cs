using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Crushy.Migrations
{
    /// <inheritdoc />
    public partial class age : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "UserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 26, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 31, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 15, 18, 9, 288, DateTimeKind.Utc).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "CreatedAt", "IsDeleted", "ReceiverId", "SenderId", "SentAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, "Teşekkür ederim, seninkini de beğendim!", new DateTime(2025, 4, 1, 15, 23, 9, 288, DateTimeKind.Utc).AddTicks(1084), false, 4, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, "Bu hafta sonu bir şeyler yapmak ister misin?", new DateTime(2025, 4, 3, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1138), false, 5, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPlans",
                columns: new[] { "Id", "DurationInDays", "Features", "Name", "Price" },
                values: new object[] { 3, 0, "Temel üyelik paketi", "Basic", 9.99m });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Age",
                value: 35);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Age",
                value: 28);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Age",
                value: 32);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Age",
                value: 25);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Age",
                value: 30);

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 4, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(447), new DateTime(2025, 3, 6, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(437) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 19, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(451), new DateTime(2025, 3, 21, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$sdlYh/EB0y7qksOS4uSdme2c421RKjwKV6wcVx7UbuAlQ5YqtR4Ne");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$VI2okUWtwKmfa7Ysfe855.ctXFKIyDKUPkOdZkE3B7LBSD4RQ.yhi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$EzzIBuW8KHFvzm/JqoYgBuZvAE5tiMt//I5DCKhTJEeDBwttgH7BS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$AJ1HQnRnxDD9DGwKl7Uc9.2vKbhRczuiGO5HfWGOOVQJ0qDGLkeHC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$LP494OzE0fvv.zfHmylh/OEs9HMs7ohrt6JxhF3rGdBGebfJT8CEO");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Password", "RefreshToken", "RefreshTokenExpiryTime", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 6, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$iA7VpecC8zSWrzSnupoU8.AI/f2gXB9yPclu0BrH4x0klPPAsO0.q", null, null, "VerifiedUser", null, "ava.johnson" },
                    { 7, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$v78pekC5HWUi/PcUYu8UzeRSoTfMX7aG88FiuGuRsVtbIZ4Ms3lqS", null, null, "VerifiedUser", null, "noah.williams" },
                    { 8, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$jt/fRQXDrQr9hHGHXoQkpu./ihRpf7KqoQHxLhhBbqKX77FpD8iES", null, null, "VerifiedUser", null, "mia.davis" },
                    { 9, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$ntQerq7mLCuCG0lIfEbfyuh8Hq.7Rtts.0Y.Gyxa4xjxoD1MZC5ZW", null, null, "VerifiedUser", null, "liam.garcia" },
                    { 10, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$LEXkIknXbujzsvriZlhVmu0j0iSJdfj1jDCqhlcjqgM12JbQneL8a", null, null, "VerifiedUser", null, "emily.miller" },
                    { 11, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$xjQZ0pxe8dZ5tvK9PKDeNer0gQ9IniY.49aYVvWNk4SFt8sof0KCS", null, null, "User", null, "ethan.anderson" },
                    { 12, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$G9VJMZboB2ioleVzpYd4UOT.dbzAeJzZHDidmPJyz9NMV2SDLOcW2", null, null, "User", null, "amelia.thomas" }
                });

            migrationBuilder.InsertData(
                table: "BlockedUsers",
                columns: new[] { "Id", "BlockedAt", "BlockedUserId", "CreatedAt", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2025, 3, 31, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1197), false, null, 6 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 4, 2, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1200), false, null, 8 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 3, 29, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1202), false, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "MatchedUsers",
                columns: new[] { "Id", "MatchedAt", "User1Id", "User2Id" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 3, 21, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(536), 6, 7 },
                    { 4, new DateTime(2025, 3, 28, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(747), 8, 9 },
                    { 5, new DateTime(2025, 4, 2, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(750), 10, 11 },
                    { 6, new DateTime(2025, 3, 24, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(752), 2, 7 },
                    { 7, new DateTime(2025, 3, 29, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(754), 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "CreatedAt", "IsDeleted", "ReceiverId", "SenderId", "SentAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, "Merhaba, burada yeni misin?", new DateTime(2025, 3, 22, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1094), false, 7, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, "Evet, yeni kayıt oldum. Seni tanımaktan memnun oldum!", new DateTime(2025, 3, 22, 15, 28, 9, 288, DateTimeKind.Utc).AddTicks(1096), false, 6, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, "Selam! Hangi şehirde yaşıyorsun?", new DateTime(2025, 3, 29, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1099), false, 9, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, "İstanbul'da yaşıyorum. Sen nerelisin?", new DateTime(2025, 3, 29, 15, 21, 9, 288, DateTimeKind.Utc).AddTicks(1101), false, 8, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, "Merhaba, hobilerin neler?", new DateTime(2025, 4, 3, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1109), false, 11, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, "Merhaba! Yüzmeyi, kitap okumayı ve film izlemeyi seviyorum. Sen nelerden hoşlanırsın?", new DateTime(2025, 4, 3, 15, 33, 9, 288, DateTimeKind.Utc).AddTicks(1112), false, 10, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, "Merhaba, seni tanımaktan memnun oldum!", new DateTime(2025, 3, 25, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1115), false, 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, "Ben de memnun oldum! Nasıl gidiyor?", new DateTime(2025, 3, 25, 15, 43, 9, 288, DateTimeKind.Utc).AddTicks(1130), false, 2, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, "Profilin çok ilgi çekici görünüyor. Nelerden hoşlanırsın?", new DateTime(2025, 3, 30, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1133), false, 8, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, "Teşekkürler! Müzik dinlemeyi, yemek yapmayı ve doğada vakit geçirmeyi seviyorum.", new DateTime(2025, 3, 30, 15, 28, 9, 288, DateTimeKind.Utc).AddTicks(1135), false, 3, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserId", "Age", "Coin", "Email", "Fullname", "Gender", "ImageUrl", "Map" },
                values: new object[,]
                {
                    { 6, 24, 60, "ava@example.com", "Ava Johnson", false, "https://randomuser.me/api/portraits/women/6.jpg", "34.0522,-118.2437" },
                    { 7, 29, 55, "noah@example.com", "Noah Williams", true, "https://randomuser.me/api/portraits/men/7.jpg", "35.6762,139.6503" },
                    { 8, 27, 40, "mia@example.com", "Mia Davis", false, "https://randomuser.me/api/portraits/women/8.jpg", "19.4326,-99.1332" },
                    { 9, 31, 65, "liam@example.com", "Liam Garcia", true, "https://randomuser.me/api/portraits/men/9.jpg", "-33.8688,151.2093" },
                    { 10, 23, 35, "emily@example.com", "Emily Miller", false, "https://randomuser.me/api/portraits/women/10.jpg", "55.7558,37.6173" },
                    { 11, 34, 25, "ethan@example.com", "Ethan Anderson", true, "https://randomuser.me/api/portraits/men/11.jpg", "37.7749,-122.4194" },
                    { 12, 26, 20, "amelia@example.com", "Amelia Thomas", false, "https://randomuser.me/api/portraits/women/12.jpg", "43.6532,-79.3832" }
                });

            migrationBuilder.InsertData(
                table: "UserSubscriptions",
                columns: new[] { "Id", "EndDate", "PlanId", "StartDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 5, 20, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(454), 1, new DateTime(2025, 2, 19, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(453), "active", 6 },
                    { 4, new DateTime(2025, 5, 5, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(457), 2, new DateTime(2025, 2, 4, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(456), "active", 7 },
                    { 5, new DateTime(2025, 3, 6, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(460), 1, new DateTime(2025, 1, 5, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(459), "expired", 9 },
                    { 6, new DateTime(2025, 4, 25, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(463), 3, new DateTime(2025, 3, 26, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(462), "active", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Age",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(875));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 26, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 31, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 13, 22, 58, 984, DateTimeKind.Utc).AddTicks(832));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 4, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(689), new DateTime(2025, 3, 6, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 19, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(692), new DateTime(2025, 3, 21, 13, 17, 58, 984, DateTimeKind.Utc).AddTicks(691) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$E/Fepzvh6k7IoC9yix7f0.WLj5rSuKtsdZPJt7zoRYQI4t1XhiKD6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$2RIcz0nRnuwBoCheLKmD2.aHS3/IBfurrapmMHqQyii9TJxBB7Z6a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Qwtn8q4aJdV1zQClOk5MPeI6DUuwoQrFzWiZ76dXRx2lve5dwkOJ.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$Dnb2M0kDpwl/EFEBaN1.D.hYojvbNixIkXn0l5E3iXxYQsayeKbFi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$JWOxfDQg4GMVV1yDMB4RyuUD3nwoG8u6rJyqmnYJZ/YhZ20Btotnu");
        }
    }
}
