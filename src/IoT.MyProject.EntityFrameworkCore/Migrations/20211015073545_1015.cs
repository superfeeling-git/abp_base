using Microsoft.EntityFrameworkCore.Migrations;

namespace IoT.MyProject.Migrations
{
    public partial class _1015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppTasks");
        }
    }
}
