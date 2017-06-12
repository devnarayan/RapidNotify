using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RapidNotify.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(RapidNotify.Services.MockDataStore))]
namespace RapidNotify.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Notification 1", Description="", NotifycationDate=DateTime.UtcNow},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Notification 2", Description="", NotifycationDate=DateTime.UtcNow},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Notification 3", Description="", NotifycationDate=DateTime.UtcNow},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Notification 4", Description="", NotifycationDate=DateTime.UtcNow},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Notification 5", Description="", NotifycationDate=DateTime.UtcNow},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Notification 6", Description="", NotifycationDate=DateTime.UtcNow},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Notification 7", Description="", NotifycationDate=DateTime.UtcNow},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Notification 8", Description="", NotifycationDate=DateTime.UtcNow},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
