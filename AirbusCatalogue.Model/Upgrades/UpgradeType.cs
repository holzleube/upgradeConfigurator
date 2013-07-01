using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using Windows.Foundation;

namespace AirbusCatalogue.Model.Upgrades
{
    public class UpgradeType: IUpgradeType
    {
        public UpgradeType(string id, string upgradeName)
        {
            UniqueId = id;
            Name = upgradeName;
        }

        public UpgradeType(string id, string upgradeName, List<IAtaChapter> ataChapters): this(id, upgradeName)
        {
            AtaChapters = ataChapters;
        }

        public string UniqueId { get; set; }

        public string Name { get; set; }

        public Point Position { get; set; }

        public List<IAtaChapter> AtaChapters { get; set; }
    }
}
