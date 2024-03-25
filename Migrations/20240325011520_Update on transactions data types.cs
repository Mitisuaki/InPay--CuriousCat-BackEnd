using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InPay__CuriousCat_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Updateontransactionsdatatypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "DateTime");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "Transactions",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Transactions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
