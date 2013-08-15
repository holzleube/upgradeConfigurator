using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.ViewModel.Filter;

namespace AirbusCatalogue.ViewModel.Category.Aircraft.Interfaces
{
    /// <summary>
    /// This interface is used as a data element for the category list view in aircraft selection.
    /// </summary>
    public interface IAircraftCategory
    {
        string CategoryName { get; set; }

        ICategoryCriteria<IAircraft> CategoryCriteria { get; set; } 
    }
}
