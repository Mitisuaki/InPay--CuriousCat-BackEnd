using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InPay__CuriousCat_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Updateontransactionsdatatypes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Transactions",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "DateTime");
        }
    }
}
