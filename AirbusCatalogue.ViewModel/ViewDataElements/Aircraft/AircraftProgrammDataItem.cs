using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Aircraft
{
    public class AircraftProgrammDataItem: BasicDataItem
    {
        public AircraftProgrammDataItem(IAircraftProgramm programm, DataGroup @group) : this(programm, @group, 60, 80)
        {
        }
        public AircraftProgrammDataItem(IAircraftProgramm programm, DataGroup @group, int rowSpan, int colSpan)
            : base(programm.UniqueId, programm.Name, programm.ImagePath, @group, rowSpan, colSpan)
        {
            
        }

        public AircraftProgrammDataItem(DataGroup @group, int colspan , int rowSpan)
            : base("", "A320", "Assets/aircrafts/a320_transparent.png", @group,60,80)
        {
            
        }
    }
}
