using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmirImamTask.DataServices.Migrations
{
    public partial class Person_CurrentOtp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentOtp",
                table: "Person",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentOtp",
                table: "Person");
        }
    }
}
