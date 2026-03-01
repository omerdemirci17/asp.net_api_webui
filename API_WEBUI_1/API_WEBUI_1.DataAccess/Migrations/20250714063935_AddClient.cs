using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_WEBUI_1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "SocialMedias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_EmployeeID",
                table: "SocialMedias",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_Employees_EmployeeID",
                table: "SocialMedias",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_Employees_EmployeeID",
                table: "SocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_EmployeeID",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Employees");
        }
    }
}
