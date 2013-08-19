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

        [DataMember]
        public string UniqueId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ProductImagePath { get; set; }

        [DataMember]
        public string SellerImagePath { get; set; }

        [DataMember]
        public int Priority { get; set; }

        [DataMember]
        public int TduNumber { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }


        /// <summary>
        /// This overridden method is necessary for comparing the items and reselect them in upgradeSelectionView.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
