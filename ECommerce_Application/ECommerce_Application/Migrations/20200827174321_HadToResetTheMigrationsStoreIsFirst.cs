﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Application.Migrations
{
    public partial class HadToResetTheMigrationsStoreIsFirst : Migration
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
                    Quantity = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
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
                    Quantity = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    IsFeature = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    CartId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Age", "Breed", "Category", "Color", "Description", "Image", "IsFeature", "Name", "Price", "Quantity", "SKU", "SuperPower" },
                values: new object[,]
                {
                    { 1, 2, "Staffordshire Terrier", "Bully", "Brindle", "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ", "https://superpetpicturestorage.blob.core.windows.net/productimages/Rampage", true, "Rampage", 200m, 1, null, "Super Love" },
                    { 2, 4, "Poodle", "Poodles", "White", "Loves ", "https://superpetpicturestorage.blob.core.windows.net/productimages/Snowball", false, "Snowball", 200m, 1, null, "Super Love" },
                    { 3, 7, "Golden Doodle", "Poodles", "Golden", "Her thick hips won't stop her from dragging you across the concrete to catch a squirrel", "https://superpetpicturestorage.blob.core.windows.net/productimages/Whiskey", false, "Whiskey", 2000m, 1, null, "Fly" },
                    { 4, 6, "Labradoodle", "Poodles", "black", "Fastest dog in the world. She's beat Usain Bolt... Twice. ", "https://superpetpicturestorage.blob.core.windows.net/productimages/rye.jpeg", false, "Rye", 9000m, 1, null, "Super speed" },
                    { 5, 3, "Dog", "Poodles", "Brown and White", "Will knock anything on your desk onto the floor. Can also poop in toilet. ", "https://superpetpicturestorage.blob.core.windows.net/productimages/backup.jpeg", false, "Snowball", 4000m, 1, null, "Personality" },
                    { 6, 15, "Dog", "Bully", "Brown", "Speaks English... And a little Spanish. ", "https://superpetpicturestorage.blob.core.windows.net/productimages/Duke1.jpeg", false, "Duke", 9000m, 1, null, "Speaking" },
                    { 7, 99, "Dog", "Bully", "Grey", "Disrupts Zoom meetings. Can order Starbucks on occassion.", "https://superpetpicturestorage.blob.core.windows.net/productimages/Josie", false, "Josie", 6000m, 1, null, "Ordering coffee" },
                    { 8, 8, "Dog", "Bully", "Orangeish", "As if a dog wasn't enough, this guy comes with laser eyes. ", "https://superpetpicturestorage.blob.core.windows.net/productimages/chubbs.jpeg", false, "Chubbs", 1000m, 1, null, "Laser Eyes" },
                    { 9, 15, "Dog", "Bully", "Orange and White", "An engineer who dabbles in explosives.", "https://superpetpicturestorage.blob.core.windows.net/productimages/Peanut.jpeg", false, "Peanut", 5000m, 1, null, "Super Genius" },
                    { 10, 6, "Pomeranian", "Mixed", "Black", "Makes bukoo money.", "https://superpetpicturestorage.blob.core.windows.net/productimages/Mani", false, "Mani", 1000m, 1, null, "Can produce cash out of thin-air" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
