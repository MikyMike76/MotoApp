using MotoApp.Entities;

namespace MotoApp.DataProvider
{
    public interface ICarsProvider
    {
        List<Car> FilterCars(decimal minPrice);
        List<string> GetUniqueCarColors();
        decimal GetMinimumPriceOfAllCars();
    }
}
