namespace API.Models.Dtos
{
    public record BidDto(int Id, int ItemId, string BidderName, decimal Amount);

}