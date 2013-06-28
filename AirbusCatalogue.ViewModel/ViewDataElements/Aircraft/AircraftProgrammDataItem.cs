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
        public AircraftProgrammDataItem(IAircraftProgramm programm, DataGroup @group) : base(programm.UniqueId, programm.Name, programm.ImagePath, @group, 60, 80)
        {
        }
    }
}
