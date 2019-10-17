using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab1A.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    VIN = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    DealershipID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
