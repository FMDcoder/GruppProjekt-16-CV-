using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GruppProjekt_Grupp16_CV.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created",
                table: "Project",
                newName: "Created");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatorId",
                table: "Project",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_CreatorId",
                table: "Project",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_CreatorId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CreatorId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Project",
                newName: "created");
        }
    }
}
