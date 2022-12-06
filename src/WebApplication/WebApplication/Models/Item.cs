using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Item
    {
        //public int Id { get; set; }
        public Guid Id { get; private set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime Created { get; private set; }
        public DateTime? Completed { get; set; }

        public static Item Create(string description)
        {
            return new Item
            {
                Id = Guid.NewGuid(),
                Description = description,
                Created = DateTime.Now,
                Completed = null,
                IsDone = false,
            };
        }
    }
}
