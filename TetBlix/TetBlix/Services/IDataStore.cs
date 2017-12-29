using System.Collections.Generic;
using System.Threading.Tasks;

namespace TetBlix
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item, bool update);
        Task<bool> UpdateItemAsync(T item, bool update);
        Task<bool> DeleteItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = true);
    }
}