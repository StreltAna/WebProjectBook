using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjectBook.Data.Migrations.Identity
{
    public partial class EmployeeDbMigrationNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Lastname",
                table: "Employees",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Firstname",
                table: "Employees",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
