using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.ViewModel.Filter;

namespace AirbusCatalogue.ViewModel.Category.Aircraft.Criterias
{
    /// <summary>
    /// This criteria groups the Aircrafts in AircraftSelection by Version name like afr.
    /// </summary>
    public class AircraftVersionCategoryCriteria : ICategoryCriteria<IAircraft>
    {
        public string GetFilterValue(IAircraft typeToCategorize)
        {
            return typeToCategorize.Version;
        }
    }
}
