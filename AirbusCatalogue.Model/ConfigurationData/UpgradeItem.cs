using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class UpgradeItem : Identable
    {
        public UpgradeItem(string uniqueId, string name, string description, string imagePath, int priority)
        {
            UniqueId = uniqueId;
            Name = name;
            Description = description;
            ProductImagePath = imagePath;
            Priority = priority;
        }

        public string Name { get; set; }

        public string AtaSubchapterId { get; set; }

        public string ProductImagePath { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }
    }
}
