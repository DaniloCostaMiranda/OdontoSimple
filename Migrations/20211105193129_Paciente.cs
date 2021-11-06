using Microsoft.EntityFrameworkCore.Migrations;

namespace OdontoSimple.Migrations
{
    public partial class Paciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Tratamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tratamento_PacienteId",
                table: "Tratamento",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tratamento_Paciente_PacienteId",
                table: "Tratamento",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tratamento_Paciente_PacienteId",
                table: "Tratamento");

            migrationBuilder.DropIndex(
                name: "IX_Tratamento_PacienteId",
                table: "Tratamento");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Tratamento");
        }
    }
}
