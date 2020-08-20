using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Application.Migrations
{
    public partial class updatedStoreWithCarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

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
                    Image = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    CartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Age", "Breed", "CartId", "Color", "Description", "Image", "IsAvailable", "Name", "Price", "SKU", "SuperPower" },
                values: new object[,]
                {
                    { 1, 2, "Staffordshire Terrier", 0, "Brindle", "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ", null, false, "Rampage", 200m, null, "Super Love" },
                    { 2, 4, "Poodle", 0, "White", "Loves ", null, false, "Snowball", 200m, null, "Super Love" },
                    { 3, 7, "Golden Doodle", 0, "Golden", "Her thick hips won't stop her from dragging you across the concrete to catch a squirrel", null, false, "Whiskey", 2000m, null, "Fly" },
                    { 4, 6, "Labradoodle", 0, "black", "Fastest dog in the world. She's beat Usain Bolt... Twice. ", null, false, "Rye", 90000000m, null, "Super speed" },
                    { 5, 3, "Siamese Cat", 0, "Black and White", "Will knock anything on your desk onto the floor. Can also poop in toilet. ", null, false, "Snowball", 40000m, null, "Personality" },
                    { 6, 15, "Bear", 0, "Brown", "Speaks English... And a little Spanish. ", null, false, "Duke", 9000m, null, "Speaking" },
                    { 7, 99, "Tabbie Cat (unsure)", 0, "Grey", "Disrupts Zoom meetings. Can order Starbucks on occassion.", null, false, "Josie", 6000000m, null, "Ordering coffee" },
                    { 8, 8, "Lion", 0, "Orangeish", "As if a lion wasn't enough, this guy comes with laser eyes. ", null, false, "Chubbs", 1000000m, null, "Laser Eyes" },
                    { 9, 15, "Hamster", 0, "Orange and White", "An engineer who dabbles in explosives.", null, false, "Peanut", 500000m, null, "Super Genius" },
                    { 10, 6, "Pomeranian", 0, "Black", "Makes bukoo money.", null, false, "Mani", 1000000000000m, null, "Can produce cash out of thin-air" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartId",
                table: "Products",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
