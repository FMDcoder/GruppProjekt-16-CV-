using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GruppProjekt_Grupp16_CV.Migrations
{
    /// <inheritdoc />
    public partial class visitorcv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserVisits",
                columns: table => new
                {
                    VisitorUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVisits", x => new { x.OwnerUserId, x.VisitorUserId });
                    table.ForeignKey(
                        name: "FK_UserVisits_AspNetUsers_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserVisits_AspNetUsers_VisitorUserId",
                        column: x => x.VisitorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVisits_VisitorUserId",
                table: "UserVisits",
                column: "VisitorUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVisits");
        }
    }
}
