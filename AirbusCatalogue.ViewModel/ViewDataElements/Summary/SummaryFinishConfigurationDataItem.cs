using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Summary
{
    public class SummaryFinishConfigurationDataItem: BasicDataItem
    {
        public SummaryFinishConfigurationDataItem(string uniqueId, string title, string imagePath, DataGroup @group) : 
            base(uniqueId, title, imagePath, @group, 24, 24)
        {
            ImageContent = imagePath;
        }

        public string ImageContent { get; set; }
    }
}
