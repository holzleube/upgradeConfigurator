using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.ViewModel.Category.Aircraft.Criterias;
using AirbusCatalogue.ViewModel.Category.Aircraft.Interfaces;

namespace AirbusCatalogue.ViewModel.Category.Aircraft
{
    public class AircraftCategoryFactory
    {
        public List<IAircraftCategory> CreateAircraftCategories()
        {
            var result = new List<IAircraftCategory>
                {
                    new AircraftCategory("version", new AircraftVersionCategoryCriteria()),
                    new AircraftCategory("aircraft type", new AircraftTypeCategoryCriteria())
                };
            return result;
        } 
    }
}
