namespace API.Dtos
{
    public record ItemDetailDto(int Id, String Name, String? Description, decimal Price, String? ImageUrl);
}
