using Microsoft.EntityFrameworkCore.Migrations;

namespace OdontoSimple.Migrations
{
    public partial class UpdateFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tratamento_Procediment_ProcedimentId",
                table: "Tratamento");

            migrationBuilder.DropIndex(
                name: "IX_Tratamento_ProcedimentId",
                table: "Tratamento");

            migrationBuilder.DropColumn(
                name: "ProcedimentId",
                table: "Tratamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcedimentId",
                table: "Tratamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tratamento_ProcedimentId",
                table: "Tratamento",
                column: "ProcedimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tratamento_Procediment_ProcedimentId",
                table: "Tratamento",
                column: "ProcedimentId",
                principalTable: "Procediment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
