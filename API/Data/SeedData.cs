﻿using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<ItemEntity>().HasData(new List<ItemEntity> {

                new ItemEntity
                {
                    Id = 1,
                    Name = "Smartphone",
                    Description = "Latest model with high-resolution display.",
                    Price = 799.99m,
                },
                new ItemEntity
                {
                    Id = 2,
                    Name = "Bluetooth Speaker",
                    Description = "Portable speaker with deep bass.",
                    Price = 59.99m,
                },
                new ItemEntity
                {
                    Id = 3,
                    Name = "Gaming Monitor",
                    Description = "27-inch 144Hz gaming monitor.",
                    Price = 299.99m,
                },
                new ItemEntity
                {
                    Id = 4,
                    Name = "USB-C Hub",
                    Description = "Multiport adapter for laptops.",
                    Price = 39.99m,
                },
                new ItemEntity
                {
                    Id = 5,
                    Name = "Noise Cancelling Headphones",
                    Description = "Over-ear headphones with active noise cancellation.",
                    Price = 199.99m,
                }
            });
            builder.Entity<BidEntity>().HasData(new List<BidEntity> {
                new BidEntity
                {
                    Id = 1,
                    ItemId = 1,
                    BidderName = "Alice",
                    Amount = 810.00m
                },
                 new BidEntity
                {
                    Id = 2,
                    ItemId = 1,
                    BidderName = "Bob",
                    Amount = 820.00m
                },
                 new BidEntity
                {
                    Id = 3,
                    ItemId = 2,
                    BidderName = "Charlie",
                    Amount = 65.00m
                },
                   new BidEntity
                {
                    Id = 4,
                    ItemId = 3,
                    BidderName = "Diana",
                    Amount = 320.00m
                }
            });
        }
    }

}