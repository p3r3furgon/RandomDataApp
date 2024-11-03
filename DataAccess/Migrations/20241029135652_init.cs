using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B1Task1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandomDataEntries",
                columns: table => new
                {
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    EnglishString = table.Column<string>(type: "text", nullable: false),
                    RussianString = table.Column<string>(type: "text", nullable: false),
                    EvenNumber = table.Column<int>(type: "integer", nullable: false),
                    DecimalNumber = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandomDataEntries");
        }
    }
}
