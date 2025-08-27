using API.Models.Dtos;

namespace API.Repositories
{
    public interface IItemRepository
    {
        Task<List<ItemDto>> GetItems();
        Task<ItemDetailDto?> GetItemById(int id);
        Task<ItemDetailDto> AddItem(ItemDetailDto dto);
        Task<ItemDetailDto> UpdateItem(ItemDetailDto dto);
        Task DeleteItem(int id);

    }
}
