using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSpecificationClassesToEntitiesWithoutMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactSpecifications_Histories_History_HistoryId",
                table: "ContactSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactSpecifications_Persons_CreatedBy_PersonId",
                table: "ContactSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactSpecifications_Persons_LastModifiedBy_PersonId",
                table: "ContactSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionSpecifications_Histories_History_HistoryId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionSpecifications_Persons_CreatedBy_PersonId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionSpecifications_Persons_LastModifiedBy_PersonId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionTypes_Histories_History_HistoryId",
                table: "DescriptionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionTypes_Persons_CreatedBy_PersonId",
                table: "DescriptionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionTypes_Persons_LastModifiedBy_PersonId",
                table: "DescriptionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_GraphicsSpecifications_Histories_History_HistoryId",
                table: "GraphicsSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_GraphicsSpecifications_Persons_CreatedBy_PersonId",
                table: "GraphicsSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_GraphicsSpecifications_Persons_LastModifiedBy_PersonId",
                table: "GraphicsSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecifications_Histories_History_HistoryId",
                table: "LocationSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecifications_Persons_CreatedBy_PersonId",
                table: "LocationSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecifications_Persons_LastModifiedBy_PersonId",
                table: "LocationSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecifications_Histories_History_HistoryId",
                table: "MaterialSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecifications_Persons_CreatedBy_PersonId",
                table: "MaterialSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecifications_Persons_LastModifiedBy_PersonId",
                table: "MaterialSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPositionConnections_Histories_History_HistoryId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPositionConnections_Persons_CreatedBy_PersonId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPositionConnections_Persons_LastModifiedBy_Pers~",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTags_Histories_History_HistoryId",
                table: "ProjectTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTags_Persons_CreatedBy_PersonId",
                table: "ProjectTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTags_Persons_LastModifiedBy_PersonId",
                table: "ProjectTags");

            migrationBuilder.DropForeignKey(
                name: "FK_QuantitySpecifications_Histories_History_HistoryId",
                table: "QuantitySpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_QuantitySpecifications_Persons_CreatedBy_PersonId",
                table: "QuantitySpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_QuantitySpecifications_Persons_LastModifiedBy_PersonId",
                table: "QuantitySpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementSpecifications_Histories_History_HistoryId",
                table: "RequirementSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementSpecifications_Persons_CreatedBy_PersonId",
                table: "RequirementSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementSpecifications_Persons_LastModifiedBy_PersonId",
                table: "RequirementSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSpecifications_Histories_History_HistoryId",
                table: "SkillSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSpecifications_Persons_CreatedBy_PersonId",
                table: "SkillSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSpecifications_Persons_LastModifiedBy_PersonId",
                table: "SkillSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecifications_Histories_History_HistoryId",
                table: "TimeSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecifications_Persons_CreatedBy_PersonId",
                table: "TimeSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecifications_Persons_LastModifiedBy_PersonId",
                table: "TimeSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecifications_Histories_History_HistoryId",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecifications_Persons_CreatedBy_PersonId",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecifications_Persons_LastModifiedBy_PersonId",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_WorkAmountSpecifications_CreatedBy_PersonId",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_WorkAmountSpecifications_History_HistoryId",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_WorkAmountSpecifications_LastModifiedBy_PersonId",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_TimeSpecifications_CreatedBy_PersonId",
                table: "TimeSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_TimeSpecifications_History_HistoryId",
                table: "TimeSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_TimeSpecifications_LastModifiedBy_PersonId",
                table: "TimeSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_SkillSpecifications_CreatedBy_PersonId",
                table: "SkillSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_SkillSpecifications_History_HistoryId",
                table: "SkillSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_SkillSpecifications_LastModifiedBy_PersonId",
                table: "SkillSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_RequirementSpecifications_CreatedBy_PersonId",
                table: "RequirementSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_RequirementSpecifications_History_HistoryId",
                table: "RequirementSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_RequirementSpecifications_LastModifiedBy_PersonId",
                table: "RequirementSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_QuantitySpecifications_CreatedBy_PersonId",
                table: "QuantitySpecifications");

            migrationBuilder.DropIndex(
                name: "IX_QuantitySpecifications_History_HistoryId",
                table: "QuantitySpecifications");

            migrationBuilder.DropIndex(
                name: "IX_QuantitySpecifications_LastModifiedBy_PersonId",
                table: "QuantitySpecifications");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTags_CreatedBy_PersonId",
                table: "ProjectTags");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTags_History_HistoryId",
                table: "ProjectTags");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTags_LastModifiedBy_PersonId",
                table: "ProjectTags");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationPositionConnections_CreatedBy_PersonId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationPositionConnections_History_HistoryId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationPositionConnections_LastModifiedBy_PersonId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropIndex(
                name: "IX_MaterialSpecifications_CreatedBy_PersonId",
                table: "MaterialSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_MaterialSpecifications_History_HistoryId",
                table: "MaterialSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_MaterialSpecifications_LastModifiedBy_PersonId",
                table: "MaterialSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_LocationSpecifications_CreatedBy_PersonId",
                table: "LocationSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_LocationSpecifications_History_HistoryId",
                table: "LocationSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_LocationSpecifications_LastModifiedBy_PersonId",
                table: "LocationSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_GraphicsSpecifications_CreatedBy_PersonId",
                table: "GraphicsSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_GraphicsSpecifications_History_HistoryId",
                table: "GraphicsSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_GraphicsSpecifications_LastModifiedBy_PersonId",
                table: "GraphicsSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_DescriptionTypes_CreatedBy_PersonId",
                table: "DescriptionTypes");

            migrationBuilder.DropIndex(
                name: "IX_DescriptionTypes_History_HistoryId",
                table: "DescriptionTypes");

            migrationBuilder.DropIndex(
                name: "IX_DescriptionTypes_LastModifiedBy_PersonId",
                table: "DescriptionTypes");

            migrationBuilder.DropIndex(
                name: "IX_DescriptionSpecifications_CreatedBy_PersonId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_DescriptionSpecifications_History_HistoryId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_DescriptionSpecifications_LastModifiedBy_PersonId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_ContactSpecifications_CreatedBy_PersonId",
                table: "ContactSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_ContactSpecifications_History_HistoryId",
                table: "ContactSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_ContactSpecifications_LastModifiedBy_PersonId",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "WorkAmountSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "TimeSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TimeSpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "TimeSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "TimeSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "TimeSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "SkillSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SkillSpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "SkillSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "SkillSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "SkillSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "RequirementSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RequirementSpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "RequirementSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "RequirementSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "RequirementSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "QuantitySpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "QuantitySpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "QuantitySpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "QuantitySpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "QuantitySpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "ProjectTags");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ProjectTags");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "ProjectTags");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "ProjectTags");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "ProjectTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "GraphicsSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "GraphicsSpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "GraphicsSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "GraphicsSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "GraphicsSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "DescriptionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DescriptionTypes");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "DescriptionTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "DescriptionTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "DescriptionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DescriptionSpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "DescriptionSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy_PersonId",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "History_HistoryId",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy_PersonId",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "ContactSpecifications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "WorkAmountSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "WorkAmountSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "WorkAmountSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "WorkAmountSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "WorkAmountSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "TimeSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "TimeSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "TimeSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "TimeSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "TimeSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "SkillSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "SkillSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "SkillSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "SkillSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "SkillSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "RequirementSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "RequirementSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "RequirementSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "RequirementSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "RequirementSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "QuantitySpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "QuantitySpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "QuantitySpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "QuantitySpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "QuantitySpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "ProjectTags",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "ProjectTags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "ProjectTags",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "ProjectTags",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "ProjectTags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "OrganizationPositionConnections",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "OrganizationPositionConnections",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "OrganizationPositionConnections",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "OrganizationPositionConnections",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "OrganizationPositionConnections",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "MaterialSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "MaterialSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "MaterialSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "MaterialSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "MaterialSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "LocationSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "LocationSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "LocationSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "LocationSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "LocationSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "GraphicsSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "GraphicsSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "GraphicsSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "GraphicsSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "GraphicsSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "DescriptionTypes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "DescriptionTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "DescriptionTypes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "DescriptionTypes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "DescriptionTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "DescriptionSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "DescriptionSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "DescriptionSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "DescriptionSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "DescriptionSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_PersonId",
                table: "ContactSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "ContactSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "History_HistoryId",
                table: "ContactSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy_PersonId",
                table: "ContactSpecifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "ContactSpecifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_WorkAmountSpecifications_CreatedBy_PersonId",
                table: "WorkAmountSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAmountSpecifications_History_HistoryId",
                table: "WorkAmountSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAmountSpecifications_LastModifiedBy_PersonId",
                table: "WorkAmountSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecifications_CreatedBy_PersonId",
                table: "TimeSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecifications_History_HistoryId",
                table: "TimeSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecifications_LastModifiedBy_PersonId",
                table: "TimeSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSpecifications_CreatedBy_PersonId",
                table: "SkillSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSpecifications_History_HistoryId",
                table: "SkillSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSpecifications_LastModifiedBy_PersonId",
                table: "SkillSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementSpecifications_CreatedBy_PersonId",
                table: "RequirementSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementSpecifications_History_HistoryId",
                table: "RequirementSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementSpecifications_LastModifiedBy_PersonId",
                table: "RequirementSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantitySpecifications_CreatedBy_PersonId",
                table: "QuantitySpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantitySpecifications_History_HistoryId",
                table: "QuantitySpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantitySpecifications_LastModifiedBy_PersonId",
                table: "QuantitySpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_CreatedBy_PersonId",
                table: "ProjectTags",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_History_HistoryId",
                table: "ProjectTags",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_LastModifiedBy_PersonId",
                table: "ProjectTags",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionConnections_CreatedBy_PersonId",
                table: "OrganizationPositionConnections",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionConnections_History_HistoryId",
                table: "OrganizationPositionConnections",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionConnections_LastModifiedBy_PersonId",
                table: "OrganizationPositionConnections",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSpecifications_CreatedBy_PersonId",
                table: "MaterialSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSpecifications_History_HistoryId",
                table: "MaterialSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSpecifications_LastModifiedBy_PersonId",
                table: "MaterialSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSpecifications_CreatedBy_PersonId",
                table: "LocationSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSpecifications_History_HistoryId",
                table: "LocationSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSpecifications_LastModifiedBy_PersonId",
                table: "LocationSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphicsSpecifications_CreatedBy_PersonId",
                table: "GraphicsSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphicsSpecifications_History_HistoryId",
                table: "GraphicsSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphicsSpecifications_LastModifiedBy_PersonId",
                table: "GraphicsSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionTypes_CreatedBy_PersonId",
                table: "DescriptionTypes",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionTypes_History_HistoryId",
                table: "DescriptionTypes",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionTypes_LastModifiedBy_PersonId",
                table: "DescriptionTypes",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionSpecifications_CreatedBy_PersonId",
                table: "DescriptionSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionSpecifications_History_HistoryId",
                table: "DescriptionSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionSpecifications_LastModifiedBy_PersonId",
                table: "DescriptionSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactSpecifications_CreatedBy_PersonId",
                table: "ContactSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactSpecifications_History_HistoryId",
                table: "ContactSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactSpecifications_LastModifiedBy_PersonId",
                table: "ContactSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSpecifications_Histories_History_HistoryId",
                table: "ContactSpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSpecifications_Persons_CreatedBy_PersonId",
                table: "ContactSpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSpecifications_Persons_LastModifiedBy_PersonId",
                table: "ContactSpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionSpecifications_Histories_History_HistoryId",
                table: "DescriptionSpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionSpecifications_Persons_CreatedBy_PersonId",
                table: "DescriptionSpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionSpecifications_Persons_LastModifiedBy_PersonId",
                table: "DescriptionSpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionTypes_Histories_History_HistoryId",
                table: "DescriptionTypes",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionTypes_Persons_CreatedBy_PersonId",
                table: "DescriptionTypes",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionTypes_Persons_LastModifiedBy_PersonId",
                table: "DescriptionTypes",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GraphicsSpecifications_Histories_History_HistoryId",
                table: "GraphicsSpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_GraphicsSpecifications_Persons_CreatedBy_PersonId",
                table: "GraphicsSpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GraphicsSpecifications_Persons_LastModifiedBy_PersonId",
                table: "GraphicsSpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecifications_Histories_History_HistoryId",
                table: "LocationSpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecifications_Persons_CreatedBy_PersonId",
                table: "LocationSpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecifications_Persons_LastModifiedBy_PersonId",
                table: "LocationSpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecifications_Histories_History_HistoryId",
                table: "MaterialSpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecifications_Persons_CreatedBy_PersonId",
                table: "MaterialSpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecifications_Persons_LastModifiedBy_PersonId",
                table: "MaterialSpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPositionConnections_Histories_History_HistoryId",
                table: "OrganizationPositionConnections",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPositionConnections_Persons_CreatedBy_PersonId",
                table: "OrganizationPositionConnections",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPositionConnections_Persons_LastModifiedBy_Pers~",
                table: "OrganizationPositionConnections",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTags_Histories_History_HistoryId",
                table: "ProjectTags",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTags_Persons_CreatedBy_PersonId",
                table: "ProjectTags",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTags_Persons_LastModifiedBy_PersonId",
                table: "ProjectTags",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuantitySpecifications_Histories_History_HistoryId",
                table: "QuantitySpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuantitySpecifications_Persons_CreatedBy_PersonId",
                table: "QuantitySpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuantitySpecifications_Persons_LastModifiedBy_PersonId",
                table: "QuantitySpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementSpecifications_Histories_History_HistoryId",
                table: "RequirementSpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementSpecifications_Persons_CreatedBy_PersonId",
                table: "RequirementSpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementSpecifications_Persons_LastModifiedBy_PersonId",
                table: "RequirementSpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSpecifications_Histories_History_HistoryId",
                table: "SkillSpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSpecifications_Persons_CreatedBy_PersonId",
                table: "SkillSpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSpecifications_Persons_LastModifiedBy_PersonId",
                table: "SkillSpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecifications_Histories_History_HistoryId",
                table: "TimeSpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecifications_Persons_CreatedBy_PersonId",
                table: "TimeSpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecifications_Persons_LastModifiedBy_PersonId",
                table: "TimeSpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecifications_Histories_History_HistoryId",
                table: "WorkAmountSpecifications",
                column: "History_HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecifications_Persons_CreatedBy_PersonId",
                table: "WorkAmountSpecifications",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecifications_Persons_LastModifiedBy_PersonId",
                table: "WorkAmountSpecifications",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
