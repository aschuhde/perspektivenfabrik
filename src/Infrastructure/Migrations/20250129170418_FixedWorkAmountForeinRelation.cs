using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedWorkAmountForeinRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequirementSpecifications_WorkAmountSpecificationRequiremen~",
                table: "RequirementSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.DropIndex(
                name: "IX_RequirementSpecifications_WorkAmountSpecificationEntityId",
                table: "RequirementSpecifications");

            migrationBuilder.DropColumn(
                name: "WorkAmountSpecificationEntityId",
                table: "RequirementSpecifications");

            migrationBuilder.RenameColumn(
                name: "RequirementSpecificationId",
                table: "WorkAmountSpecificationRequirementConnections",
                newName: "RequirementSpecificationPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "RequirementSpecificationPersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.RenameColumn(
                name: "RequirementSpecificationPersonId",
                table: "WorkAmountSpecificationRequirementConnections",
                newName: "RequirementSpecificationId");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkAmountSpecificationEntityId",
                table: "RequirementSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "RequirementSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementSpecifications_WorkAmountSpecificationEntityId",
                table: "RequirementSpecifications",
                column: "WorkAmountSpecificationEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementSpecifications_WorkAmountSpecificationRequiremen~",
                table: "RequirementSpecifications",
                column: "WorkAmountSpecificationEntityId",
                principalTable: "WorkAmountSpecificationRequirementConnections",
                principalColumn: "EntityId");
        }
    }
}
