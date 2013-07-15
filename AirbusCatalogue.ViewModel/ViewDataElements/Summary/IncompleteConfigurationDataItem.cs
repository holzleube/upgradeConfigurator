using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Summary
{
    public class IncompleteConfigurationDataItem: BasicDataItem
    {
        public IncompleteConfigurationDataItem(DataGroup @group) : base("NoConfigDataItem", "No Configuration possible please select aircraft and upgrade", "", @group, 55, 40)
        {
        }
    }
}
