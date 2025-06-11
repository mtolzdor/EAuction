
using API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<ItemEntity> AddItem(ItemEntity item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemEntity?> GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemDto>> GetItems()
        {
            return await _context.Items.Select(i => new ItemDto(i.Id, i.Name, i.Price, i.ImageUrl)).ToListAsync();
        }

        public Task<ItemEntity> UpdateItem(ItemEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
