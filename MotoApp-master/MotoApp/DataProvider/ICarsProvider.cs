using MotoApp.Entities;

namespace MotoApp.DataProvider
{
    public interface ICarsProvider
    {
        // select
        List<string> GetUniqueCarColors();
        decimal GetMinimumPriceOfAllCars();
        List<Car> GetSpicificColumns();
        string AnonymousClass();
        // order by

    }
}
