using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedLocationSpecificationsSameAsProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DbRequirementSpecificationPerson_LocationSpecificationsSameAsP~",
                table: "RequirementSpecifications",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LocationSpecificationsSameAsProject",
                table: "RequirementSpecifications",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DbRequirementSpecificationPerson_LocationSpecificationsSameAsP~",
                table: "RequirementSpecifications");

            migrationBuilder.DropColumn(
                name: "LocationSpecificationsSameAsProject",
                table: "RequirementSpecifications");
        }
    }
}
