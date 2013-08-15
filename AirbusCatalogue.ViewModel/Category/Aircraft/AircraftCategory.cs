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
