using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMaterialSpecifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "MaterialSpecifications",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description_RawContentString",
                table: "MaterialSpecifications",
                type: "character varying(50000)",
                maxLength: 50000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_RawContentString",
                table: "MaterialSpecifications",
                type: "character varying(50000)",
                maxLength: 50000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_RawContentString",
                table: "MaterialSpecifications");

            migrationBuilder.DropColumn(
                name: "Title_RawContentString",
                table: "MaterialSpecifications");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MaterialSpecifications",
                newName: "Value");
        }
    }
}
