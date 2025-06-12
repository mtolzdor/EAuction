using API.Data;
using API.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddScoped<IItemRepository, ItemRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

app.MapGet("/items", async (IItemRepository repo) =>
{
    var items = await repo.GetItems();
    return Results.Ok(items);
}).Produces<ItemDto[]>(StatusCodes.Status200OK);

app.MapGet("/item/{itemId:int}", async (int itemId, IItemRepository repo) =>
{
    var item = await repo.GetItemById(itemId);
    if (item == null)
    {
        return Results.Problem($"Item with ID {itemId} not found.", statusCode: 404);
    }
    return Results.Ok(item);
}).ProducesProblem(404).Produces<ItemDetailDto>(StatusCodes.Status200OK);

app.Run();
