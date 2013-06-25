using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Aircrafts;

namespace AirbusCatalogue.ViewModel.ViewDataElements
{
    public class AircraftProgrammGroup : DataGroup
    {
        public AircraftProgrammGroup(IEnumerable<AircraftProgramm> allAircrafts) : base("aircraftProgrammes", "", "")
        {
            foreach (var aircraftProgramm in allAircrafts)
            {
                Items.Add(new BasicDataItem(aircraftProgramm.UniqueId, aircraftProgramm.Name, aircraftProgramm.ImagePath, this, 60, 80));
            }
        }
    }
}
