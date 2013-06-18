using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Data;

namespace AirbusCatalogue.DataModel
{
    class HubDataGroup : SampleDataGroup
    {
        public HubDataGroup(string uniqueId, string title, string subtitle, string imagePath, string description) : base(uniqueId, title, subtitle, imagePath, description)
        {
        }
    }
}
