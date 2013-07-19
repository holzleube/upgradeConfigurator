using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.ViewModel.ViewDataElements;

namespace AirbusCatalogue.Sample
{
    public class CompleteSampleDataItem:BasicDataItem
    {
        public CompleteSampleDataItem(DataGroup @group)
            : base("Id", "Titel", "/Assets/upgrades/jackPanel.jpg", @group, 55, 40)
        {
        }

        public string Name
        {
            get
            {
                return "Name alternative boomset - Telex boomset headphones";
            }
        }
        public string Description
        {
            get
            {
                return "This is a Description Text";
            }
        }
        public string ProductImagePath
        {
            get
            {
                return "/Assets/upgrades/jackPanel.jpg";
            }
        }
        public int CountOfNewTdus
        {
            get
            {
                return 4;
            }
        }
    }
}
