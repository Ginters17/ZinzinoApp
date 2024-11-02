using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Date", "EmailAddress", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 2, 17, 44, 53, 343, DateTimeKind.Local).AddTicks(9639), "ginters@example.com", "P@ssword1", "ginters" },
                    { 2, new DateTime(2024, 11, 2, 17, 44, 53, 343, DateTimeKind.Local).AddTicks(9683), "janis@example.com", "P@ssword1", "janis" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Date", "State", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Saules iela 10", null, "Sigulda", new DateTime(2024, 11, 2, 17, 44, 53, 343, DateTimeKind.Local).AddTicks(9756), "Latvia", 1, "LV-2158" },
                    { 2, "Mēness iela 2", null, "Cēsis", new DateTime(2024, 11, 2, 17, 44, 53, 343, DateTimeKind.Local).AddTicks(9762), "Latvia", 2, "LV-4101" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
