using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.ViewModel.Filter;

namespace AirbusCatalogue.ViewModel.Category.Aircraft.Criterias
{
    public class AircraftVersionCategoryCriteria : ICategoryCriteria<IAircraft>
    {
        public string GetFilterValue(IAircraft typeToCategorize)
        {
            return typeToCategorize.Version;
        }
    }
}
