using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Model.Aircrafts;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Aircraft
{
    public class AircraftTypeDataItem:BasicDataItem
    {
        public AircraftTypeDataItem(IAircraftType programm, DataGroup @group)
            : base(programm.UniqueId, programm.Name, programm.ImagePath, @group, 60, 80)
        {
            DataObject = programm;
        }

        public IAircraftType DataObject { get; set; }
    }
}
