using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact_Information.Migrations
{
    public partial class ChangecolumnIsActiveintoboolinusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
