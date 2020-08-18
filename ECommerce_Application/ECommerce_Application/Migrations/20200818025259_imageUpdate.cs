using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Application.Migrations
{
    public partial class imageUpdate : Migration
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
                    Color = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Age", "Breed", "Color", "Description", "Image", "Name", "Price", "SKU", "SuperPower" },
                values: new object[,]
                {
                    { 1, 2, "Staffordshire Terrier", "Brindle", "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ", null, "Rampage", 200m, null, "Super Love" },
                    { 2, 4, "Poodle", "White", "Loves ", null, "Snowball", 200m, null, "Super Love" },
                    { 3, 7, "Golden Doodle", "Golden", "Her thick hips won't stop her from dragging you across the concrete to catch a squirrel", null, "Whiskey", 2000m, null, "Fly" },
                    { 4, 6, "Labradoodle", "black", "Fastest dog in the world. She's beat Usain Bolt... Twice. ", null, "Rye", 90000000m, null, "Super speed" },
                    { 5, 3, "Siamese Cat", "Black and White", "Will knock anything on your desk onto the floor. Can also poop in toilet. ", null, "Snowball", 40000m, null, "Personality" },
                    { 6, 15, "Bear", "Brown", "Speaks English... And a little Spanish. ", null, "Duke", 9000m, null, "Speaking" },
                    { 7, 99, "Tabbie Cat (unsure)", "Grey", "Disrupts Zoom meetings. Can order Starbucks on occassion.", null, "Josie", 6000000m, null, "Ordering coffee" },
                    { 8, 8, "Lion", "Orangeish", "As if a lion wasn't enough, this guy comes with laser eyes. ", null, "Chubbs", 1000000m, null, "Laser Eyes" },
                    { 9, 15, "Hamster", "Orange and White", "An engineer who dabbles in explosives.", null, "Peanut", 500000m, null, "Super Genius" },
                    { 10, 6, "Pomeranian", "Black", "Makes bukoo money.", null, "Mani", 1000000000000m, null, "Can produce cash out of thin-air" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
