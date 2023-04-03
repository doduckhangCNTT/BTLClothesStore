using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_ClothesStore.Migrations
{
    public partial class updateColumnAvailability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inStock",
                table: "Availability");

            migrationBuilder.RenameColumn(
                name: "outOfStock",
                table: "Availability",
                newName: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Availability",
                newName: "outOfStock");

            migrationBuilder.AddColumn<string>(
                name: "inStock",
                table: "Availability",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
