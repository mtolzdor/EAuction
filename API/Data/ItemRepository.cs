﻿
using API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        private static void DtoToEntity(ItemDetailDto dto, ItemEntity item)
        {
            item.Name = dto.Name;
            item.Description = dto.Description;
            item.Price = dto.Price;
            item.ImageUrl = dto.ImageUrl;
        }

        private static ItemDetailDto EntityToDetailDto(ItemEntity item)
        {
            return new ItemDetailDto(item.Id, item.Name, item.Description, item.Price, item.ImageUrl);
        }

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ItemDetailDto> AddItem(ItemDetailDto dto)
        {
            var item = new ItemEntity();

            DtoToEntity(dto, item);

            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return EntityToDetailDto(item);

        }

        public async Task DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                throw new ArgumentException($"Item with ID {id} not found.");
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ItemDetailDto?> GetItemById(int id)
        {
            var item = await _context.Items.SingleOrDefaultAsync(i => i.Id == id);

            if (item == null)
            {
                return null;
            }
            return EntityToDetailDto(item);
        }

        public async Task<List<ItemDto>> GetItems()
        {
            return await _context.Items.Select(i => new ItemDto(i.Id, i.Name, i.Price, i.ImageUrl)).ToListAsync();
        }

        public async Task<ItemDetailDto> UpdateItem(ItemDetailDto dto)
        {
            var item = await _context.Items.FindAsync(dto.Id);

            if (item == null)
            {
                throw new ArgumentException($"Item with ID {dto.Id} not found.");
            }

            DtoToEntity(dto, item);
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return EntityToDetailDto(item);
        }
    }
}
