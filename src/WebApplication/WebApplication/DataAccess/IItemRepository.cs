using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.DataAccess
{
    public interface IItemRepository
    {
        List<Item> GetAllItems();
        Item GetById(Guid id);
        void AddItem(Item item);
        void UpdateItem(Item item);

    }
}
