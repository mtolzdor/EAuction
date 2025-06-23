using API.Dtos;

namespace API.Data
{
    public interface IItemRepository
    {
        Task<List<ItemDto>> GetItems();
        Task<ItemDetailDto?> GetItemById(int id);
        Task<ItemDetailDto> AddItem(ItemDetailDto dto);
        Task<ItemEntity> UpdateItem(ItemEntity item);
        Task DeleteItem(int id);

    }
}
