using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.WebApi.Shared.Database.Migrations
{
    public partial class CreateTableEcommerceCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ecommerce");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Ecommerce",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "datetimeoffset(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "Ecommerce");
        }
    }
}
