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
            migrationBuilder.AddColumn<string>(
                name: "IsRead",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 9, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 6, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 8, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "BlockedUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 1, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 6, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 27, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 3, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 8, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 30, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 4, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 24, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 26, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 28, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 30, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 1, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 2, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 3, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 4, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2484));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 5, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 6, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 25, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 27, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 29, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 31, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 2, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 4, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 6, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 25,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 8, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 26,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 9, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 27,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 10, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 2, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2592), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 2, 19, 2, 7, 946, DateTimeKind.Utc).AddTicks(2595), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 7, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2598), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 7, 19, 7, 7, 946, DateTimeKind.Utc).AddTicks(2601), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2602), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 28, 19, 12, 7, 946, DateTimeKind.Utc).AddTicks(2603), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 4, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2605), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 4, 19, 5, 7, 946, DateTimeKind.Utc).AddTicks(2606), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 9, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2607), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 9, 19, 17, 7, 946, DateTimeKind.Utc).AddTicks(2608), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 31, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2610), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 31, 19, 27, 7, 946, DateTimeKind.Utc).AddTicks(2611), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 5, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2612), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 5, 19, 12, 7, 946, DateTimeKind.Utc).AddTicks(2614), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 9, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2615), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 24, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2616), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 24, 19, 17, 7, 946, DateTimeKind.Utc).AddTicks(2617), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 24, 19, 32, 7, 946, DateTimeKind.Utc).AddTicks(2619), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 26, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2620), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 26, 19, 57, 7, 946, DateTimeKind.Utc).AddTicks(2621), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2625), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2626), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 28, 19, 42, 7, 946, DateTimeKind.Utc).AddTicks(2627), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 29, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2629), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 31, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2630), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 31, 20, 57, 7, 946, DateTimeKind.Utc).AddTicks(2631), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 2, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2632), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 2, 19, 37, 7, 946, DateTimeKind.Utc).AddTicks(2634), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 25, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2635), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 25, 19, 57, 7, 946, DateTimeKind.Utc).AddTicks(2636), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2637), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 27, 21, 57, 7, 946, DateTimeKind.Utc).AddTicks(2639), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 31, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2640), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 3, 31, 20, 57, 7, 946, DateTimeKind.Utc).AddTicks(2641), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 6, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2642), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 6, 19, 27, 7, 946, DateTimeKind.Utc).AddTicks(2644), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 8, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2646), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 8, 19, 57, 7, 946, DateTimeKind.Utc).AddTicks(2648), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 9, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2649), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 9, 22, 57, 7, 946, DateTimeKind.Utc).AddTicks(2650), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 10, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2651), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 10, 20, 57, 7, 946, DateTimeKind.Utc).AddTicks(2653), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 10, 21, 57, 7, 946, DateTimeKind.Utc).AddTicks(2654), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 10, 22, 57, 7, 946, DateTimeKind.Utc).AddTicks(2655), null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "IsRead" },
                values: new object[] { new DateTime(2025, 4, 10, 23, 57, 7, 946, DateTimeKind.Utc).AddTicks(2657), null });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2372), new DateTime(2025, 3, 12, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2357) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 25, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2375), new DateTime(2025, 3, 27, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2374) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2376), new DateTime(2025, 2, 25, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2376) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 11, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2378), new DateTime(2025, 2, 10, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2378) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 3, 12, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2380), new DateTime(2025, 1, 11, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2379) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 1, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2382), new DateTime(2025, 4, 1, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2381) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 21, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2384), new DateTime(2025, 3, 22, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2383) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2385), new DateTime(2025, 3, 12, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2385) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 26, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2388), new DateTime(2025, 3, 27, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2387) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2397), new DateTime(2025, 4, 6, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2389) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 16, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2399), new DateTime(2025, 3, 17, 18, 57, 7, 946, DateTimeKind.Utc).AddTicks(2398) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$0bvoP4IgWeU7xO40tVVUO.A1oVFZl4rlCtEZnntUn1u9m1bpOAILi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$j2bVd2qBvvhFGHzHOFP85e614cOZ/vFmDE8fBBVXz7vKK10JxQOiq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$bzDVmCGVd0V3enHnrq2Hb.gf4B6ISp0.GprNVOhj450fJSCBuk3y.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$39Iml8f/.Sy22lXpxRMNbOaeJ../Dd/X3IRu61xHJawNF9xz0p0IG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$zoJGFd.3urxz0AjVmzkqEOefor0IygiJelin9Q9tc1HMtFX1kVagG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$RHhC3RNRDy7Gx2vhraEBMO3.jlyV4HgRisGtZShKQw9TEYPdCTjTC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$HfH3U78mtN3I6nUkYdUkbef/1er94Zi.1AYxAZtJpzHA3k80ernxS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$Z5ak.iUPWYjdaZ6ZKQZmquyg2Yf3rG6xTaeVZR7y45KZjkeXkN7h2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$72IieO0WyuZm3vZXGQ7yE.VxIpisyhL/ABZqaMbnyHwTw3dbTJCFS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$0cFoglIBCSVC8l08vEwS7.89s2FUSgllAQmqPw6tz9Rtg.iwKRPIG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$tV.F1O6pjMPrGm00SoRh/.IgouQKfQ3bhz2Ljt0Iq1CT9NDksjcgm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$GJorio30YmEMgvtkMu5P3e3/ex4MXoI4RNA/p4vffAJQ5OoYRYRdS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$hiOUHwKjWVzlTeShNbaS0uLV7RpEWD37Smdrx38Co3r8htbtwBK3O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$e7ZrhdxnEVtloPyKjDy0Eu0q/.6PWsy9PFbQh4WCsKc.MFy22Me0u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$vruFJZrN6CphkejXt8o4nuS9MTnNeNamsJQakwtk1XdzR4.VDEGn2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$khtK62nLNyWoVd1E7puovOU8MTPSc2sz/2cZ6vkkpz84oxTStHSn2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$DluF0mzSopoNScCa/zHAduUSLPL2/rM5r45gbOvC.fQw.IEIFjXPO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                column: "Password",
                value: "$2a$11$yB5CD.cBNUXX6VBjCGxshei6qF56VKzFQmQu.ARUA1.DGcfHDE8fG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                column: "Password",
                value: "$2a$11$YYN2tbZKcQ6U1nIJMPnox.oIHbKe5bGG.8bKJHKBYM6fjEYIpzZSW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                column: "Password",
                value: "$2a$11$ofXlNTP5FapQorm/fKnBmuhHLEs8Gwa6fl3Tm8D6o6zGSiFGIOWdW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                column: "Password",
                value: "$2a$11$qZIS8mps9Um//OVmb.i7d.Qf9NIR3UQb/PTdoD6FZALJMvMV.rbAS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                column: "Password",
                value: "$2a$11$B8k48G/yBHi2sazipEAO0OQuKrBBkmdJ.uhwDVd1YELtgdCnARode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Messages");

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
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 18, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 20, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 22, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 24, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 26, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 27, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 28, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 29, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 30, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 18,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 19, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 19,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 20,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 23, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 21,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 25, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 22,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 27, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 23,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 29, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 24,
                column: "MatchedAt",
                value: new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 25,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 2, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 26,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 3, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "MatchedUsers",
                keyColumn: "Id",
                keyValue: 27,
                column: "MatchedAt",
                value: new DateTime(2025, 4, 4, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(250));

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
                table: "Messages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 18, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 18, 20, 33, 8, 642, DateTimeKind.Utc).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 18, 20, 48, 8, 642, DateTimeKind.Utc).AddTicks(874));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 21, 13, 8, 642, DateTimeKind.Utc).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 22, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 22, 20, 58, 8, 642, DateTimeKind.Utc).AddTicks(885));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 23, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 22, 13, 8, 642, DateTimeKind.Utc).AddTicks(892));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(894));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 27, 20, 53, 8, 642, DateTimeKind.Utc).AddTicks(896));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 19, 21, 13, 8, 642, DateTimeKind.Utc).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 21, 23, 13, 8, 642, DateTimeKind.Utc).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(908));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 22, 13, 8, 642, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 31, 20, 43, 8, 642, DateTimeKind.Utc).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 2, 21, 13, 8, 642, DateTimeKind.Utc).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 3, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 0, 13, 8, 642, DateTimeKind.Utc).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 22, 13, 8, 642, DateTimeKind.Utc).AddTicks(926));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 4, 23, 13, 8, 642, DateTimeKind.Utc).AddTicks(928));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 0, 13, 8, 642, DateTimeKind.Utc).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 5, 1, 13, 8, 642, DateTimeKind.Utc).AddTicks(933));

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
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 15, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(106), new DateTime(2025, 3, 16, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(106) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 4, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(109), new DateTime(2025, 3, 6, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(108) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 20, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(111), new DateTime(2025, 3, 21, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 30, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(121), new DateTime(2025, 3, 31, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(113) });

            migrationBuilder.UpdateData(
                table: "UserSubscriptions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 10, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(123), new DateTime(2025, 3, 11, 20, 13, 8, 642, DateTimeKind.Utc).AddTicks(122) });

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$NWfKi9.Pcp213EDeTyNEYeZe4ZPA9N9ar68EHd.nnq1DBchPZh31y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$F/aXGiOggf4laDOBHEie1.r3G/06IZI6lyZKrP8NJT.XEpyqHXPUW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$oAFjjmS9WQ0iTe.lTibAvufeew748MhnuBZ0CiY1v8J6B4cJM/PnC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$cJNobZskGHPlBrzGuCkqOOIn9ZjOxrj1SzO9INpXM6gG/PTNZgNq2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$VkGwPZbNb2eFwVD0AMpi5OPw5zrtQXCDbSt1xkXYSH9W9U23Ing8W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                column: "Password",
                value: "$2a$11$D/DdDxpQozK31EYFOV9.1elwHvR/MAIZFSIzzN4530Ej.NTrfmNV.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                column: "Password",
                value: "$2a$11$ixzJRiFZv5lxDRuxVN4PX.B2TwLC3BnRzVpz.myxkoguaI/Bccx6O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                column: "Password",
                value: "$2a$11$Qgz1/TSDBzcabC08WOLaluHYpEu3zE3NdKn2S8BkrqO04BUKFP1PS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                column: "Password",
                value: "$2a$11$.P2x1ESKn.5Zh3zzBcQ7IupNonN/sFQsGTNeVn/V4jMNba/sXncvi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                column: "Password",
                value: "$2a$11$iP24qvjLN0NzxwC0lBnnSOKhUTtaEFEOXTiNhIcaJkQBwlpv0tE0q");
        }
    }
}
