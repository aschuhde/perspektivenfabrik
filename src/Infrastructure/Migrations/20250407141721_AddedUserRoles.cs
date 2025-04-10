using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_UserRoles_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_UserRoles_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreatedBy_PersonId",
                table: "UserRoles",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_History_HistoryId",
                table: "UserRoles",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_LastModifiedBy_PersonId",
                table: "UserRoles",
                column: "LastModifiedBy_PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
