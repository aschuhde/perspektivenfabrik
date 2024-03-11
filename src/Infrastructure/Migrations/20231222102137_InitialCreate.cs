using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessPolicies",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityIndex = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPolicies", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EntityIndex = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    AccessPolicyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_User_AccessPolicies_AccessPolicyId",
                        column: x => x.AccessPolicyId,
                        principalTable: "AccessPolicies",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_User_CreatedByEntityId",
                        column: x => x.CreatedByEntityId,
                        principalTable: "User",
                        principalColumn: "EntityId");
                });

            migrationBuilder.CreateTable(
                name: "UserAccesses",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessPolicyId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionKey = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    EntityIndex = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccesses", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_UserAccesses_AccessPolicies_AccessPolicyId",
                        column: x => x.AccessPolicyId,
                        principalTable: "AccessPolicies",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccesses_User_CreatedByEntityId",
                        column: x => x.CreatedByEntityId,
                        principalTable: "User",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_UserAccesses_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_AccessPolicyId",
                table: "User",
                column: "AccessPolicyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedByEntityId",
                table: "User",
                column: "CreatedByEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_AccessPolicyId",
                table: "UserAccesses",
                column: "AccessPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_CreatedByEntityId",
                table: "UserAccesses",
                column: "CreatedByEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_UserId",
                table: "UserAccesses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccesses");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AccessPolicies");
        }
    }
}
