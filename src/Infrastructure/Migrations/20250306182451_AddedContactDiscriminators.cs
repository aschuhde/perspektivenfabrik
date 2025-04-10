using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactDiscriminators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankAccount_AccountName",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccount_Bic_BicName",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccount_Iban_IbanName",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccount_Reference",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganisationName",
                table: "ContactSpecifications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaypalAddress_Mail",
                table: "ContactSpecifications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaypalMeAddress_RawUrl",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalName",
                table: "ContactSpecifications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website_RawUrl",
                table: "ContactSpecifications",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccount_AccountName",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "BankAccount_Bic_BicName",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "BankAccount_Iban_IbanName",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "BankAccount_Reference",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "OrganisationName",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "PaypalAddress_Mail",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "PaypalMeAddress_RawUrl",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "PersonalName",
                table: "ContactSpecifications");

            migrationBuilder.DropColumn(
                name: "Website_RawUrl",
                table: "ContactSpecifications");
        }
    }
}
