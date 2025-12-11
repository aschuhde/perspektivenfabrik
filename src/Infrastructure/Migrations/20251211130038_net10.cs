using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class net10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DbPostalAddress_PostalAddress_AddressDisplayName",
                table: "LocationSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DbPostalAddress_PostalAddress_AddressText",
                table: "LocationSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DbPostalAddress_PostalAddress_AddressDisplayName",
                table: "LocationSpecifications");

            migrationBuilder.DropColumn(
                name: "DbPostalAddress_PostalAddress_AddressText",
                table: "LocationSpecifications");
        }
    }
}
