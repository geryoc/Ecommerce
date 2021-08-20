using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Ecommerce.WebApi.Shared.Database.Migrations
{
    public partial class SeedEcommerceCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Ecommerce.Category");

            migrationBuilder.InsertData(
                table: "Category",
                schema: "Ecommerce",
                columns: new[] { "Name", "Created" },
                values: new object[,]
                {
                    { "Home", DateTimeOffset.UtcNow },
                    { "Technology", DateTimeOffset.UtcNow },
                    { "Beauty and Health", DateTimeOffset.UtcNow },
                    { "Office", DateTimeOffset.UtcNow },
                    { "Sport", DateTimeOffset.UtcNow },
                    { "Clothes", DateTimeOffset.UtcNow },
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Ecommerce.Category");
        }
    }
}
