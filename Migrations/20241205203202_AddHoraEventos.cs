using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaLeaf.Migrations
{
    /// <inheritdoc />
    public partial class AddHoraEventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hora",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Eventos");
        }
    }
}
