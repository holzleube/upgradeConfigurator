using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.Model.Upgrades
{
    [DataContract]
    public class UpgradeItem:IUpgradeItem
    {

        public UpgradeItem(string id, string name, string description, string productImage, string sellerLogo, int tduNumber, int priority, bool isDefault)
        {
            SellerImagePath = sellerLogo;
            TduNumber = tduNumber;
            UniqueId = id;
            Name = name;
            Description = description;
            ProductImagePath = productImage;
            Priority = priority;
            IsDefault = isDefault;
        }

        public string UniqueId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProductImagePath { get; set; }

        public string SellerImagePath { get; set; }

        public int Priority { get; set; }

        public int TduNumber { get; set; }

        public bool IsDefault { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as UpgradeItem;
            if (item == null)
            {
                return false;
            }
            return item.UniqueId.Equals(UniqueId);
        }
    }
}
