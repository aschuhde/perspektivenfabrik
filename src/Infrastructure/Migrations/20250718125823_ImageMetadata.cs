using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content_FileExtension",
                table: "DescriptionImage",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Content_Height",
                table: "DescriptionImage",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content_MimeType",
                table: "DescriptionImage",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Content_Width",
                table: "DescriptionImage",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Thumbnail_Content",
                table: "DescriptionImage",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_FileExtension",
                table: "DescriptionImage",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Thumbnail_Height",
                table: "DescriptionImage",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_MimeType",
                table: "DescriptionImage",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Thumbnail_Width",
                table: "DescriptionImage",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content_FileExtension",
                table: "DescriptionImage");

            migrationBuilder.DropColumn(
                name: "Content_Height",
                table: "DescriptionImage");

            migrationBuilder.DropColumn(
                name: "Content_MimeType",
                table: "DescriptionImage");

            migrationBuilder.DropColumn(
                name: "Content_Width",
                table: "DescriptionImage");

            migrationBuilder.DropColumn(
                name: "Thumbnail_Content",
                table: "DescriptionImage");

            migrationBuilder.DropColumn(
                name: "Thumbnail_FileExtension",
                table: "DescriptionImage");

            migrationBuilder.DropColumn(
                name: "Thumbnail_Height",
                table: "DescriptionImage");

            migrationBuilder.DropColumn(
                name: "Thumbnail_MimeType",
                table: "DescriptionImage");

            migrationBuilder.DropColumn(
                name: "Thumbnail_Width",
                table: "DescriptionImage");
        }
    }
}
