using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteNoAction2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Persons_CreatedBy_PersonId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Persons_LastModifiedBy_PersonId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Persons_CreatedBy_PersonId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Persons_LastModifiedBy_PersonId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_Persons_CreatedBy_PersonId",
                table: "UserRefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_Persons_LastModifiedBy_PersonId",
                table: "UserRefreshTokens");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Persons_CreatedBy_PersonId",
                table: "Organizations",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Persons_LastModifiedBy_PersonId",
                table: "Organizations",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Persons_CreatedBy_PersonId",
                table: "Projects",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Persons_LastModifiedBy_PersonId",
                table: "Projects",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_Persons_CreatedBy_PersonId",
                table: "UserRefreshTokens",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_Persons_LastModifiedBy_PersonId",
                table: "UserRefreshTokens",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Persons_CreatedBy_PersonId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Persons_LastModifiedBy_PersonId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Persons_CreatedBy_PersonId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Persons_LastModifiedBy_PersonId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_Persons_CreatedBy_PersonId",
                table: "UserRefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_Persons_LastModifiedBy_PersonId",
                table: "UserRefreshTokens");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Persons_CreatedBy_PersonId",
                table: "Organizations",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Persons_LastModifiedBy_PersonId",
                table: "Organizations",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Persons_CreatedBy_PersonId",
                table: "Projects",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Persons_LastModifiedBy_PersonId",
                table: "Projects",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_Persons_CreatedBy_PersonId",
                table: "UserRefreshTokens",
                column: "CreatedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_Persons_LastModifiedBy_PersonId",
                table: "UserRefreshTokens",
                column: "LastModifiedBy_PersonId",
                principalTable: "Persons",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
