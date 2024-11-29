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
        List<Car> OrderByName();
        List<Car> OrderByNameDescending();
        List<Car> OrderByColorAndName();
        List<Car> OrderByColorAndNameDesc();
        // where
        List<Car> WhereStartsWith(string prefix);
        List<Car> WhereStartsWithAndGreaterThan(string prefix, decimal cost);
        List<Car> WhereColorIs(string color);
        // first, last, single
        Car FirstByColor(string color);
        Car? FirstOrDefaultByColor(string color);
        Car FirstOrDefaultByColorWithDefault(string color);
        Car LastByColor(string color);
        Car SingleById(int id);
        Car? SingleOrDefaultById(int id);

    }
}
