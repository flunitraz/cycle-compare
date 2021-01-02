using Microsoft.EntityFrameworkCore.Migrations;

namespace webProje.Data.Migrations
{
    public partial class cumartesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Karsilastirmalar",
                columns: table => new
                {
                    KarsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BisikletId = table.Column<int>(type: "int", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Materyal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JantCapi = table.Column<int>(type: "int", nullable: false),
                    VitesSayisi = table.Column<int>(type: "int", nullable: false),
                    KullanimAlani = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrenTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspansiyonTuru = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karsilastirmalar", x => x.KarsId);
                    table.ForeignKey(
                        name: "FK_Karsilastirmalar_Bisikletler_BisikletId",
                        column: x => x.BisikletId,
                        principalTable: "Bisikletler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karsilastirmalar_BisikletId",
                table: "Karsilastirmalar",
                column: "BisikletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karsilastirmalar");
        }
    }
}
