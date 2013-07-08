using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Summary
{
    public class SummarySelectionDataItem:BasicDataItem
    {
        private int _itemCount;

        public SummarySelectionDataItem(string uniqueId, string title, string imagePath, DataGroup @group, int itemCount) : base(uniqueId, title, imagePath, @group, 30, 30)
        {
            _itemCount = itemCount;
            ImageContent = imagePath;
        }

        public string CountText
        {
            get
            {
                if (_itemCount == 0)
                {
                    return "no items selected";
                }
                return "count: " + _itemCount;
            }
        }

        public string ImageContent { get; set; }
    }
}
