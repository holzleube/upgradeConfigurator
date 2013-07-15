using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Summary
{
    /// <summary>
    /// This Data Item is used when model is configuring. It shows a small loading animation and will be reset
    /// if the configuration has finished
    /// </summary>
    public class ConfigureDataItem: BasicDataItem
    {
        public ConfigureDataItem(DataGroup @group) : base("configureDataItem", "configure...", "", @group, 55, 40)
        {
        }
    }
}
