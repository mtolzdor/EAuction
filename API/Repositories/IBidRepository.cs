using API.Models.Dtos;

namespace API.Repositories
{
    public interface IBidRepository
    {
        Task<List<BidDto>> GetBids(int itemId);
        Task<BidDto> AddBid(BidDto dto);
    }
}