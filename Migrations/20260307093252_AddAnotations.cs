using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddAnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_AttendanceForms",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AttendanceForm",
                table: "Students",
                newName: "Attendance");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_AttendanceForms",
                table: "Students",
                sql: "[Attendance] IN ('Hybrid', 'Offline', 'Online')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_AttendanceForms",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Attendance",
                table: "Students",
                newName: "AttendanceForm");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddCheckConstraint(
                name: "CK_AttendanceForms",
                table: "Students",
                sql: "[AttendanceForm] IN ('Hybrid', 'Offline', 'Online')");
        }
    }
}
