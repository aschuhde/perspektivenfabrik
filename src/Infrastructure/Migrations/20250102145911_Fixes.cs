using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "TimeSpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "SkillSpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "RequirementSpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "QuantitySpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProjectTags");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedBy_DbPersonEntityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_DbPersonEntityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "GraphicsSpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "DescriptionTypes");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "DescriptionSpecifications");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ContactSpecifications");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Persons",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.CreateTable(
                name: "HistoryItems",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    HistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Message = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: true),
                    HistoryEntryType = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryItems", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_HistoryItems_Histories_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryItems_HistoryId",
                table: "HistoryItems",
                column: "HistoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryItems");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "WorkAmountSpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TimeSpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "SkillSpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "RequirementSpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "QuantitySpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ProjectTags",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Persons",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_DbPersonEntityId",
                table: "Persons",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_DbPersonEntityId",
                table: "Persons",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Organizations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "OrganizationPositionConnections",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "MaterialSpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "LocationSpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "GraphicsSpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "DescriptionTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "DescriptionSpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ContactSpecifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
