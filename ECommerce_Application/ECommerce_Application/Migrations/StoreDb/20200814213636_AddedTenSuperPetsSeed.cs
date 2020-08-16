using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Application.Migrations.StoreDb
{
    public partial class AddedTenSuperPetsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Her thick hips won't stop her from dragging you across the concrete to catch a squirrel");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Age", "Breed", "Color", "Description", "Name", "Price", "SKU", "SuperPower" },
                values: new object[,]
                {
                    { 4, 6, "Labradoodle", "black", "Fastest dog in the world. She's beat Usain Bolt... Twice. ", "Rye", 90000000m, null, "Super speed" },
                    { 5, 3, "Siamese Cat", "Black and White", "Will knock anything on your desk onto the floor. Can also poop in toilet. ", "Snowball", 40000m, null, "Personality" },
                    { 6, 15, "Bear", "Brown", "Speaks English... And a little Spanish. ", "Duke", 9000m, null, "Speaking" },
                    { 7, 99, "Tabbie Cat (unsure)", "Grey", "Disrupts Zoom meetings. Can order Starbucks on occassion.", "Josie", 6000000m, null, "Ordering coffee" },
                    { 8, 8, "Lion", "Orangeish", "As if a lion wasn't enough, this guy comes with laser eyes. ", "Chubbs", 1000000m, null, "Laser Eyes" },
                    { 9, 15, "Hamster", "Orange and White", "An engineer who dabbles in explosives.", "Peanut", 500000m, null, "Super Genius" },
                    { 10, 6, "Pomeranian", "Black", "Makes bukoo money.", "Mani", 1000000000000m, null, "Can produce cash out of thin-air" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Is a pro at Squirrel catching by flying into the trees to catch them");
        }
    }
}
