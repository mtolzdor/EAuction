﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("API.Data.BidEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("BidderName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Bids");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 810.00m,
                            BidderName = "Alice",
                            ItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 820.00m,
                            BidderName = "Bob",
                            ItemId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = 65.00m,
                            BidderName = "Charlie",
                            ItemId = 2
                        },
                        new
                        {
                            Id = 4,
                            Amount = 320.00m,
                            BidderName = "Diana",
                            ItemId = 3
                        });
                });

            modelBuilder.Entity("API.Data.ItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Latest model with high-resolution display.",
                            Name = "Smartphone",
                            Price = 799.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Portable speaker with deep bass.",
                            Name = "Bluetooth Speaker",
                            Price = 59.99m
                        },
                        new
                        {
                            Id = 3,
                            Description = "27-inch 144Hz gaming monitor.",
                            Name = "Gaming Monitor",
                            Price = 299.99m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Multiport adapter for laptops.",
                            Name = "USB-C Hub",
                            Price = 39.99m
                        },
                        new
                        {
                            Id = 5,
                            Description = "Over-ear headphones with active noise cancellation.",
                            Name = "Noise Cancelling Headphones",
                            Price = 199.99m
                        });
                });

            modelBuilder.Entity("API.Data.BidEntity", b =>
                {
                    b.HasOne("API.Data.ItemEntity", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });
#pragma warning restore 612, 618
        }
    }
}
