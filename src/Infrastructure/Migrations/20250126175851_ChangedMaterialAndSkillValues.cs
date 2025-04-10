using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMaterialAndSkillValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementS~1",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.DropIndex(
                name: "IX_WorkAmountSpecificationRequirementConnections_DbRequirement~",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.DropColumn(
                name: "DbRequirementSpecificationPersonEntityId",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "SkillSpecifications",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Title_RawContentString",
                table: "SkillSpecifications",
                type: "character varying(50000)",
                maxLength: 50000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkAmountSpecificationEntityId",
                table: "RequirementSpecifications",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequirementSpecifications_WorkAmountSpecificationRequiremen~",
                table: "RequirementSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.DropIndex(
                name: "IX_RequirementSpecifications_WorkAmountSpecificationEntityId",
                table: "RequirementSpecifications");

            migrationBuilder.DropColumn(
                name: "Title_RawContentString",
                table: "SkillSpecifications");

            migrationBuilder.DropColumn(
                name: "WorkAmountSpecificationEntityId",
                table: "RequirementSpecifications");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SkillSpecifications",
                newName: "Value");

            migrationBuilder.AddColumn<Guid>(
                name: "DbRequirementSpecificationPersonEntityId",
                table: "WorkAmountSpecificationRequirementConnections",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkAmountSpecificationRequirementConnections_DbRequirement~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "DbRequirementSpecificationPersonEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "DbRequirementSpecificationPersonEntityId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementS~1",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
