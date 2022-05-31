using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmirImamTask.DataServices.Migrations
{
    public partial class Item_ItemCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "Item",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "Item");
        }
    }
}
