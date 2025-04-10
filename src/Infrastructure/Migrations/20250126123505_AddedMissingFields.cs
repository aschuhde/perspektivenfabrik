using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMissingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "WorkAmountSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "SkillSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "QuantitySpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "MaterialSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LocationSpecificationRequirementConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequirementSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DbRequirementSpecificationMaterialEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    DbRequirementSpecificationPersonEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSpecificationRequirementConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_LocationSpecificationRequirementConnections_LocationSpecifi~",
                        column: x => x.LocationSpecificationId,
                        principalTable: "LocationSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationSpecificationRequirementConnections_RequirementSpec~",
                        column: x => x.DbRequirementSpecificationMaterialEntityId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_LocationSpecificationRequirementConnections_RequirementSpe~1",
                        column: x => x.DbRequirementSpecificationPersonEntityId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_LocationSpecificationRequirementConnections_RequirementSpe~2",
                        column: x => x.RequirementSpecificationId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationSpecificationRequirementConnections_DbRequirementS~1",
                table: "LocationSpecificationRequirementConnections",
                column: "DbRequirementSpecificationPersonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSpecificationRequirementConnections_DbRequirementSp~",
                table: "LocationSpecificationRequirementConnections",
                column: "DbRequirementSpecificationMaterialEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSpecificationRequirementConnections_LocationSpecifi~",
                table: "LocationSpecificationRequirementConnections",
                column: "LocationSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSpecificationRequirementConnections_RequirementSpec~",
                table: "LocationSpecificationRequirementConnections",
                column: "RequirementSpecificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationSpecificationRequirementConnections");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "SkillSpecifications");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "QuantitySpecifications");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "MaterialSpecifications");
        }
    }
}
