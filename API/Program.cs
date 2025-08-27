using API.Data;
using API.Models.Dtos;
using API.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
//builder.Services.AddCors();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "__auth-cookie";
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Admin"));
});

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseAuthentication();

//app.UseCors(p => p.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

app.MapGet("/items", [Authorize] async (IItemRepository repo) =>
{
    var items = await repo.GetItems();
    return Results.Ok(items);
}).Produces<ItemDto[]>(StatusCodes.Status200OK);

app.MapGet("/item/{itemId:int}", [Authorize] async (int itemId, IItemRepository repo) =>
{
    var item = await repo.GetItemById(itemId);
    if (item == null)
    {
        return Results.Problem($"Item with ID {itemId} not found.", statusCode: 404);
    }
    return Results.Ok(item);
}).ProducesProblem(404).Produces<ItemDetailDto>(StatusCodes.Status200OK);

app.MapPost("/items", [Authorize] async (ItemDetailDto dto, IItemRepository repo) =>
{
    var item = await repo.AddItem(dto);
    return Results.Created($"/item/{item.Id}", item);
}).Produces<ItemDetailDto>(StatusCodes.Status201Created);

app.MapPut("/items", [Authorize] async (ItemDetailDto dto, IItemRepository repo) =>
{
    if (await repo.GetItemById(dto.Id) == null)
    {
        return Results.Problem($"Item with ID {dto.Id} not found.", statusCode: 404);
    }
    var item = await repo.UpdateItem(dto);
    return Results.Ok(item);
}).ProducesProblem(404).Produces<ItemDetailDto>(StatusCodes.Status200OK);

app.MapDelete("/items/{itemId:int}", [Authorize] async (int itemId, IItemRepository repo) =>
{
    if (await repo.GetItemById(itemId) == null)
    {
        return Results.Problem($"Item with ID {itemId} not found.", statusCode: 404);
    }
    await repo.DeleteItem(itemId);
    return Results.Ok();
}).ProducesProblem(404).Produces(StatusCodes.Status200OK);

app.MapGet("/items/{itemId:int}/bids", [Authorize] async (int itemId, IItemRepository itemRepo, IBidRepository bidRepo) =>
{
    if (await itemRepo.GetItemById(itemId) == null)
    {
        return Results.Problem($"Item with ID {itemId} not found.", statusCode: 404);
    }
    var bids = await bidRepo.GetBids(itemId);
    return Results.Ok(bids);
}).ProducesProblem(404).Produces(StatusCodes.Status200OK);

app.MapPost("/item/{itemId:int}/bids", [Authorize] async (int itemId, BidDto dto, IBidRepository repo) =>
{
    if (dto.ItemId != itemId)
    {
        return Results.Problem("Id mismatch", statusCode: StatusCodes.Status400BadRequest);
    }
    var bid = await repo.AddBid(dto);
    return Results.Created($"/items/{bid.ItemId}/bids", bid);
}).ProducesProblem(400).Produces<BidDto>(StatusCodes.Status201Created);

app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.MapFallbackToFile("index.html");

app.Run();
