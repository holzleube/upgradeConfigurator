using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common;
using AirbusCatalogue.Data;

namespace AirbusCatalogue.DataModel
{
    public class HubPageDataItem : BasicDataItem
    {
        public HubPageDataItem(String uniqueId, String title, String imagePath, String description, String content, SampleDataGroup group)
            : base(uniqueId, title, imagePath, description, content, group, 64,111)
        {
            
        }
    }
}
