using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class CheckConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Salary_MoreThenZero",
                table: "Teachers",
                sql: "[Salary] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Email_Pattern",
                table: "Students",
                sql: "[Email] LIKE '%_@%_.%_'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Salary_MoreThenZero",
                table: "Teachers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Email_Pattern",
                table: "Students");
        }
    }
}
