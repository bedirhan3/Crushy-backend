using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Crushy.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 29, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 26, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(187));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(189));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 28, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 2, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(194));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 24, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 29, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 20, 18, 8, 642, DateTimeKind.Utc).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(799));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 20, 23, 8, 642, DateTimeKind.Utc).AddTicks(802));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 22, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 22, 20, 28, 8, 642, DateTimeKind.Utc).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 29, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 29, 20, 21, 8, 642, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 20, 33, 8, 642, DateTimeKind.Utc).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 20, 43, 8, 642, DateTimeKind.Utc).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 20, 28, 8, 642, DateTimeKind.Utc).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 4, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(90), new DateTime(2025, 3, 6, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 19, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(94), new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(93) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 20, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(97), new DateTime(2025, 2, 19, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 5, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(99), new DateTime(2025, 2, 4, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(98) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 3, 6, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(101), new DateTime(2025, 1, 5, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(101) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 25, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(104), new DateTime(2025, 3, 26, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(103) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$K5AR6rLuKPdM6GYY.mdqPesJhmnWt/K5H1y8IH7nlVApNxvJ5k.QS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$gP/AY1vJLFD42/KuWobX4u5F7yg2tz5y.E06SWAbPwbOC8/byxf8a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$NbkU051A0pxUIOuy52wFQeG45rRl0KLd0zzfqkZlZepdIh9D5Hhpe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$zuRjWYGiwXbucPryt3dMdu6qdOa4QOXhB2zNG5OQ.9QTr.TQIidoK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$8KBz3T8WTfmxqfaCErr6y.jGaPUAdMyrYsMVIf60wW5qIl2wVYPv.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$1GEfwlMS6ViOx78ei/cUwuoTqhggurKadhezaSwoCYHrTYypBMnem");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$HZcS./ikOjFZcpE3OOtugemXve.PYiopnBr7zp/REZ3XsgE2YqT7y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$vI4tTx3FVZ5heRl/vUcluOSS562y1IdIeyoTe9RN6Mld8Uys6AHWm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$dUUYx49TKvYiXkldf7jQaeiMFMvErD2xPPHoXsRy2G4zErjPV/86y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$fFVDBWhGSaV3XA4ZwR6SseqsE.8RQo0BxsG.DA7RyRzsduYVflApK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$K96nFrb6qpLVN6TzZjVG6OnmvdTxLSyvndl9OkvAegpyHPEraDEA.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$oqcr1Yy4Y85.K1f0P4YbhuK8KHTY6v8z9SWCr3i8EwS.BlhfOd4My");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Password", "RefreshToken", "RefreshTokenExpiryTime", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 13, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$NWfKi9.Pcp213EDeTyNEYeZe4ZPA9N9ar68EHd.nnq1DBchPZh31y", null, null, "VerifiedUser", null, "ahmet.yilmaz" },
                    { 14, new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$F/aXGiOggf4laDOBHEie1.r3G/06IZI6lyZKrP8NJT.XEpyqHXPUW", null, null, "VerifiedUser", null, "ayse.demir" },
                    { 15, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$oAFjjmS9WQ0iTe.lTibAvufeew748MhnuBZ0CiY1v8J6B4cJM/PnC", null, null, "VerifiedUser", null, "mehmet.kaya" },
                    { 16, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$cJNobZskGHPlBrzGuCkqOOIn9ZjOxrj1SzO9INpXM6gG/PTNZgNq2", null, null, "VerifiedUser", null, "zeynep.celik" },
                    { 17, new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$VkGwPZbNb2eFwVD0AMpi5OPw5zrtQXCDbSt1xkXYSH9W9U23Ing8W", null, null, "VerifiedUser", null, "mustafa.sahin" },
                    { 18, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$D/DdDxpQozK31EYFOV9.1elwHvR/MAIZFSIzzN4530Ej.NTrfmNV.", null, null, "VerifiedUser", null, "elif.yildiz" },
                    { 19, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$ixzJRiFZv5lxDRuxVN4PX.B2TwLC3BnRzVpz.myxkoguaI/Bccx6O", null, null, "VerifiedUser", null, "emre.ozturk" },
                    { 20, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$Qgz1/TSDBzcabC08WOLaluHYpEu3zE3NdKn2S8BkrqO04BUKFP1PS", null, null, "VerifiedUser", null, "selin.aksoy" },
                    { 21, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$.P2x1ESKn.5Zh3zzBcQ7IupNonN/sFQsGTNeVn/V4jMNba/sXncvi", null, null, "VerifiedUser", null, "burak.korkmaz" },
                    { 22, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2a$11$iP24qvjLN0NzxwC0lBnnSOKhUTtaEFEOXTiNhIcaJkQBwlpv0tE0q", null, null, "VerifiedUser", null, "ece.aydin" }
                });

            migrationBuilder.InsertData(
                table: "MatchedUsers",
                columns: new[] { "Id", "MatchedAt", "User1Id", "User2Id" },
                values: new object[,]
                {
                    { 8, new DateTime(2025, 3, 18, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(199), 13, 14 },
                    { 9, new DateTime(2025, 3, 20, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(220), 15, 16 },
                    { 10, new DateTime(2025, 3, 22, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(222), 17, 18 },
                    { 11, new DateTime(2025, 3, 24, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(223), 19, 20 },
                    { 12, new DateTime(2025, 3, 26, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(225), 21, 22 },
                    { 13, new DateTime(2025, 3, 27, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(227), 13, 16 },
                    { 14, new DateTime(2025, 3, 28, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(228), 15, 18 },
                    { 15, new DateTime(2025, 3, 29, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(230), 17, 20 },
                    { 16, new DateTime(2025, 3, 30, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(232), 19, 22 },
                    { 17, new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(233), 14, 21 },
                    { 18, new DateTime(2025, 3, 19, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(235), 13, 2 },
                    { 19, new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(236), 14, 3 },
                    { 20, new DateTime(2025, 3, 23, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(238), 15, 4 },
                    { 21, new DateTime(2025, 3, 25, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(241), 16, 5 },
                    { 22, new DateTime(2025, 3, 27, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(242), 17, 6 },
                    { 23, new DateTime(2025, 3, 29, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(244), 18, 7 },
                    { 24, new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(245), 19, 8 },
                    { 25, new DateTime(2025, 4, 2, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(247), 20, 9 },
                    { 26, new DateTime(2025, 4, 3, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(248), 21, 10 },
                    { 27, new DateTime(2025, 4, 4, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(250), 22, 11 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "CreatedAt", "IsDeleted", "ReceiverId", "SenderId", "SentAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 16, "Merhaba Ayşe, profilini inceledim ve ortak ilgi alanlarımız olduğunu fark ettim.", new DateTime(2025, 3, 18, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(870), false, 14, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 17, "Merhaba Ahmet, teşekkürler. Ben de senin profilini beğendim. Hangi ilgi alanlarından bahsediyorsun?", new DateTime(2025, 3, 18, 20, 33, 8, 642, DateTimeKind.Utc).AddTicks(872), false, 13, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 18, "Özellikle sinema ve müzik konusundaki zevklerimiz benziyor gibi. En sevdiğin film nedir?", new DateTime(2025, 3, 18, 20, 48, 8, 642, DateTimeKind.Utc).AddTicks(874), false, 14, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, "Merhaba Zeynep, Ankara'da yaşadığını gördüm. Hangi semtte oturuyorsun?", new DateTime(2025, 3, 20, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(876), false, 16, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 20, "Merhaba Mehmet, Çankaya'da yaşıyorum. Sen?", new DateTime(2025, 3, 20, 21, 13, 8, 642, DateTimeKind.Utc).AddTicks(878), false, 15, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 21, "Ben de Çankaya'dayım. Bu hafta sonu bir kahve içmek ister misin?", new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(881), false, 16, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 22, "Merhaba Elif, İzmir'de yeni mi yaşıyorsun?", new DateTime(2025, 3, 22, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(883), false, 18, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 23, "Merhaba Mustafa, hayır yaklaşık 3 yıldır buradayım. Sen?", new DateTime(2025, 3, 22, 20, 58, 8, 642, DateTimeKind.Utc).AddTicks(885), false, 17, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 24, "Ben 5 yıldır İzmir'deyim. En sevdiğin yer neresi şehirde?", new DateTime(2025, 3, 23, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(887), false, 18, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 25, "Merhaba Selin, fotoğrafın çok güzel. Nerede çekildi?", new DateTime(2025, 3, 25, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(890), false, 20, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 26, "Teşekkürler Emre, fotoğraf Antalya Kaleiçi'nde çekildi. Sen hiç gittin mi?", new DateTime(2025, 3, 25, 22, 13, 8, 642, DateTimeKind.Utc).AddTicks(892), false, 19, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 27, "Merhaba Ece, profilinde gördüğüm kadarıyla müzikle ilgileniyorsun. Hangi tür müzikleri seviyorsun?", new DateTime(2025, 3, 27, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(894), false, 22, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 28, "Merhaba Burak, evet müzik benim tutkum. Özellikle rock ve alternatif müzik dinlemeyi seviyorum. Sen?", new DateTime(2025, 3, 27, 20, 53, 8, 642, DateTimeKind.Utc).AddTicks(896), false, 21, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 29, "Hello Emma, I'm from Turkey. Would you like to practice Turkish with me?", new DateTime(2025, 3, 19, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(899), false, 2, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 30, "Hi Ahmet, sure I'd love to learn some Turkish! Can you teach me basic phrases?", new DateTime(2025, 3, 19, 21, 13, 8, 642, DateTimeKind.Utc).AddTicks(901), false, 13, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 31, "Hello James, I saw your profile. What brings you to this app?", new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(904), false, 3, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 32, "Hi Ayşe, I'm looking to meet new people from different cultures. How about you?", new DateTime(2025, 3, 21, 23, 13, 8, 642, DateTimeKind.Utc).AddTicks(906), false, 14, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 33, "Hello Oliver, your travel photos look amazing. Where was your favorite place?", new DateTime(2025, 3, 25, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(908), false, 5, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 34, "Hi Zeynep, thanks! I think my favorite was Turkey actually. I loved Istanbul!", new DateTime(2025, 3, 25, 22, 13, 8, 642, DateTimeKind.Utc).AddTicks(910), false, 16, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 35, "Hello Mia, I'd like to practice my English. Would you mind chatting?", new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(912), false, 8, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 36, "Hi Emre, I don't mind at all! Your English seems good already!", new DateTime(2025, 3, 31, 20, 43, 8, 642, DateTimeKind.Utc).AddTicks(914), false, 19, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 37, "Hello Liam, I see you're interested in photography. What kind of photos do you take?", new DateTime(2025, 4, 2, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(916), false, 9, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 38, "Hi Selin, I mostly do landscape and street photography. I'd love to visit Turkey someday for photos!", new DateTime(2025, 4, 2, 21, 13, 8, 642, DateTimeKind.Utc).AddTicks(918), false, 20, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 39, "Hello Emily, I noticed we matched recently. What are your hobbies?", new DateTime(2025, 4, 3, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(920), false, 10, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 40, "Hi Burak, I enjoy reading, hiking and trying new foods. How about you?", new DateTime(2025, 4, 4, 0, 13, 8, 642, DateTimeKind.Utc).AddTicks(922), false, 21, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 41, "Hello Ethan, are you planning to visit Turkey anytime soon?", new DateTime(2025, 4, 4, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(924), false, 11, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 42, "Hi Ece, actually I've been considering it. Any recommendations on places to visit?", new DateTime(2025, 4, 4, 22, 13, 8, 642, DateTimeKind.Utc).AddTicks(926), false, 22, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 43, "Definitely visit Istanbul, Cappadocia and the Turkish coast. When are you thinking of coming?", new DateTime(2025, 4, 4, 23, 13, 8, 642, DateTimeKind.Utc).AddTicks(928), false, 11, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 44, "I'm looking at dates in summer. Maybe we could meet up if I visit?", new DateTime(2025, 4, 5, 0, 13, 8, 642, DateTimeKind.Utc).AddTicks(931), false, 22, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 45, "That would be nice! Let me know your travel dates when you book.", new DateTime(2025, 4, 5, 1, 13, 8, 642, DateTimeKind.Utc).AddTicks(933), false, 11, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserId", "Age", "Coin", "Email", "Fullname", "Gender", "ImageUrl", "Map" },
                values: new object[,]
                {
                    { 13, 29, 55, "ahmet@example.com", "Ahmet Yılmaz", true, "https://randomuser.me/api/portraits/men/22.jpg", "41.0082,28.9784" },
                    { 14, 25, 45, "ayse@example.com", "Ayşe Demir", false, "https://randomuser.me/api/portraits/women/23.jpg", "41.0082,28.9784" },
                    { 15, 33, 60, "mehmet@example.com", "Mehmet Kaya", true, "https://randomuser.me/api/portraits/men/24.jpg", "39.9208,32.8541" },
                    { 16, 27, 50, "zeynep@example.com", "Zeynep Çelik", false, "https://randomuser.me/api/portraits/women/25.jpg", "39.9208,32.8541" },
                    { 17, 31, 70, "mustafa@example.com", "Mustafa Şahin", true, "https://randomuser.me/api/portraits/men/26.jpg", "38.4237,27.1428" },
                    { 18, 24, 40, "elif@example.com", "Elif Yıldız", false, "https://randomuser.me/api/portraits/women/27.jpg", "38.4237,27.1428" },
                    { 19, 28, 65, "emre@example.com", "Emre Öztürk", true, "https://randomuser.me/api/portraits/men/28.jpg", "37.0000,35.3213" },
                    { 20, 26, 55, "selin@example.com", "Selin Aksoy", false, "https://randomuser.me/api/portraits/women/29.jpg", "36.8841,30.7056" },
                    { 21, 32, 75, "burak@example.com", "Burak Korkmaz", true, "https://randomuser.me/api/portraits/men/30.jpg", "40.1885,29.0610" },
                    { 22, 23, 35, "ece@example.com", "Ece Aydın", false, "https://randomuser.me/api/portraits/women/31.jpg", "41.2867,36.3300" }
                });

            migrationBuilder.InsertData(
                table: "UserSubscriptions",
                columns: new[] { "Id", "EndDate", "PlanId", "StartDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 7, new DateTime(2025, 5, 15, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(106), 1, new DateTime(2025, 3, 16, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(106), "active", 13 },
                    { 8, new DateTime(2025, 6, 4, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(109), 2, new DateTime(2025, 3, 6, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(108), "active", 15 },
                    { 9, new DateTime(2025, 5, 20, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(111), 1, new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(110), "active", 17 },
                    { 10, new DateTime(2025, 4, 30, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(121), 3, new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(113), "active", 19 },
                    { 11, new DateTime(2025, 5, 10, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(123), 2, new DateTime(2025, 3, 11, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(122), "active", 21 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 29, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1202));

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
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 21, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 28, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 2, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 24, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 29, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(754));

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

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 1, 15, 23, 9, 288, DateTimeKind.Utc).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 22, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 22, 15, 28, 9, 288, DateTimeKind.Utc).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 29, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 29, 15, 21, 9, 288, DateTimeKind.Utc).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 15, 33, 9, 288, DateTimeKind.Utc).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 15, 43, 9, 288, DateTimeKind.Utc).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 30, 15, 28, 9, 288, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(1138));

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
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 20, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(454), new DateTime(2025, 2, 19, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(453) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 5, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(457), new DateTime(2025, 2, 4, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(456) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 3, 6, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(460), new DateTime(2025, 1, 5, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(459) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 25, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(463), new DateTime(2025, 3, 26, 15, 13, 9, 288, DateTimeKind.Utc).AddTicks(462) });

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$iA7VpecC8zSWrzSnupoU8.AI/f2gXB9yPclu0BrH4x0klPPAsO0.q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$v78pekC5HWUi/PcUYu8UzeRSoTfMX7aG88FiuGuRsVtbIZ4Ms3lqS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$jt/fRQXDrQr9hHGHXoQkpu./ihRpf7KqoQHxLhhBbqKX77FpD8iES");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$ntQerq7mLCuCG0lIfEbfyuh8Hq.7Rtts.0Y.Gyxa4xjxoD1MZC5ZW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$LEXkIknXbujzsvriZlhVmu0j0iSJdfj1jDCqhlcjqgM12JbQneL8a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$xjQZ0pxe8dZ5tvK9PKDeNer0gQ9IniY.49aYVvWNk4SFt8sof0KCS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$G9VJMZboB2ioleVzpYd4UOT.dbzAeJzZHDidmPJyz9NMV2SDLOcW2");
        }
    }
}
