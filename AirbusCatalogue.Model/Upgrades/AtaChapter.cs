using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.Model.Upgrades
{
    public class AtaChapter:IAtaChapter
    {
        public AtaChapter(string ataChapterId, string ataChapterName, int ataNumber)
        {
            UniqueId = ataChapterId;
            Name = ataChapterName;
            AtaChapterNumber = ataNumber;
        }

        public AtaChapter(string ataChapterId, string ataChapterName, int ataNumber, List<ISubAtaChapter> subAtaChapters): this(ataChapterId, ataChapterName, ataNumber)
        {
            SubAtaChapters = subAtaChapters;
        }

        public string UniqueId { get; set; }

        public string Name { get; set; }

        public int AtaChapterNumber { get; set; }

        public List<ISubAtaChapter> SubAtaChapters { get; set; }
    }
}
