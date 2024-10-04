using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoApp.Entities;

namespace MotoApp.Repositories
{
    public class GenericRepository<T, Tkey> where T : IEntity
    {
        public Tkey? key { get; set; }
        protected readonly List<T> _items = new();
        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }
        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

    }
}
