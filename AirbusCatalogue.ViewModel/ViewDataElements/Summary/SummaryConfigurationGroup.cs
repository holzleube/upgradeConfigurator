using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Summary
{
    public class SummaryConfigurationGroup:DataGroup
    {
        public SummaryConfigurationGroup(string title, string imageContent)
            : base("summaryConfigurationGroup", title, "")
        {
            ImageContent = imageContent;
        }

        public string ImageContent { get; set; }
    }
}
