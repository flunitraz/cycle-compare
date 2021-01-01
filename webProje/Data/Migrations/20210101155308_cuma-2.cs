using Microsoft.EntityFrameworkCore.Migrations;

namespace webProje.Data.Migrations
{
    public partial class cuma2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KullanimAlani",
                table: "KullaniciFavorileri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marka",
                table: "KullaniciFavorileri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "KullaniciFavorileri",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullanimAlani",
                table: "KullaniciFavorileri");

            migrationBuilder.DropColumn(
                name: "Marka",
                table: "KullaniciFavorileri");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "KullaniciFavorileri");
        }
    }
}
