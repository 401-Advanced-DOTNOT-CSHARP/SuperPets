﻿// <auto-generated />
using ECommerce_Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce_Application.Migrations.StoreDb
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20200812220545_updatedProducts08122020")]
    partial class updatedProducts08122020
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerce_Application.Models.Services.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SKU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuperPower")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 2,
                            Breed = "Staffordshire Terrier",
                            Color = "Brindle",
                            Description = "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ",
                            Name = "Rampage",
                            Price = 200m,
                            SuperPower = "Super Love"
                        },
                        new
                        {
                            Id = 2,
                            Age = 4,
                            Breed = "Poodle",
                            Color = "White",
                            Description = "Loves ",
                            Name = "Snowball",
                            Price = 200m,
                            SuperPower = "Super Love"
                        },
                        new
                        {
                            Id = 3,
                            Age = 7,
                            Breed = "Golden Doodle",
                            Color = "Golden",
                            Description = "Is a pro at Squirrel catching by flying into the trees to catch them",
                            Name = "Whiskey",
                            Price = 2000m,
                            SuperPower = "Fly"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
