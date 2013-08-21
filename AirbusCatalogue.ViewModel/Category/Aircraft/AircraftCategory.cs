using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.ViewModel.Category.Aircraft.Interfaces;
using AirbusCatalogue.ViewModel.Filter;

namespace AirbusCatalogue.ViewModel.Category.Aircraft
{
    /// <summary>
    /// This category object is the model for the listbox in aircraft selection page. 
    /// It holds a name and the right criteria.
    /// </summary>
    public class AircraftCategory:IAircraftCategory
    {
        public AircraftCategory(string categoryName, ICategoryCriteria<IAircraft> aircraftCategoryCriteria)
        {
            CategoryName = categoryName;
            CategoryCriteria = aircraftCategoryCriteria;
        }
        public string CategoryName { get; set; }
        public ICategoryCriteria<IAircraft> CategoryCriteria { get; set; }
    }
}
