using API.Dtos;

namespace API.Data
{

    public interface IBidRepository
    {
        Task<List<BidDto>> GetBids(int itemId);
        Task<BidDto> AddBids(BidDto dto);
    }
}