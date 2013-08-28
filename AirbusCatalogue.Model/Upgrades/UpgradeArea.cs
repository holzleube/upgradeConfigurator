using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Upgrades
{
    public class UpgradeArea: IUpgradeArea
    {

        public UpgradeArea(string id, string name, int colSpan, string imagePath)
        {
            UniqueId = id;
            Name = name;
            ColSpan = colSpan;
            ImagePath = imagePath;
        }

        public int ColSpan {get;set ; }

        public string UniqueId { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }
    }
}
