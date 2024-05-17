using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "Histories",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Firstname = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DbPerson_type = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy_DbPersonEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedBy_DbPersonEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Persons_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_Persons_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_Persons_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId");
                });

            migrationBuilder.CreateTable(
                name: "ContactSpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    DbContactSpecification_type = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    MailAddress_Mail = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber_PhoneNumberText = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine1 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine2 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine3 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine4 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine5 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine6 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ContactSpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_ContactSpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactSpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionTypes",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DescriptionTitle_RawContentString = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionTypes", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_DescriptionTypes_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_DescriptionTypes_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionTypes_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GraphicsSpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Content_Content = table.Column<byte[]>(type: "bytea", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsSpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_GraphicsSpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_GraphicsSpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GraphicsSpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationSpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    DbLocationSpecification_type = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    PostalAddress_AddressLine1 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine2 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine3 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine4 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine5 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostalAddress_AddressLine6 = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Coordinates_Lat = table.Column<double>(type: "double precision", nullable: true),
                    Coordinates_Lon = table.Column<double>(type: "double precision", nullable: true),
                    Region_RegionName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_LocationSpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_LocationSpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationSpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_MaterialSpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_MaterialSpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialSpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Organizations_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_Organizations_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizations_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Phase = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Visibility = table.Column<int>(type: "integer", nullable: false),
                    ProjectName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ProjectTitle_RawContentString = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    ConnectedOrganizationsSameAsOwner = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Projects_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_Projects_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTags",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTags", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ProjectTags_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_ProjectTags_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTags_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuantitySpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantitySpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_QuantitySpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_QuantitySpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuantitySpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequirementSpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeSpecificationSameAsProject = table.Column<bool>(type: "boolean", nullable: false),
                    DbRequirementSpecification_type = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementSpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_RequirementSpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_RequirementSpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementSpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillSpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_SkillSpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_SkillSpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillSpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    DbTimeSpecification_type = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    DbTimeSpecificationDateTime_Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Month_MonthFromOneToTwelve = table.Column<int>(type: "integer", nullable: true),
                    Month_Year_YearNumber = table.Column<int>(type: "integer", nullable: true),
                    Start_MomentId = table.Column<Guid>(type: "uuid", nullable: true),
                    End_MomentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_TimeSpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_TimeSpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSpecifications_TimeSpecifications_End_MomentId",
                        column: x => x.End_MomentId,
                        principalTable: "TimeSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSpecifications_TimeSpecifications_Start_MomentId",
                        column: x => x.Start_MomentId,
                        principalTable: "TimeSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefreshToken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AbsoluteExpirationUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkAmountSpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAmountSpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_WorkAmountSpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_WorkAmountSpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkAmountSpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionSpecifications",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content_RawContentString = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionSpecifications", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_DescriptionSpecifications_DescriptionTypes_TypeEntityId",
                        column: x => x.TypeEntityId,
                        principalTable: "DescriptionTypes",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionSpecifications_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_DescriptionSpecifications_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionSpecifications_Persons_LastModifiedBy_PersonId",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_OrganizationConnections_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactSpecificationConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactSpecificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSpecificationConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ContactSpecificationConnections_ContactSpecifications_Conta~",
                        column: x => x.ContactSpecificationId,
                        principalTable: "ContactSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactSpecificationConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GraphicsSpecificationProjectConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    GraphicsSpecificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsSpecificationProjectConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_GraphicsSpecificationProjectConnections_GraphicsSpecificati~",
                        column: x => x.GraphicsSpecificationId,
                        principalTable: "GraphicsSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GraphicsSpecificationProjectConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationSpecificationProjectConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationSpecificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSpecificationProjectConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_LocationSpecificationProjectConnections_LocationSpecificati~",
                        column: x => x.LocationSpecificationId,
                        principalTable: "LocationSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationSpecificationProjectConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationProjectConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationProjectConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_OrganizationProjectConnections_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationProjectConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonProjectContributorConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProjectContributorConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_PersonProjectContributorConnections_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProjectContributorConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonProjectOwnerConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProjectOwnerConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_PersonProjectOwnerConnections_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProjectOwnerConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    RelatedProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ProjectConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectConnections_Projects_RelatedProjectId",
                        column: x => x.RelatedProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTagConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectTagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTagConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_ProjectTagConnections_ProjectTags_ProjectTagId",
                        column: x => x.ProjectTagId,
                        principalTable: "ProjectTags",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTagConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSpecificationRequirementConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequirementSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DbRequirementSpecificationMaterialEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    DbRequirementSpecificationMoneyEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSpecificationRequirementConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_MaterialSpecificationRequirementConnections_MaterialSpecifi~",
                        column: x => x.MaterialSpecificationId,
                        principalTable: "MaterialSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialSpecificationRequirementConnections_RequirementSpec~",
                        column: x => x.DbRequirementSpecificationMaterialEntityId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~1",
                        column: x => x.DbRequirementSpecificationMoneyEntityId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_MaterialSpecificationRequirementConnections_RequirementSpe~2",
                        column: x => x.RequirementSpecificationId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuantitySpecificationRequirementConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequirementSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuantitySpecificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantitySpecificationRequirementConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_QuantitySpecificationRequirementConnections_QuantitySpecifi~",
                        column: x => x.QuantitySpecificationId,
                        principalTable: "QuantitySpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuantitySpecificationRequirementConnections_RequirementSpec~",
                        column: x => x.RequirementSpecificationId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequirementSpecificationConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequirementSpecificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementSpecificationConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_RequirementSpecificationConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementSpecificationConnections_RequirementSpecificatio~",
                        column: x => x.RequirementSpecificationId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillSpecificationRequirementConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequirementSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DbRequirementSpecificationPersonEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSpecificationRequirementConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_SkillSpecificationRequirementConnections_RequirementSpecifi~",
                        column: x => x.DbRequirementSpecificationPersonEntityId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_SkillSpecificationRequirementConnections_RequirementSpecif~1",
                        column: x => x.RequirementSpecificationId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillSpecificationRequirementConnections_SkillSpecification~",
                        column: x => x.SkillSpecificationId,
                        principalTable: "SkillSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSpecificationProjectConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeSpecificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSpecificationProjectConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_TimeSpecificationProjectConnections_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSpecificationProjectConnections_TimeSpecifications_Time~",
                        column: x => x.TimeSpecificationId,
                        principalTable: "TimeSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSpecificationRequirementConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequirementSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeSpecificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSpecificationRequirementConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_TimeSpecificationRequirementConnections_RequirementSpecific~",
                        column: x => x.RequirementSpecificationId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSpecificationRequirementConnections_TimeSpecifications_~",
                        column: x => x.TimeSpecificationId,
                        principalTable: "TimeSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkAmountSpecificationRequirementConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequirementSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkAmountSpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DbRequirementSpecificationPersonEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAmountSpecificationRequirementConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                        column: x => x.DbRequirementSpecificationPersonEntityId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_WorkAmountSpecificationRequirementConnections_RequirementS~1",
                        column: x => x.RequirementSpecificationId,
                        principalTable: "RequirementSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkAmountSpecificationRequirementConnections_WorkAmountSpe~",
                        column: x => x.WorkAmountSpecificationId,
                        principalTable: "WorkAmountSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionSpecificationProjectConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescriptionSpecificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionSpecificationProjectConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_DescriptionSpecificationProjectConnections_DescriptionSpeci~",
                        column: x => x.DescriptionSpecificationId,
                        principalTable: "DescriptionSpecifications",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionSpecificationProjectConnections_Projects_Project~",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationPositionConnections",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationPosition_PositionName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DbOrganizationConnectionEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy_PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    History_HistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationPositionConnections", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_OrganizationPositionConnections_Histories_History_HistoryId",
                        column: x => x.History_HistoryId,
                        principalTable: "Histories",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_OrganizationPositionConnections_OrganizationConnections_DbO~",
                        column: x => x.DbOrganizationConnectionEntityId,
                        principalTable: "OrganizationConnections",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_OrganizationPositionConnections_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationPositionConnections_Persons_CreatedBy_PersonId",
                        column: x => x.CreatedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationPositionConnections_Persons_LastModifiedBy_Pers~",
                        column: x => x.LastModifiedBy_PersonId,
                        principalTable: "Persons",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactSpecificationConnections_ContactSpecificationId",
                table: "ContactSpecificationConnections",
                column: "ContactSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactSpecificationConnections_ProjectId",
                table: "ContactSpecificationConnections",
                column: "ProjectId");

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

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionSpecificationProjectConnections_DescriptionSpeci~",
                table: "DescriptionSpecificationProjectConnections",
                column: "DescriptionSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionSpecificationProjectConnections_ProjectId",
                table: "DescriptionSpecificationProjectConnections",
                column: "ProjectId");

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
                name: "IX_DescriptionSpecifications_TypeEntityId",
                table: "DescriptionSpecifications",
                column: "TypeEntityId");

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
                name: "IX_GraphicsSpecificationProjectConnections_GraphicsSpecificati~",
                table: "GraphicsSpecificationProjectConnections",
                column: "GraphicsSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphicsSpecificationProjectConnections_ProjectId",
                table: "GraphicsSpecificationProjectConnections",
                column: "ProjectId");

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
                name: "IX_LocationSpecificationProjectConnections_LocationSpecificati~",
                table: "LocationSpecificationProjectConnections",
                column: "LocationSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSpecificationProjectConnections_ProjectId",
                table: "LocationSpecificationProjectConnections",
                column: "ProjectId");

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
                name: "IX_MaterialSpecificationRequirementConnections_DbRequirementS~1",
                table: "MaterialSpecificationRequirementConnections",
                column: "DbRequirementSpecificationMoneyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSpecificationRequirementConnections_DbRequirementSp~",
                table: "MaterialSpecificationRequirementConnections",
                column: "DbRequirementSpecificationMaterialEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSpecificationRequirementConnections_MaterialSpecifi~",
                table: "MaterialSpecificationRequirementConnections",
                column: "MaterialSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSpecificationRequirementConnections_RequirementSpec~",
                table: "MaterialSpecificationRequirementConnections",
                column: "RequirementSpecificationId");

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
                name: "IX_OrganizationConnections_OrganizationId",
                table: "OrganizationConnections",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionConnections_CreatedBy_PersonId",
                table: "OrganizationPositionConnections",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionConnections_DbOrganizationConnectionEnt~",
                table: "OrganizationPositionConnections",
                column: "DbOrganizationConnectionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionConnections_History_HistoryId",
                table: "OrganizationPositionConnections",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionConnections_LastModifiedBy_PersonId",
                table: "OrganizationPositionConnections",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionConnections_OrganizationId",
                table: "OrganizationPositionConnections",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProjectConnections_OrganizationId",
                table: "OrganizationProjectConnections",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProjectConnections_ProjectId",
                table: "OrganizationProjectConnections",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CreatedBy_PersonId",
                table: "Organizations",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_History_HistoryId",
                table: "Organizations",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_LastModifiedBy_PersonId",
                table: "Organizations",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProjectContributorConnections_PersonId",
                table: "PersonProjectContributorConnections",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProjectContributorConnections_ProjectId",
                table: "PersonProjectContributorConnections",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProjectOwnerConnections_PersonId",
                table: "PersonProjectOwnerConnections",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProjectOwnerConnections_ProjectId",
                table: "PersonProjectOwnerConnections",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CreatedBy_PersonId",
                table: "Persons",
                column: "CreatedBy_PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_History_HistoryId",
                table: "Persons",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LastModifiedBy_PersonId",
                table: "Persons",
                column: "LastModifiedBy_PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectConnections_ProjectId",
                table: "ProjectConnections",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectConnections_RelatedProjectId",
                table: "ProjectConnections",
                column: "RelatedProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedBy_PersonId",
                table: "Projects",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_History_HistoryId",
                table: "Projects",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LastModifiedBy_PersonId",
                table: "Projects",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTagConnections_ProjectId",
                table: "ProjectTagConnections",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTagConnections_ProjectTagId",
                table: "ProjectTagConnections",
                column: "ProjectTagId");

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
                name: "IX_QuantitySpecificationRequirementConnections_QuantitySpecifi~",
                table: "QuantitySpecificationRequirementConnections",
                column: "QuantitySpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantitySpecificationRequirementConnections_RequirementSpec~",
                table: "QuantitySpecificationRequirementConnections",
                column: "RequirementSpecificationId",
                unique: true);

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
                name: "IX_RequirementSpecificationConnections_ProjectId",
                table: "RequirementSpecificationConnections",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementSpecificationConnections_RequirementSpecificatio~",
                table: "RequirementSpecificationConnections",
                column: "RequirementSpecificationId");

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
                name: "IX_SkillSpecificationRequirementConnections_DbRequirementSpeci~",
                table: "SkillSpecificationRequirementConnections",
                column: "DbRequirementSpecificationPersonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSpecificationRequirementConnections_RequirementSpecifi~",
                table: "SkillSpecificationRequirementConnections",
                column: "RequirementSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSpecificationRequirementConnections_SkillSpecification~",
                table: "SkillSpecificationRequirementConnections",
                column: "SkillSpecificationId");

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
                name: "IX_TimeSpecificationProjectConnections_ProjectId",
                table: "TimeSpecificationProjectConnections",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecificationProjectConnections_TimeSpecificationId",
                table: "TimeSpecificationProjectConnections",
                column: "TimeSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecificationRequirementConnections_RequirementSpecific~",
                table: "TimeSpecificationRequirementConnections",
                column: "RequirementSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecificationRequirementConnections_TimeSpecificationId",
                table: "TimeSpecificationRequirementConnections",
                column: "TimeSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecifications_CreatedBy_PersonId",
                table: "TimeSpecifications",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecifications_End_MomentId",
                table: "TimeSpecifications",
                column: "End_MomentId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecifications_History_HistoryId",
                table: "TimeSpecifications",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecifications_LastModifiedBy_PersonId",
                table: "TimeSpecifications",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpecifications_Start_MomentId",
                table: "TimeSpecifications",
                column: "Start_MomentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_CreatedBy_PersonId",
                table: "UserRefreshTokens",
                column: "CreatedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_History_HistoryId",
                table: "UserRefreshTokens",
                column: "History_HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_LastModifiedBy_PersonId",
                table: "UserRefreshTokens",
                column: "LastModifiedBy_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAmountSpecificationRequirementConnections_DbRequirement~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "DbRequirementSpecificationPersonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAmountSpecificationRequirementConnections_RequirementSp~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "RequirementSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAmountSpecificationRequirementConnections_WorkAmountSpe~",
                table: "WorkAmountSpecificationRequirementConnections",
                column: "WorkAmountSpecificationId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactSpecificationConnections");

            migrationBuilder.DropTable(
                name: "DescriptionSpecificationProjectConnections");

            migrationBuilder.DropTable(
                name: "GraphicsSpecificationProjectConnections");

            migrationBuilder.DropTable(
                name: "LocationSpecificationProjectConnections");

            migrationBuilder.DropTable(
                name: "MaterialSpecificationRequirementConnections");

            migrationBuilder.DropTable(
                name: "OrganizationPositionConnections");

            migrationBuilder.DropTable(
                name: "OrganizationProjectConnections");

            migrationBuilder.DropTable(
                name: "PersonProjectContributorConnections");

            migrationBuilder.DropTable(
                name: "PersonProjectOwnerConnections");

            migrationBuilder.DropTable(
                name: "ProjectConnections");

            migrationBuilder.DropTable(
                name: "ProjectTagConnections");

            migrationBuilder.DropTable(
                name: "QuantitySpecificationRequirementConnections");

            migrationBuilder.DropTable(
                name: "RequirementSpecificationConnections");

            migrationBuilder.DropTable(
                name: "SkillSpecificationRequirementConnections");

            migrationBuilder.DropTable(
                name: "TimeSpecificationProjectConnections");

            migrationBuilder.DropTable(
                name: "TimeSpecificationRequirementConnections");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "WorkAmountSpecificationRequirementConnections");

            migrationBuilder.DropTable(
                name: "ContactSpecifications");

            migrationBuilder.DropTable(
                name: "DescriptionSpecifications");

            migrationBuilder.DropTable(
                name: "GraphicsSpecifications");

            migrationBuilder.DropTable(
                name: "LocationSpecifications");

            migrationBuilder.DropTable(
                name: "MaterialSpecifications");

            migrationBuilder.DropTable(
                name: "OrganizationConnections");

            migrationBuilder.DropTable(
                name: "ProjectTags");

            migrationBuilder.DropTable(
                name: "QuantitySpecifications");

            migrationBuilder.DropTable(
                name: "SkillSpecifications");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TimeSpecifications");

            migrationBuilder.DropTable(
                name: "RequirementSpecifications");

            migrationBuilder.DropTable(
                name: "WorkAmountSpecifications");

            migrationBuilder.DropTable(
                name: "DescriptionTypes");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Histories");
        }
    }
}
