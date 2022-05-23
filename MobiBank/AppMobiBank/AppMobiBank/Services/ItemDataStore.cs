using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public abstract class ItemDataStore<T> : IDataStore<T>
    {
        public List<T> items { get; set; }

        public abstract T Find(T item);
        public abstract T Find(int id);
        public async Task<bool> AddItemAsync(T item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = Find(id);
            items.Remove(item);
            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            var item = Find(id);
            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            var oldItem = Find(item);
            if(oldItem != null)
                items.Remove(oldItem);
            items.Add(item);
            return await Task.FromResult(true);


        }
    }
}
