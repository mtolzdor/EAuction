using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Latest model with high-resolution display.", "https://example.com/images/smartphone.jpg", "Smartphone", 799.99m },
                    { 2, "Portable speaker with deep bass.", "https://example.com/images/speaker.jpg", "Bluetooth Speaker", 59.99m },
                    { 3, "27-inch 144Hz gaming monitor.", "https://example.com/images/monitor.jpg", "Gaming Monitor", 299.99m },
                    { 4, "Multiport adapter for laptops.", "https://example.com/images/hub.jpg", "USB-C Hub", 39.99m },
                    { 5, "Over-ear headphones with active noise cancellation.", "https://example.com/images/headphones.jpg", "Noise Cancelling Headphones", 199.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
