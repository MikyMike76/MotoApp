using MotoApp.Entities;

namespace MotoApp.DataProvider.Extensions
{
    public static class CarHelper
    {
        public static IEnumerable<Car> ByColor(this IEnumerable<Car> query, string color)
        {
            return query.Where(c => c.Color == color);
        }
    }
}
