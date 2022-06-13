using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Oblasti",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Putanja = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PotrebnoOdobrenje = table.Column<bool>(type: "bit", nullable: false),
                    NadoblastID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oblasti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Oblasti_Oblasti_NadoblastID",
                        column: x => x.NadoblastID,
                        principalTable: "Oblasti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalozi",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Uloga = table.Column<int>(type: "int", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusNaloga = table.Column<int>(type: "int", nullable: false),
                    PoslednjaPromena = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalozi", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_KorisnickiNalozi_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OsnovniKorisnikPodaci",
                columns: table => new
                {
                    IDBroj = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Privilegije = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsnovniKorisnikPodaci", x => x.IDBroj);
                    table.ForeignKey(
                        name: "FK_OsnovniKorisnikPodaci_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materijali",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ekstenzija = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UkupnaOcena = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IDNaFajlSistemu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KratakOpis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NadoblastID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materijali", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materijali_Oblasti_NadoblastID",
                        column: x => x.NadoblastID,
                        principalTable: "Oblasti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministratorskiZahtevi",
                columns: table => new
                {
                    VremeSlanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<int>(type: "int", nullable: false),
                    SubjekatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorskiZahtevi", x => new { x.AutorID, x.VremeSlanja });
                    table.ForeignKey(
                        name: "FK_AdministratorskiZahtevi_KorisnickiNalozi_AutorID",
                        column: x => x.AutorID,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdministratorskiZahtevi_KorisnickiNalozi_SubjekatID",
                        column: x => x.SubjekatID,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OblastiINadlezni",
                columns: table => new
                {
                    NadlezniID = table.Column<int>(type: "int", nullable: false),
                    OblastID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OblastiINadlezni", x => new { x.NadlezniID, x.OblastID });
                    table.ForeignKey(
                        name: "FK_OblastiINadlezni_KorisnickiNalozi_NadlezniID",
                        column: x => x.NadlezniID,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OblastiINadlezni_Oblasti_OblastID",
                        column: x => x.OblastID,
                        principalTable: "Oblasti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IstorijaIzmena",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    MaterijalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VremeIzmene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipIzmene = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstorijaIzmena", x => new { x.AutorID, x.MaterijalID, x.VremeIzmene });
                    table.ForeignKey(
                        name: "FK_IstorijaIzmena_KorisnickiNalozi_AutorID",
                        column: x => x.AutorID,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IstorijaIzmena_Materijali_MaterijalID",
                        column: x => x.MaterijalID,
                        principalTable: "Materijali",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Komentari",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    MaterijalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VremeKomentarisanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdgovorNaAutorID = table.Column<int>(type: "int", nullable: true),
                    OdgovorNaMaterijalID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OdgovorNaVremeKomentarisanja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentari", x => new { x.AutorID, x.MaterijalID, x.VremeKomentarisanja });
                    table.ForeignKey(
                        name: "FK_Komentari_Komentari_OdgovorNaAutorID_OdgovorNaMaterijalID_OdgovorNaVremeKomentarisanja",
                        columns: x => new { x.OdgovorNaAutorID, x.OdgovorNaMaterijalID, x.OdgovorNaVremeKomentarisanja },
                        principalTable: "Komentari",
                        principalColumns: new[] { "AutorID", "MaterijalID", "VremeKomentarisanja" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Komentari_KorisnickiNalozi_AutorID",
                        column: x => x.AutorID,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentari_Materijali_MaterijalID",
                        column: x => x.MaterijalID,
                        principalTable: "Materijali",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocene",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    MaterijalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipOcene = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocene", x => new { x.AutorID, x.MaterijalID });
                    table.ForeignKey(
                        name: "FK_Ocene_KorisnickiNalozi_AutorID",
                        column: x => x.AutorID,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocene_Materijali_MaterijalID",
                        column: x => x.MaterijalID,
                        principalTable: "Materijali",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZahteviZaDodavanjeMaterijala",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    MaterijalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OblastID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipZahteva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahteviZaDodavanjeMaterijala", x => new { x.AutorID, x.MaterijalID });
                    table.ForeignKey(
                        name: "FK_ZahteviZaDodavanjeMaterijala_KorisnickiNalozi_AutorID",
                        column: x => x.AutorID,
                        principalTable: "KorisnickiNalozi",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahteviZaDodavanjeMaterijala_Materijali_MaterijalID",
                        column: x => x.MaterijalID,
                        principalTable: "Materijali",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahteviZaDodavanjeMaterijala_Oblasti_OblastID",
                        column: x => x.OblastID,
                        principalTable: "Oblasti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorskiZahtevi_SubjekatID",
                table: "AdministratorskiZahtevi",
                column: "SubjekatID");

            migrationBuilder.CreateIndex(
                name: "IX_IstorijaIzmena_MaterijalID",
                table: "IstorijaIzmena",
                column: "MaterijalID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_MaterijalID",
                table: "Komentari",
                column: "MaterijalID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_OdgovorNaAutorID_OdgovorNaMaterijalID_OdgovorNaVremeKomentarisanja",
                table: "Komentari",
                columns: new[] { "OdgovorNaAutorID", "OdgovorNaMaterijalID", "OdgovorNaVremeKomentarisanja" });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Email",
                table: "Korisnici",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiNalozi_KorisnickoIme",
                table: "KorisnickiNalozi",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materijali_IDNaFajlSistemu",
                table: "Materijali",
                column: "IDNaFajlSistemu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materijali_NadoblastID_Naziv_Ekstenzija",
                table: "Materijali",
                columns: new[] { "NadoblastID", "Naziv", "Ekstenzija" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oblasti_NadoblastID",
                table: "Oblasti",
                column: "NadoblastID");

            migrationBuilder.CreateIndex(
                name: "IX_Oblasti_Putanja",
                table: "Oblasti",
                column: "Putanja",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OblastiINadlezni_OblastID",
                table: "OblastiINadlezni",
                column: "OblastID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_MaterijalID",
                table: "Ocene",
                column: "MaterijalID");

            migrationBuilder.CreateIndex(
                name: "IX_OsnovniKorisnikPodaci_KorisnikID",
                table: "OsnovniKorisnikPodaci",
                column: "KorisnikID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaDodavanjeMaterijala_MaterijalID",
                table: "ZahteviZaDodavanjeMaterijala",
                column: "MaterijalID");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaDodavanjeMaterijala_OblastID",
                table: "ZahteviZaDodavanjeMaterijala",
                column: "OblastID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministratorskiZahtevi");

            migrationBuilder.DropTable(
                name: "IstorijaIzmena");

            migrationBuilder.DropTable(
                name: "Komentari");

            migrationBuilder.DropTable(
                name: "OblastiINadlezni");

            migrationBuilder.DropTable(
                name: "Ocene");

            migrationBuilder.DropTable(
                name: "OsnovniKorisnikPodaci");

            migrationBuilder.DropTable(
                name: "ZahteviZaDodavanjeMaterijala");

            migrationBuilder.DropTable(
                name: "KorisnickiNalozi");

            migrationBuilder.DropTable(
                name: "Materijali");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Oblasti");
        }
    }
}
