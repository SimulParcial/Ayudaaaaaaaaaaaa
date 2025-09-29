using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeriesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInicialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merlinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personaje = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Actor = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    SignoZodiacal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merlinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModernFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personaje = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Actor = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    SignoZodiacal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModernFamilies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merlinas");

            migrationBuilder.DropTable(
                name: "ModernFamilies");
        }
    }
}
