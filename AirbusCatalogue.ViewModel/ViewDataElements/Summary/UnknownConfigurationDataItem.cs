using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Summary
{
    public class UnknownConfigurationDataItem:BasicDataItem
    {
        public UnknownConfigurationDataItem(DataGroup @group) : base("unknownConfiguration", "no configuration server available, please try again later", "", @group, 55, 40)
        {
            ImageContent = "\uE11B";
        }

        public string ImageContent { get; set; }
    }


}
