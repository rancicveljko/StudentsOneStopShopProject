using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaDodavanjeMaterijala_KorisnickiNalozi_AutorID",
                table: "ZahteviZaDodavanjeMaterijala");

            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaDodavanjeMaterijala_Materijali_MaterijalID",
                table: "ZahteviZaDodavanjeMaterijala");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZahteviZaDodavanjeMaterijala",
                table: "ZahteviZaDodavanjeMaterijala");

            migrationBuilder.RenameTable(
                name: "ZahteviZaDodavanjeMaterijala",
                newName: "ZahteviZaDodavanjeIliAzuriranjeMaterijala");

            migrationBuilder.RenameIndex(
                name: "IX_ZahteviZaDodavanjeMaterijala_MaterijalID",
                table: "ZahteviZaDodavanjeIliAzuriranjeMaterijala",
                newName: "IX_ZahteviZaDodavanjeIliAzuriranjeMaterijala_MaterijalID");

            migrationBuilder.AddColumn<DateTime>(
                name: "VremeSlanja",
                table: "ZahteviZaDodavanjeIliAzuriranjeMaterijala",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZahteviZaDodavanjeIliAzuriranjeMaterijala",
                table: "ZahteviZaDodavanjeIliAzuriranjeMaterijala",
                columns: new[] { "AutorID", "MaterijalID", "VremeSlanja" });

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaDodavanjeIliAzuriranjeMaterijala_KorisnickiNalozi_AutorID",
                table: "ZahteviZaDodavanjeIliAzuriranjeMaterijala",
                column: "AutorID",
                principalTable: "KorisnickiNalozi",
                principalColumn: "KorisnikID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaDodavanjeIliAzuriranjeMaterijala_Materijali_MaterijalID",
                table: "ZahteviZaDodavanjeIliAzuriranjeMaterijala",
                column: "MaterijalID",
                principalTable: "Materijali",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaDodavanjeIliAzuriranjeMaterijala_KorisnickiNalozi_AutorID",
                table: "ZahteviZaDodavanjeIliAzuriranjeMaterijala");

            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaDodavanjeIliAzuriranjeMaterijala_Materijali_MaterijalID",
                table: "ZahteviZaDodavanjeIliAzuriranjeMaterijala");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZahteviZaDodavanjeIliAzuriranjeMaterijala",
                table: "ZahteviZaDodavanjeIliAzuriranjeMaterijala");

            migrationBuilder.DropColumn(
                name: "VremeSlanja",
                table: "ZahteviZaDodavanjeIliAzuriranjeMaterijala");

            migrationBuilder.RenameTable(
                name: "ZahteviZaDodavanjeIliAzuriranjeMaterijala",
                newName: "ZahteviZaDodavanjeMaterijala");

            migrationBuilder.RenameIndex(
                name: "IX_ZahteviZaDodavanjeIliAzuriranjeMaterijala_MaterijalID",
                table: "ZahteviZaDodavanjeMaterijala",
                newName: "IX_ZahteviZaDodavanjeMaterijala_MaterijalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZahteviZaDodavanjeMaterijala",
                table: "ZahteviZaDodavanjeMaterijala",
                columns: new[] { "AutorID", "MaterijalID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaDodavanjeMaterijala_KorisnickiNalozi_AutorID",
                table: "ZahteviZaDodavanjeMaterijala",
                column: "AutorID",
                principalTable: "KorisnickiNalozi",
                principalColumn: "KorisnikID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaDodavanjeMaterijala_Materijali_MaterijalID",
                table: "ZahteviZaDodavanjeMaterijala",
                column: "MaterijalID",
                principalTable: "Materijali",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
