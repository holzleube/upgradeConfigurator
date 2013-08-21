using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Aircraft
{
    /// <summary>
    /// This dataElement holds a 
    /// </summary>
    public class AircraftProgrammDataItem: BasicDataItem
    {
       
        public AircraftProgrammDataItem(string uniqueId, IAircraftProgramm programm, DataGroup @group, int rowSpan, int colSpan)
            : base(uniqueId, programm.Name, programm.ImagePath, @group, rowSpan, colSpan)
        {
            Name = programm.Name;
            ImagePath = programm.ImagePath;

        }

        public string Name { get; set; }

        public string ImagePath { get; set; }

    }
}
