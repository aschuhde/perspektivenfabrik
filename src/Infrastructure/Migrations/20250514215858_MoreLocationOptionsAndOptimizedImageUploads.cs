using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoreLocationOptionsAndOptimizedImageUploads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GraphicsSpecificationTemp",
                table: "DescriptionImage",
                type: "uuid",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
            
            migrationBuilder.Sql(@"
                INSERT INTO ""DescriptionImage"" (""EntityId"", ""ProjectId"", ""Content_Content"", ""GraphicsSpecificationTemp"")
                SELECT gen_random_uuid(), t1.""ProjectId"", t2.""Content_Content"", t2.""EntityId""
                FROM ""GraphicsSpecificationProjectConnections"" as t1
                                    INNER JOIN ""GraphicsSpecifications"" as t2
                ON t1.""GraphicsSpecificationId"" = t2.""EntityId""
            ");
            
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "GraphicsSpecifications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
            
            migrationBuilder.Sql(@"
                UPDATE ""GraphicsSpecifications"" g 
                SET ""ImageId"" = p.""EntityId""
                FROM ""DescriptionImage"" p 
                WHERE g.""EntityId"" = p.""GraphicsSpecificationTemp""
            ");
            
            migrationBuilder.DropColumn(
                name: "GraphicsSpecificationTemp",
                table: "DescriptionImage");
            
            migrationBuilder.DropColumn(
                name: "Content_Content",
                table: "GraphicsSpecifications");

            migrationBuilder.AlterColumn<string>(
                name: "DbLocationSpecification_type",
                table: "LocationSpecifications",
                type: "character varying(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(34)",
                oldMaxLength: 34);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "GraphicsSpecifications");

            migrationBuilder.AlterColumn<string>(
                name: "DbLocationSpecification_type",
                table: "LocationSpecifications",
                type: "character varying(34)",
                maxLength: 34,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(55)",
                oldMaxLength: 55);

            migrationBuilder.AddColumn<byte[]>(
                name: "Content_Content",
                table: "GraphicsSpecifications",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
