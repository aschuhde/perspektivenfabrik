using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteNoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactSpecificationConnections_ContactSpecifications_Conta~",
                table: "ContactSpecificationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactSpecificationConnections_Projects_ProjectId",
                table: "ContactSpecificationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionSpecificationProjectConnections_DescriptionSpeci~",
                table: "DescriptionSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionSpecificationProjectConnections_Projects_Project~",
                table: "DescriptionSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionSpecifications_DescriptionTypes_TypeEntityId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_GraphicsSpecificationProjectConnections_GraphicsSpecificati~",
                table: "GraphicsSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_GraphicsSpecificationProjectConnections_Projects_ProjectId",
                table: "GraphicsSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryItems_Histories_HistoryId",
                table: "HistoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecificationProjectConnections_LocationSpecificati~",
                table: "LocationSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecificationProjectConnections_Projects_ProjectId",
                table: "LocationSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecificationRequirementConnections_LocationSpecifi~",
                table: "LocationSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecificationRequirementConnections_RequirementSpe~2",
                table: "LocationSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_MaterialSpecifi~",
                table: "MaterialSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~1",
                table: "MaterialSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationConnections_Organizations_OrganizationId",
                table: "OrganizationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPositionConnections_Organizations_OrganizationId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationProjectConnections_Organizations_OrganizationId",
                table: "OrganizationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationProjectConnections_Projects_ProjectId",
                table: "OrganizationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProjectContributorConnections_Persons_PersonId",
                table: "PersonProjectContributorConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProjectContributorConnections_Projects_ProjectId",
                table: "PersonProjectContributorConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProjectOwnerConnections_Persons_PersonId",
                table: "PersonProjectOwnerConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProjectOwnerConnections_Projects_ProjectId",
                table: "PersonProjectOwnerConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectConnections_Projects_ProjectId",
                table: "ProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectConnections_Projects_RelatedProjectId",
                table: "ProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTagConnections_ProjectTags_ProjectTagId",
                table: "ProjectTagConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTagConnections_Projects_ProjectId",
                table: "ProjectTagConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_QuantitySpecificationRequirementConnections_QuantitySpecifi~",
                table: "QuantitySpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_QuantitySpecificationRequirementConnections_RequirementSpec~",
                table: "QuantitySpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementSpecificationConnections_Projects_ProjectId",
                table: "RequirementSpecificationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementSpecificationConnections_RequirementSpecificatio~",
                table: "RequirementSpecificationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSpecificationRequirementConnections_RequirementSpecif~1",
                table: "SkillSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSpecificationRequirementConnections_SkillSpecification~",
                table: "SkillSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecificationProjectConnections_Projects_ProjectId",
                table: "TimeSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecificationProjectConnections_TimeSpecifications_Time~",
                table: "TimeSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecificationRequirementConnections_RequirementSpecific~",
                table: "TimeSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecificationRequirementConnections_TimeSpecifications_~",
                table: "TimeSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecifications_TimeSpecifications_End_MomentId",
                table: "TimeSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecifications_TimeSpecifications_Start_MomentId",
                table: "TimeSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_WorkAmountSpe~",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSpecificationConnections_ContactSpecifications_Conta~",
                table: "ContactSpecificationConnections",
                column: "ContactSpecificationId",
                principalTable: "ContactSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSpecificationConnections_Projects_ProjectId",
                table: "ContactSpecificationConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionSpecificationProjectConnections_DescriptionSpeci~",
                table: "DescriptionSpecificationProjectConnections",
                column: "DescriptionSpecificationId",
                principalTable: "DescriptionSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionSpecificationProjectConnections_Projects_Project~",
                table: "DescriptionSpecificationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionSpecifications_DescriptionTypes_TypeEntityId",
                table: "DescriptionSpecifications",
                column: "TypeEntityId",
                principalTable: "DescriptionTypes",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_GraphicsSpecificationProjectConnections_GraphicsSpecificati~",
                table: "GraphicsSpecificationProjectConnections",
                column: "GraphicsSpecificationId",
                principalTable: "GraphicsSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_GraphicsSpecificationProjectConnections_Projects_ProjectId",
                table: "GraphicsSpecificationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryItems_Histories_HistoryId",
                table: "HistoryItems",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecificationProjectConnections_LocationSpecificati~",
                table: "LocationSpecificationProjectConnections",
                column: "LocationSpecificationId",
                principalTable: "LocationSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecificationProjectConnections_Projects_ProjectId",
                table: "LocationSpecificationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecificationRequirementConnections_LocationSpecifi~",
                table: "LocationSpecificationRequirementConnections",
                column: "LocationSpecificationId",
                principalTable: "LocationSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecificationRequirementConnections_RequirementSpe~2",
                table: "LocationSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_MaterialSpecifi~",
                table: "MaterialSpecificationRequirementConnections",
                column: "MaterialSpecificationId",
                principalTable: "MaterialSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~1",
                table: "MaterialSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationConnections_Organizations_OrganizationId",
                table: "OrganizationConnections",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPositionConnections_Organizations_OrganizationId",
                table: "OrganizationPositionConnections",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationProjectConnections_Organizations_OrganizationId",
                table: "OrganizationProjectConnections",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationProjectConnections_Projects_ProjectId",
                table: "OrganizationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProjectContributorConnections_Persons_PersonId",
                table: "PersonProjectContributorConnections",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProjectContributorConnections_Projects_ProjectId",
                table: "PersonProjectContributorConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProjectOwnerConnections_Persons_PersonId",
                table: "PersonProjectOwnerConnections",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProjectOwnerConnections_Projects_ProjectId",
                table: "PersonProjectOwnerConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectConnections_Projects_ProjectId",
                table: "ProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectConnections_Projects_RelatedProjectId",
                table: "ProjectConnections",
                column: "RelatedProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTagConnections_ProjectTags_ProjectTagId",
                table: "ProjectTagConnections",
                column: "ProjectTagId",
                principalTable: "ProjectTags",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTagConnections_Projects_ProjectId",
                table: "ProjectTagConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuantitySpecificationRequirementConnections_QuantitySpecifi~",
                table: "QuantitySpecificationRequirementConnections",
                column: "QuantitySpecificationId",
                principalTable: "QuantitySpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuantitySpecificationRequirementConnections_RequirementSpec~",
                table: "QuantitySpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementSpecificationConnections_Projects_ProjectId",
                table: "RequirementSpecificationConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementSpecificationConnections_RequirementSpecificatio~",
                table: "RequirementSpecificationConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSpecificationRequirementConnections_RequirementSpecif~1",
                table: "SkillSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSpecificationRequirementConnections_SkillSpecification~",
                table: "SkillSpecificationRequirementConnections",
                column: "SkillSpecificationId",
                principalTable: "SkillSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecificationProjectConnections_Projects_ProjectId",
                table: "TimeSpecificationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecificationProjectConnections_TimeSpecifications_Time~",
                table: "TimeSpecificationProjectConnections",
                column: "TimeSpecificationId",
                principalTable: "TimeSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecificationRequirementConnections_RequirementSpecific~",
                table: "TimeSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecificationRequirementConnections_TimeSpecifications_~",
                table: "TimeSpecificationRequirementConnections",
                column: "TimeSpecificationId",
                principalTable: "TimeSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecifications_TimeSpecifications_End_MomentId",
                table: "TimeSpecifications",
                column: "End_MomentId",
                principalTable: "TimeSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecifications_TimeSpecifications_Start_MomentId",
                table: "TimeSpecifications",
                column: "Start_MomentId",
                principalTable: "TimeSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "RequirementSpecificationPersonId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_WorkAmountSpe~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "WorkAmountSpecificationId",
                principalTable: "WorkAmountSpecifications",
                principalColumn: "EntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactSpecificationConnections_ContactSpecifications_Conta~",
                table: "ContactSpecificationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactSpecificationConnections_Projects_ProjectId",
                table: "ContactSpecificationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionSpecificationProjectConnections_DescriptionSpeci~",
                table: "DescriptionSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionSpecificationProjectConnections_Projects_Project~",
                table: "DescriptionSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionSpecifications_DescriptionTypes_TypeEntityId",
                table: "DescriptionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_GraphicsSpecificationProjectConnections_GraphicsSpecificati~",
                table: "GraphicsSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_GraphicsSpecificationProjectConnections_Projects_ProjectId",
                table: "GraphicsSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryItems_Histories_HistoryId",
                table: "HistoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecificationProjectConnections_LocationSpecificati~",
                table: "LocationSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecificationProjectConnections_Projects_ProjectId",
                table: "LocationSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecificationRequirementConnections_LocationSpecifi~",
                table: "LocationSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationSpecificationRequirementConnections_RequirementSpe~2",
                table: "LocationSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_MaterialSpecifi~",
                table: "MaterialSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~1",
                table: "MaterialSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationConnections_Organizations_OrganizationId",
                table: "OrganizationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPositionConnections_Organizations_OrganizationId",
                table: "OrganizationPositionConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationProjectConnections_Organizations_OrganizationId",
                table: "OrganizationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationProjectConnections_Projects_ProjectId",
                table: "OrganizationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProjectContributorConnections_Persons_PersonId",
                table: "PersonProjectContributorConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProjectContributorConnections_Projects_ProjectId",
                table: "PersonProjectContributorConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProjectOwnerConnections_Persons_PersonId",
                table: "PersonProjectOwnerConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProjectOwnerConnections_Projects_ProjectId",
                table: "PersonProjectOwnerConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectConnections_Projects_ProjectId",
                table: "ProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectConnections_Projects_RelatedProjectId",
                table: "ProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTagConnections_ProjectTags_ProjectTagId",
                table: "ProjectTagConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTagConnections_Projects_ProjectId",
                table: "ProjectTagConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_QuantitySpecificationRequirementConnections_QuantitySpecifi~",
                table: "QuantitySpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_QuantitySpecificationRequirementConnections_RequirementSpec~",
                table: "QuantitySpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementSpecificationConnections_Projects_ProjectId",
                table: "RequirementSpecificationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementSpecificationConnections_RequirementSpecificatio~",
                table: "RequirementSpecificationConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSpecificationRequirementConnections_RequirementSpecif~1",
                table: "SkillSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSpecificationRequirementConnections_SkillSpecification~",
                table: "SkillSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecificationProjectConnections_Projects_ProjectId",
                table: "TimeSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecificationProjectConnections_TimeSpecifications_Time~",
                table: "TimeSpecificationProjectConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecificationRequirementConnections_RequirementSpecific~",
                table: "TimeSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecificationRequirementConnections_TimeSpecifications_~",
                table: "TimeSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecifications_TimeSpecifications_End_MomentId",
                table: "TimeSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpecifications_TimeSpecifications_Start_MomentId",
                table: "TimeSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_WorkAmountSpe~",
                table: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSpecificationConnections_ContactSpecifications_Conta~",
                table: "ContactSpecificationConnections",
                column: "ContactSpecificationId",
                principalTable: "ContactSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSpecificationConnections_Projects_ProjectId",
                table: "ContactSpecificationConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionSpecificationProjectConnections_DescriptionSpeci~",
                table: "DescriptionSpecificationProjectConnections",
                column: "DescriptionSpecificationId",
                principalTable: "DescriptionSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionSpecificationProjectConnections_Projects_Project~",
                table: "DescriptionSpecificationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionSpecifications_DescriptionTypes_TypeEntityId",
                table: "DescriptionSpecifications",
                column: "TypeEntityId",
                principalTable: "DescriptionTypes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GraphicsSpecificationProjectConnections_GraphicsSpecificati~",
                table: "GraphicsSpecificationProjectConnections",
                column: "GraphicsSpecificationId",
                principalTable: "GraphicsSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GraphicsSpecificationProjectConnections_Projects_ProjectId",
                table: "GraphicsSpecificationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryItems_Histories_HistoryId",
                table: "HistoryItems",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecificationProjectConnections_LocationSpecificati~",
                table: "LocationSpecificationProjectConnections",
                column: "LocationSpecificationId",
                principalTable: "LocationSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecificationProjectConnections_Projects_ProjectId",
                table: "LocationSpecificationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecificationRequirementConnections_LocationSpecifi~",
                table: "LocationSpecificationRequirementConnections",
                column: "LocationSpecificationId",
                principalTable: "LocationSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationSpecificationRequirementConnections_RequirementSpe~2",
                table: "LocationSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_MaterialSpecifi~",
                table: "MaterialSpecificationRequirementConnections",
                column: "MaterialSpecificationId",
                principalTable: "MaterialSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~1",
                table: "MaterialSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationConnections_Organizations_OrganizationId",
                table: "OrganizationConnections",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPositionConnections_Organizations_OrganizationId",
                table: "OrganizationPositionConnections",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationProjectConnections_Organizations_OrganizationId",
                table: "OrganizationProjectConnections",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationProjectConnections_Projects_ProjectId",
                table: "OrganizationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProjectContributorConnections_Persons_PersonId",
                table: "PersonProjectContributorConnections",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProjectContributorConnections_Projects_ProjectId",
                table: "PersonProjectContributorConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProjectOwnerConnections_Persons_PersonId",
                table: "PersonProjectOwnerConnections",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProjectOwnerConnections_Projects_ProjectId",
                table: "PersonProjectOwnerConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectConnections_Projects_ProjectId",
                table: "ProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectConnections_Projects_RelatedProjectId",
                table: "ProjectConnections",
                column: "RelatedProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTagConnections_ProjectTags_ProjectTagId",
                table: "ProjectTagConnections",
                column: "ProjectTagId",
                principalTable: "ProjectTags",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTagConnections_Projects_ProjectId",
                table: "ProjectTagConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuantitySpecificationRequirementConnections_QuantitySpecifi~",
                table: "QuantitySpecificationRequirementConnections",
                column: "QuantitySpecificationId",
                principalTable: "QuantitySpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuantitySpecificationRequirementConnections_RequirementSpec~",
                table: "QuantitySpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementSpecificationConnections_Projects_ProjectId",
                table: "RequirementSpecificationConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementSpecificationConnections_RequirementSpecificatio~",
                table: "RequirementSpecificationConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSpecificationRequirementConnections_RequirementSpecif~1",
                table: "SkillSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSpecificationRequirementConnections_SkillSpecification~",
                table: "SkillSpecificationRequirementConnections",
                column: "SkillSpecificationId",
                principalTable: "SkillSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecificationProjectConnections_Projects_ProjectId",
                table: "TimeSpecificationProjectConnections",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecificationProjectConnections_TimeSpecifications_Time~",
                table: "TimeSpecificationProjectConnections",
                column: "TimeSpecificationId",
                principalTable: "TimeSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecificationRequirementConnections_RequirementSpecific~",
                table: "TimeSpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecificationRequirementConnections_TimeSpecifications_~",
                table: "TimeSpecificationRequirementConnections",
                column: "TimeSpecificationId",
                principalTable: "TimeSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecifications_TimeSpecifications_End_MomentId",
                table: "TimeSpecifications",
                column: "End_MomentId",
                principalTable: "TimeSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpecifications_TimeSpecifications_Start_MomentId",
                table: "TimeSpecifications",
                column: "Start_MomentId",
                principalTable: "TimeSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "RequirementSpecificationPersonId",
                principalTable: "RequirementSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAmountSpecificationRequirementConnections_WorkAmountSpe~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "WorkAmountSpecificationId",
                principalTable: "WorkAmountSpecifications",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
