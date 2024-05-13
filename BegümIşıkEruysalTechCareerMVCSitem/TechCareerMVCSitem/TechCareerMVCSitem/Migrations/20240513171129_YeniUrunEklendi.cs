using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechCareerMVCSitem.Migrations
{
    /// <inheritdoc />
    public partial class YeniUrunEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YeniUrun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    urunResim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yayinlanmaTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeniUrun", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YeniUrun");
        }
    }
}
