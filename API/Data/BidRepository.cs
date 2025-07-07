using API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BidRepository : IBidRepository
    {
        private readonly ApplicationDbContext _context;
        public BidRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<BidDto>> GetBids(int itemId)
        {
            return await _context.Bids.Where(b => b.ItemId == itemId).Select(b => new BidDto(b.Id, b.ItemId, b.BidderName, b.Amount)).ToListAsync();
        }
        public async Task<BidDto> AddBid(BidDto dto)
        {
            var bid = new BidEntity();
            bid.ItemId = dto.ItemId;
            bid.BidderName = dto.BidderName;
            bid.Amount = dto.Amount;

            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
            return new BidDto(bid.Id, bid.ItemId, bid.BidderName, bid.Amount);
        }

    }

}