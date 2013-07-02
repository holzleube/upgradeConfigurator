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
        public AtaChapter(string ataChapterId, string ataChapterName, int ataNumber, string category)
        {
            UniqueId = ataChapterId;
            Name = ataChapterName;
            AtaChapterNumber = ataNumber;
            Category = category;
        }

        public AtaChapter(string ataChapterId, string ataChapterName, int ataNumber, List<ISubAtaChapter> subAtaChapters, string category): this(ataChapterId, ataChapterName, ataNumber, category)
        {
            SubAtaChapters = subAtaChapters;
        }

        public string UniqueId { get; set; }

        public string Name { get; set; }

        public int AtaChapterNumber { get; set; }

        public List<ISubAtaChapter> SubAtaChapters { get; set; }

        public string Category { get; set; }
    }
}
