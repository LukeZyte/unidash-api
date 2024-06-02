using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniDash.API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FriendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_Friendships_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friendships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("1873d190-f08b-410e-a9a9-510a9e598cf6"), "biretta", "Exam" },
                    { new Guid("6259683a-adf4-41f2-b71f-dc311156b3b6"), "board", "Presentation" },
                    { new Guid("d860e623-9350-49b9-9c04-573f6beff8df"), "book", "Test" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Login", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("34355ad1-fe6e-4e96-bfbe-73664978feb5"), new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(567), "krzysztof@wp.pl", "krzysztof", "Krzysztof", "Krzysztof" },
                    { new Guid("71c7ee1f-3866-47c8-a55e-19ccdb7827d2"), new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(565), "bartek@wp.pl", "bartek", "Bartek", "Bartek" },
                    { new Guid("79ba5203-7080-4998-85d5-9cfed69b69ba"), new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(562), "daniel@wp.pl", "daniel", "Daniel", "Daniel" },
                    { new Guid("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9"), new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(564), "lukasz@wp.pl", "lukasz", "Lukasz", "Lukasz" },
                    { new Guid("de99be5f-0a4b-4da5-a74b-b9c10c3cef20"), new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(551), "lukjpl@wp.pl", "test", "Test", "Test" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Color", "Date", "Description", "EventTypeId", "IsPublic", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("6622a31b-7c5d-403a-99b7-c59e643535ba"), "yellow", new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(680), null, new Guid("d860e623-9350-49b9-9c04-573f6beff8df"), true, "Łatwy kolos", new Guid("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9") },
                    { new Guid("7d32a906-40a3-4faf-bdab-30a777c028fe"), "green", new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(677), null, new Guid("1873d190-f08b-410e-a9a9-510a9e598cf6"), true, "Łatwy egzamin", new Guid("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9") },
                    { new Guid("e9880e9b-ffc5-448c-bc97-cc00d6c95601"), "red", new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(672), null, new Guid("1873d190-f08b-410e-a9a9-510a9e598cf6"), true, "Trudny egzamin", new Guid("79ba5203-7080-4998-85d5-9cfed69b69ba") }
                });

            migrationBuilder.InsertData(
                table: "Friendships",
                columns: new[] { "FriendId", "UserId", "CreatedAt", "IsAccepted" },
                values: new object[,]
                {
                    { new Guid("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9"), new Guid("71c7ee1f-3866-47c8-a55e-19ccdb7827d2"), new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(654), true },
                    { new Guid("71c7ee1f-3866-47c8-a55e-19ccdb7827d2"), new Guid("79ba5203-7080-4998-85d5-9cfed69b69ba"), new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(652), true },
                    { new Guid("ccbe10aa-0082-4f5e-9c87-4eaaa0d448c9"), new Guid("79ba5203-7080-4998-85d5-9cfed69b69ba"), new DateTime(2024, 6, 1, 14, 40, 52, 934, DateTimeKind.Utc).AddTicks(647), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendId",
                table: "Friendships",
                column: "FriendId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
