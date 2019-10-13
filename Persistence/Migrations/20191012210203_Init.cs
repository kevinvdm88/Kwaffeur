using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    GenderType = table.Column<int>(nullable: true, defaultValue: 77),
                    FirstName = table.Column<string>(maxLength: 150, nullable: true),
                    LastName = table.Column<string>(maxLength: 150, nullable: true),
                    CustomerType = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    Street = table.Column<string>(maxLength: 200, nullable: true),
                    StreetNumber = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 200, nullable: true),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 200, nullable: true),
                    Zip = table.Column<string>(maxLength: 30, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    VatNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(maxLength: 30, nullable: true),
                    Phone = table.Column<string>(maxLength: 30, nullable: true),
                    Fax = table.Column<string>(maxLength: 30, nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
