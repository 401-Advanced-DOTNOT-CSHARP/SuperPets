using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Application.Migrations
{
    public partial class RemovedPostsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, null, "Rampage", 200m, 1 },
                    { 2, null, "Snowball", 200m, 1 },
                    { 3, null, "Whiskey", 2000m, 1 },
                    { 4, null, "Rye", 90000000m, 1 },
                    { 5, null, "Snowball", 40000m, 1 },
                    { 6, null, "Duke", 9000m, 1 },
                    { 7, null, "Josie", 6000000m, 1 },
                    { 8, null, "Chubbs", 1000000m, 1 },
                    { 9, null, "Peanut", 500000m, 1 },
                    { 10, null, "Mani", 1000000000000m, 1 }
                });
        }
    }
}
