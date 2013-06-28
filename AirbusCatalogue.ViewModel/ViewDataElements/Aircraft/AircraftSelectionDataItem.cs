using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Aircraft
{
    public class AircraftSelectionDataItem : BasicDataItem
    {
        public AircraftSelectionDataItem(IAircraft aircraft, DataGroup @group)
            : this(aircraft, @group, 15, 20)
        {
        }

        public AircraftSelectionDataItem(IAircraft aircraft, DataGroup @group, int rowSpan, int colSpan)
            : base(aircraft.UniqueId, aircraft.Name, aircraft.ImagePath, @group, rowSpan, colSpan)
        {
            Version = aircraft.Version;
        }

        public string Version { get; set; }
 
    }
}
