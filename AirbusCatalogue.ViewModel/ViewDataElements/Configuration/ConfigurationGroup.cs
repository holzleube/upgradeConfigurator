using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Configuration
{
    public class ConfigurationGroup : DataGroup
    {
        public ConfigurationGroup(string uniqueId, string title, string iconValue) : base(uniqueId, title, "")
        {
            ImageContent = iconValue;
        }

        public string ImageContent { get; set; }
    }
}
