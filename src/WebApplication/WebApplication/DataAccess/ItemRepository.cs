using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.DataAccess
{
    public class ItemRepository : IItemRepository
    {
        private static List<Item> _items = new List<Item>();

        static ItemRepository()
        {
            _items.Add(Item.Create("write email to my friend"));
            _items.Add(Item.Create("call vet to schedule visit for my pet"));
        }

        public void AddItem(Item item)
        {
            if (item == null)
                return;

            _items.Add(item);
        }

        public List<Item> GetAllItems() // TODO: bool all or no-completed 
        {
            return _items;
        }

        public Item GetById(Guid id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }

        public void UpdateItem(Item item)
        {
            if (item == null)
                return;

            var myItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (myItem != null)
            {
                myItem.Description = item.Description;
                myItem.IsDone = item.IsDone;
                myItem.Completed =
                        item.IsDone == true
                        ? new Nullable<DateTime>(DateTime.Now)
                        : null;
            }
        }
    }
}
