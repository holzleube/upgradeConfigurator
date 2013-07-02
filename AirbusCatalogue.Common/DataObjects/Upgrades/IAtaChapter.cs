using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Common.DataObjects.Upgrades
{
    public interface IAtaChapter:IIdentable, INameable
    {
        int AtaChapterNumber { get; set; }

        List<ISubAtaChapter> SubAtaChapters { get; set; }

        string Category { get; set; }

    }
}
