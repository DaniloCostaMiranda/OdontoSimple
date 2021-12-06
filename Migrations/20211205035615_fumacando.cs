using Microsoft.EntityFrameworkCore.Migrations;

namespace OdontoSimple.Migrations
{
    public partial class fumacando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DenteProcedimento_Dente_DenteId",
                table: "DenteProcedimento");

            migrationBuilder.AlterColumn<int>(
                name: "DenteId",
                table: "DenteProcedimento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TratamentoDenteId",
                table: "DenteProcedimento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DenteProcedimento_TratamentoDenteId",
                table: "DenteProcedimento",
                column: "TratamentoDenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_DenteProcedimento_Dente_DenteId",
                table: "DenteProcedimento",
                column: "DenteId",
                principalTable: "Dente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DenteProcedimento_TratamentoDente_TratamentoDenteId",
                table: "DenteProcedimento",
                column: "TratamentoDenteId",
                principalTable: "TratamentoDente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DenteProcedimento_Dente_DenteId",
                table: "DenteProcedimento");

            migrationBuilder.DropForeignKey(
                name: "FK_DenteProcedimento_TratamentoDente_TratamentoDenteId",
                table: "DenteProcedimento");

            migrationBuilder.DropIndex(
                name: "IX_DenteProcedimento_TratamentoDenteId",
                table: "DenteProcedimento");

            migrationBuilder.DropColumn(
                name: "TratamentoDenteId",
                table: "DenteProcedimento");

            migrationBuilder.AlterColumn<int>(
                name: "DenteId",
                table: "DenteProcedimento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DenteProcedimento_Dente_DenteId",
                table: "DenteProcedimento",
                column: "DenteId",
                principalTable: "Dente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
