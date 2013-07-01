using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.Model.Upgrades
{
    public class UpgradeItem:IUpgradeItem
    {
        public UpgradeItem(string id, string name, string description, string productImage, int priority)
        {
            UniqueId = id;
            Name = name;
            Description = description;
            ProductImagePath = productImage;
            Priority = priority;
        }

        public UpgradeItem(string id, string name, string description, string productImage, string sellerLogo, int tduNumber):this(id, name, description,productImage, 0)
        {
            SellerImagePath = sellerLogo;
            TduNumber = tduNumber;
        }

        public string UniqueId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProductImagePath { get; set; }

        public string SellerImagePath { get; set; }

        public int Priority { get; set; }

        public int TduNumber { get; set; }
    }
}
