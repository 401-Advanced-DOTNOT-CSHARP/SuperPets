using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Application.Migrations
{
    public partial class AddedImagesToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://superpetpicturestorage.blob.core.windows.net/productimages/Rampage");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://superpetpicturestorage.blob.core.windows.net/productimages/Snowball");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://superpetpicturestorage.blob.core.windows.net/productimages/Whiskey");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://superpetpicturestorage.blob.core.windows.net/productimages/rye.jpeg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Breed", "Color", "Image" },
                values: new object[] { "Dog", "Brown and White", "https://superpetpicturestorage.blob.core.windows.net/productimages/backup.jpeg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Breed", "Image" },
                values: new object[] { "Dog", "https://superpetpicturestorage.blob.core.windows.net/productimages/Duke1.jpeg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Breed", "Image" },
                values: new object[] { "Dog", "https://superpetpicturestorage.blob.core.windows.net/productimages/Josie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Breed", "Description", "Image" },
                values: new object[] { "Dog", "As if a dog wasn't enough, this guy comes with laser eyes. ", "https://superpetpicturestorage.blob.core.windows.net/productimages/chubbs.jpeg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Breed", "Image" },
                values: new object[] { "Dog", "https://superpetpicturestorage.blob.core.windows.net/productimages/Peanut.jpeg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Image", "Price" },
                values: new object[] { "https://superpetpicturestorage.blob.core.windows.net/productimages/Mani", 100000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Breed", "Color", "Image" },
                values: new object[] { "Siamese Cat", "Black and White", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Breed", "Image" },
                values: new object[] { "Bear", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Breed", "Image" },
                values: new object[] { "Tabbie Cat (unsure)", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Breed", "Description", "Image" },
                values: new object[] { "Lion", "As if a lion wasn't enough, this guy comes with laser eyes. ", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Breed", "Image" },
                values: new object[] { "Hamster", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Image", "Price" },
                values: new object[] { null, 1000000000000m });
        }
    }
}
