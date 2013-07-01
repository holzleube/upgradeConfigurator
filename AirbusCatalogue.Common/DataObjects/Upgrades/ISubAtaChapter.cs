using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Common.DataObjects.Upgrades
{
    public interface ISubAtaChapter: INameable, IIdentable
    {
        int SubAtaChapterNumber { get; set; }

        int SubAtaChapterSecondNumber { get; set; }

        string Objective { get; set; }

        string BasicAircraft { get; set; }

        string Description { get; set; }

        string EpacSelectionMode { get; set; }

        List<IUpgradeItem> UpgradeItems { get; set; }
    }
}
