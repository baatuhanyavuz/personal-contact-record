using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrepareReport.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabaseAndTableSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Company = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    ReportStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    RegisteredPersonCount = table.Column<int>(type: "integer", nullable: false),
                    RegisteredPhoneNumberCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonID = table.Column<Guid>(type: "uuid", nullable: false),
                    Phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContactInformations_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReportDetails_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportDetails_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformations_PersonID",
                table: "ContactInformations",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_PersonId",
                table: "ReportDetails",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetails",
                column: "ReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInformations");

            migrationBuilder.DropTable(
                name: "ReportDetails");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
