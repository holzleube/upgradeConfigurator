using System.Runtime.Serialization;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Common.DataObjects.Upgrades
{
    public interface IUpgradeItem: IIdentable, INameable
    {
        [DataMember]
        string Description { get; set; }

        [DataMember]
        string ProductImagePath { get; set; }

        [DataMember]
        string SellerImagePath { get; set; }

        [DataMember]
        int Priority { get; set; }

        [DataMember]
        int TduNumber { get; set; }

        [DataMember]
        bool IsDefault { get; set; }
    }
}
