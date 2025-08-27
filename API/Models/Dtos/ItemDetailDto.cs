namespace API.Models.Dtos
{
    public record ItemDetailDto(int Id, string Name, string? Description, decimal Price, string? ImageUrl);
}
