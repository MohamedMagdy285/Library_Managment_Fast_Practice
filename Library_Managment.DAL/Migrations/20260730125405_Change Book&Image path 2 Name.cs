using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Managment.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBookImagepath2Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Books",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "BookPath",
                table: "Books",
                newName: "BookName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Books",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "Books",
                newName: "BookPath");
        }
    }
}
