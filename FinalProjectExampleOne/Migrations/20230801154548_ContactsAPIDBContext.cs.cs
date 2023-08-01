using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectExampleOne.Migrations
{
    public partial class ContactsAPIDBContextcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amplifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmplifierManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmplifierType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmplifierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmplifierCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amplifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guitars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuitarManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedalManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PedalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PedalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PedalCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amplifiers");

            migrationBuilder.DropTable(
                name: "Guitars");

            migrationBuilder.DropTable(
                name: "Pedals");
        }
    }
}
