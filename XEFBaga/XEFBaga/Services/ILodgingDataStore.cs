using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XEFBaga.Services
{
    public interface ILodgingDataStore<T>
    {
        Task<bool> AddLodgingAsync(T item);
        Task<bool> UpdateLodgingAsync(T item);
        Task<bool> DeleteLodgingAsync(int id);
        Task<T> GetLodgingAsync(int id);
        Task<IEnumerable<T>> GetLodgingsAsync(bool forceRefresh = false);
    }
}
