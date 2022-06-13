using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZahteviZaDodavanjeMaterijala_Oblasti_OblastID",
                table: "ZahteviZaDodavanjeMaterijala");

            migrationBuilder.DropIndex(
                name: "IX_ZahteviZaDodavanjeMaterijala_OblastID",
                table: "ZahteviZaDodavanjeMaterijala");

            migrationBuilder.DropColumn(
                name: "OblastID",
                table: "ZahteviZaDodavanjeMaterijala");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OblastID",
                table: "ZahteviZaDodavanjeMaterijala",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaDodavanjeMaterijala_OblastID",
                table: "ZahteviZaDodavanjeMaterijala",
                column: "OblastID");

            migrationBuilder.AddForeignKey(
                name: "FK_ZahteviZaDodavanjeMaterijala_Oblasti_OblastID",
                table: "ZahteviZaDodavanjeMaterijala",
                column: "OblastID",
                principalTable: "Oblasti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
