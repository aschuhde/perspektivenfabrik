using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DroppedMaterialSpecificationsForMoneyRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~1",
                table: "MaterialSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~2",
                table: "MaterialSpecificationRequirementConnections");

            migrationBuilder.DropIndex(
                name: "IX_MaterialSpecificationRequirementConnections_DbRequirementS~1",
                table: "MaterialSpecificationRequirementConnections");

            migrationBuilder.DropColumn(
                name: "DbRequirementSpecificationMoneyEntityId",
                table: "MaterialSpecificationRequirementConnections");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~1",
                table: "MaterialSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~1",
                table: "MaterialSpecificationRequirementConnections");

            migrationBuilder.AddColumn<Guid>(
                name: "DbRequirementSpecificationMoneyEntityId",
                table: "MaterialSpecificationRequirementConnections",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSpecificationRequirementConnections_DbRequirementS~1",
                table: "MaterialSpecificationRequirementConnections",
                column: "DbRequirementSpecificationMoneyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~1",
                table: "MaterialSpecificationRequirementConnections",
                column: "DbRequirementSpecificationMoneyEntityId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~2",
                table: "MaterialSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
