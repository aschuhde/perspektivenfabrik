using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PersonLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Persons",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredLanguageCode",
                table: "Persons",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Otp",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Otp = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AbsoluteExpirationUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RequestedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otp", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TaskType = table.Column<int>(type: "integer", nullable: false),
                    TaskStatus = table.Column<int>(type: "integer", nullable: false),
                    TaskData = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.EntityId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Otp");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PreferredLanguageCode",
                table: "Persons");
        }
    }
}
