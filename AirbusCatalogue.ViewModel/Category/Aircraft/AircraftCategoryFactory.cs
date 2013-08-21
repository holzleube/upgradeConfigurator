using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.ViewModel.Category.Aircraft.Criterias;
using AirbusCatalogue.ViewModel.Category.Aircraft.Interfaces;

namespace AirbusCatalogue.ViewModel.Category.Aircraft
{
    /// <summary>
    /// This factory creates all model objects for grouping the aircrafts in aircraft selection.
    /// If you want a new criteria you simply have to add it here.
    /// </summary>
    public class AircraftCategoryFactory
    {
        public List<IAircraftCategory> CreateAircraftCategories()
        {
            var result = new List<IAircraftCategory>
                {
                    new AircraftCategory("version", new AircraftVersionCategoryCriteria()),
                    new AircraftCategory("aircraft type", new AircraftTypeCategoryCriteria()),
                    new AircraftCategory("aircraft number", new AircraftMsnCriteria())
                };
            return result;
        } 
    }
}
