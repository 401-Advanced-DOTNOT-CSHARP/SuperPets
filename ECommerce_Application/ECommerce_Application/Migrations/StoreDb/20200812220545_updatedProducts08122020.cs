using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Application.Migrations.StoreDb
{
    public partial class updatedProducts08122020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Breed = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    SuperPower = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Age", "Breed", "Color", "Description", "Name", "Price", "SKU", "SuperPower" },
                values: new object[] { 1, 2, "Staffordshire Terrier", "Brindle", "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ", "Rampage", 200m, null, "Super Love" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Age", "Breed", "Color", "Description", "Name", "Price", "SKU", "SuperPower" },
                values: new object[] { 2, 4, "Poodle", "White", "Loves ", "Snowball", 200m, null, "Super Love" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Age", "Breed", "Color", "Description", "Name", "Price", "SKU", "SuperPower" },
                values: new object[] { 3, 7, "Golden Doodle", "Golden", "Is a pro at Squirrel catching by flying into the trees to catch them", "Whiskey", 2000m, null, "Fly" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
