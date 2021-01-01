using Microsoft.EntityFrameworkCore.Migrations;

namespace webProje.Data.Migrations
{
    public partial class cuma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KullaniciFavorileri",
                columns: table => new
                {
                    FavId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BisikletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciFavorileri", x => x.FavId);
                    table.ForeignKey(
                        name: "FK_KullaniciFavorileri_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KullaniciFavorileri_Bisikletler_BisikletId",
                        column: x => x.BisikletId,
                        principalTable: "Bisikletler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciFavorileri_BisikletId",
                table: "KullaniciFavorileri",
                column: "BisikletId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciFavorileri_KullaniciId",
                table: "KullaniciFavorileri",
                column: "KullaniciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciFavorileri");
        }
    }
}
