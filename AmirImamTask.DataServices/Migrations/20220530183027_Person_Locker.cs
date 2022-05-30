using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmirImamTask.DataServices.Migrations
{
    public partial class Person_Locker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Locker",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locker",
                table: "Person");
        }
    }
}
