using MotoApp.Entities;

namespace MotoApp.Repositories
{
    internal class GenericRepositoryWithRemove<T, Tkey> : GenericRepository<T, Tkey> where T : IEntity
    {
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
}
