using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public class MockDataStore : ItemDataStore<Item>
    {

        public MockDataStore():base()
        {
            items = new List<Item>()
            {
                new Item { Id = "1", Text = "First item", Description="This is an item description." },
                new Item { Id = "2", Text = "Second item", Description="This is an item description." },
                new Item { Id = "3", Text = "Third item", Description="This is an item description." },
                new Item { Id = "5", Text = "Fourth item", Description="This is an item description." },
                new Item { Id = "5", Text = "Fifth item", Description="This is an item description." },
                new Item { Id = "6", Text = "Sixth item", Description="This is an item description." }
            };
        }

        public override Item Find(Item item)
        {
            var card = items.Where((Item c) => c.Id == item.Id).FirstOrDefault();
            return card;
        }

        public override Item Find(int id)
        {
            var card = items.Where((Item c) => c.Id == id.ToString()).FirstOrDefault();
            return card;
        }
    }
}