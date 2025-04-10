using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TranformedPostalAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalAddress_AddressLine1",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "PostalAddress_AddressLine2",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "PostalAddress_AddressLine3",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "PostalAddress_AddressLine4",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "PostalAddress_AddressLine1",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "PostalAddress_AddressLine2",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "PostalAddress_AddressLine3",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "PostalAddress_AddressLine4",
                table: "ContactSpecifications");

            migrationBuilder.RenameColumn(
                name: "PostalAddress_AddressLine6",
                table: "LocationSpecifications",
                newName: "PostalAddress_AddressText");

            migrationBuilder.RenameColumn(
                name: "PostalAddress_AddressLine5",
                table: "LocationSpecifications",
                newName: "PostalAddress_AddressDisplayName");

            migrationBuilder.RenameColumn(
                name: "PostalAddress_AddressLine6",
                table: "ContactSpecifications",
                newName: "PostalAddress_AddressText");

            migrationBuilder.RenameColumn(
                name: "PostalAddress_AddressLine5",
                table: "ContactSpecifications",
                newName: "PostalAddress_AddressDisplayName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalAddress_AddressText",
                table: "LocationSpecifications",
                newName: "PostalAddress_AddressLine6");

            migrationBuilder.RenameColumn(
                name: "PostalAddress_AddressDisplayName",
                table: "LocationSpecifications",
                newName: "PostalAddress_AddressLine5");

            migrationBuilder.RenameColumn(
                name: "PostalAddress_AddressText",
                table: "ContactSpecifications",
                newName: "PostalAddress_AddressLine6");

            migrationBuilder.RenameColumn(
                name: "PostalAddress_AddressDisplayName",
                table: "ContactSpecifications",
                newName: "PostalAddress_AddressLine5");

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress_AddressLine1",
                table: "LocationSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress_AddressLine2",
                table: "LocationSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress_AddressLine3",
                table: "LocationSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress_AddressLine4",
                table: "LocationSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress_AddressLine1",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress_AddressLine2",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress_AddressLine3",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress_AddressLine4",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
