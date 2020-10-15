using Microsoft.EntityFrameworkCore.Migrations;

namespace Register.Api.Migrations
{
    public partial class CompletedVisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Companies_CompanyId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Employees_EmployeeId",
                table: "Visits");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Visits",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Visits",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Companies_CompanyId",
                table: "Visits",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Employees_EmployeeId",
                table: "Visits",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Companies_CompanyId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Employees_EmployeeId",
                table: "Visits");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Visits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Visits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Companies_CompanyId",
                table: "Visits",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Employees_EmployeeId",
                table: "Visits",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
