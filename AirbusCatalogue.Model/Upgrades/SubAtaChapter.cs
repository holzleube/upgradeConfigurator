using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.Model.Upgrades
{
    public class SubAtaChapter:ISubAtaChapter
    {
        public SubAtaChapter(string id, string name, int ataChapterNumber, int subAtaChapterSecondNumber, string objective, string basicAircraft, string description, string epacSelection)
        {
            UniqueId = id;
            Name = name;
            SubAtaChapterNumber = ataChapterNumber;
            SubAtaChapterSecondNumber = subAtaChapterSecondNumber;
            Objective = objective;
            BasicAircraft = basicAircraft;
            Description = description;
            EpacSelectionMode = epacSelection;
        }

        public SubAtaChapter(string id, string name, int ataChapterNumber, int subAtaChapterSecondNumber, string objective, string basicAircraft, string description, string epacSelection, List<IUpgradeItem> upgradeItems):this(id,name,ataChapterNumber, subAtaChapterSecondNumber,objective,basicAircraft,description,epacSelection)
        {
            UpgradeItems = upgradeItems;
        }

        public string Name { get; set; }

        public string UniqueId { get; set; }

        public int SubAtaChapterNumber { get; set; }

        public int SubAtaChapterSecondNumber { get; set; }

        public string Objective { get; set; }

        public string BasicAircraft { get; set; }

        public string Description { get; set; }

        public string EpacSelectionMode { get; set; }

        public List<IUpgradeItem> UpgradeItems { get; set; }
    }
}
