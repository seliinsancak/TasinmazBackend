using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasinmazBackend.Migrations
{
    /// <inheritdoc />
    public partial class SeedTasinmazlar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasinmazlar",
                columns: new[] { "Id", "Ada", "Parsel", "Nitelik", "Adres", "MahalleId" },
                values: new object[,]
                {
                    { 1, "123", "1", "Konut", "Kızılay Mah. No:1", 1 },
                    { 2, "124", "2", "Arsa", "Dikmen Mah. No:2", 2 },
                    { 3, "125", "3", "İş Yeri", "Bağlum Mah. No:3", 3 },
                    { 4, "126", "4", "Konut", "Moda Mah. No:4", 4 },
                    { 5, "127", "5", "Arsa", "Erenköy Mah. No:5", 5 },
                    { 6, "128", "6", "İş Yeri", "Levent Mah. No:6", 6 },
                    { 7, "129", "7", "Konut", "Akatlar Mah. No:7", 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasinmazlar",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7 });
        }
    }
}
