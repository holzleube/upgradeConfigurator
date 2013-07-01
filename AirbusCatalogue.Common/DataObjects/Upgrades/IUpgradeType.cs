using AirbusCatalogue.Common.DataObjects.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace AirbusCatalogue.Common.DataObjects.Upgrades
{
    public interface IUpgradeType: IIdentable, INameable
    {
        Point Position { get; set; }

        List<IAtaChapter> AtaChapters { get; set; } 
    }
}
