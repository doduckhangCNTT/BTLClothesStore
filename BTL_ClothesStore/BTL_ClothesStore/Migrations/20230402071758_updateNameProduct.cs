using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_ClothesStore.Migrations
{
    public partial class updateNameProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "Product",
                newName: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Product",
                newName: "fullname");
        }
    }
}
