using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace curitibano.microservico.junina.Migrations
{
    /// <inheritdoc />
    public partial class mig003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormaId",
                table: "Venda",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaId",
                table: "Venda");
        }
    }
}
