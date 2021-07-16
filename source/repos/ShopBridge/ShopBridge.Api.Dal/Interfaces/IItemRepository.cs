using ShopBridge.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Dal.Interfaces
{
    public interface IItemRepository: IRepository
    {
        Task<List<Item>> GetAllItemAsync(string searchText);
        Task<Item> GetItemAsync(string itemId);
        Task<Item> UpdateItemAsync(Item item);
        Task<Item> AddItemAsync(Item item);
        Task<bool> DeleteItemAsync(string itemId);
        Task<bool> IsItemExistsAsync(string itemId);
    }
}
