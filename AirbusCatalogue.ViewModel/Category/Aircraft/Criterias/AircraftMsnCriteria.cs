using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.ViewModel.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.Category.Aircraft.Criterias
{
    /// <summary>
    /// This criteria groups the Aircrafts in AircraftSelection by the msn number. 
    /// It groups the aircrafts in group of 1000.
    /// </summary>
    public class AircraftMsnCriteria : ICategoryCriteria<IAircraft>
    {
        public string GetFilterValue(IAircraft typeToCategorize)
        {
            int category = (typeToCategorize.MsnNumber / 1000)*1000;
            return category.ToString() ;
        }
    }
}
