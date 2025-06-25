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

app.MapPost("/items", async (ItemDetailDto dto, IItemRepository repo) =>
{
    var item = await repo.AddItem(dto);
    return Results.Created($"/item/{item.Id}", item);
}).Produces<ItemDetailDto>(StatusCodes.Status201Created);

app.MapPut("/items", async (ItemDetailDto dto, IItemRepository repo) =>
{
    if (await repo.GetItemById(dto.Id) == null)
    {
        return Results.Problem($"Item with ID {dto.Id} not found.", statusCode: 404);
    }
    var item = await repo.UpdateItem(dto);
    return Results.Ok(item);
}).ProducesProblem(404).Produces<ItemDetailDto>(StatusCodes.Status200OK);

app.MapDelete("/items/{itemId:int}", async (int itemId, IItemRepository repo) =>
{
    if (await repo.GetItemById(itemId) == null)
    {
        return Results.Problem($"Item with ID {itemId} not found.", statusCode: 404);
    }
    await repo.DeleteItem(itemId);
    return Results.Ok();
}).ProducesProblem(404).Produces(StatusCodes.Status200OK);

app.Run();
