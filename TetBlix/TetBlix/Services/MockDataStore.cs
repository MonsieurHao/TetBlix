﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;

[assembly: Xamarin.Forms.Dependency(typeof(TetBlix.MockDataStore))]
namespace TetBlix
{

    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;
        Realm realm = Realm.GetInstance();

        public MockDataStore()
        {
            items = new List<Item>();

            if (realm.All<Item>().Count() > 0)
            {
                return;
            }

            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Welcome",
                    Description = "Welcome to TetBlix, an application that allow you to remember all the series you want to see with your comments. " +
                    "Use the Add button to add a show that you would like to recommend and write some phrase to precise the synopsis." },

            };

            foreach (var item in mockItems)
            {
                realm.Write(() =>
                {
                    realm.Add(item);
                });
            }
        }

        public async Task<bool> AddItemAsync(Item item, bool update)
        {
            realm.Write(() =>
            {
                realm.Add(item, true);
            });

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item, bool update)
        {
            var _item = realm.All<Item>().Where((Item arg) => arg.Id == item.Id).FirstOrDefault();

            realm.Write(() =>
            {
                realm.Remove(_item);
                realm.Add(item, update);
            });

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {

            realm.Write(() =>
            {
                realm.Remove(item);
            });

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(realm.All<Item>().FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = true)
        {
            return await Task.FromResult(realm.All<Item>());
        }
    }
}
