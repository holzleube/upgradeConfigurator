using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common;
using AirbusCatalogue.Data;

namespace AirbusCatalogue.DataModel
{
    public class HubPageDataItem : SampleDataItem
    {
        public HubPageDataItem(String uniqueId, String title, String subtitle, String imagePath, String description, String content, SampleDataGroup group)
            : base(uniqueId, title, subtitle, imagePath, description, content, group)
        {
            
        }

        private int _ColSpan = 1;
        public int ColSpan
        {
            get { return this._ColSpan; }
            set { this.SetProperty(ref this._ColSpan, value); }
        }

        private int _RowSpan = 1;
        public int RowSpan
        {
            get { return this._RowSpan; }
            set { this.SetProperty(ref this._RowSpan, value); }
        }
    }
}
