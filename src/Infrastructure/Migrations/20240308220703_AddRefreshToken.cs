using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbUserRefreshTokens",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefreshToken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AbsoluteExpirationUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EntityIndex = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserRefreshTokens", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_DbUserRefreshTokens_User_CreatedByEntityId",
                        column: x => x.CreatedByEntityId,
                        principalTable: "User",
                        principalColumn: "EntityId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbUserRefreshTokens_CreatedByEntityId",
                table: "DbUserRefreshTokens",
                column: "CreatedByEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbUserRefreshTokens");
        }
    }
}
