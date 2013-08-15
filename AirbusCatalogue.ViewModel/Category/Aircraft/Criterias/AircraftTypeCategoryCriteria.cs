using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.ViewModel.Filter;

namespace AirbusCatalogue.ViewModel.Category.Aircraft.Criterias
{
    /// <summary>
    /// This criteria groups the aircrafts with aircraft type like A320 or A319 ...
    /// </summary>
    public class AircraftTypeCategoryCriteria: ICategoryCriteria<IAircraft>
    {
        public string GetFilterValue(IAircraft typeToCategorize)
        {
            return typeToCategorize.AircraftType;
        }
    }
}
