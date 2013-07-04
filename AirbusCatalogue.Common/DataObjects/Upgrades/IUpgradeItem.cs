using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Common.DataObjects.Upgrades
{
    public interface IUpgradeItem: IIdentable, INameable
    {
        string Description { get; set; }

        string ProductImagePath { get; set; }

        string SellerImagePath { get; set; }

        int Priority { get; set; }

        int TduNumber { get; set; }

        bool IsDefault { get; set; }
    }
}
