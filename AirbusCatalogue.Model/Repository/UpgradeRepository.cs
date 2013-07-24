using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Upgrades;

namespace AirbusCatalogue.Model.Repository
{
    public class UpgradeRepository
    {
        private Dictionary<string, IUpgradeItem> _dataMap;

        public UpgradeRepository()
        {
            InitializeDataMap();
        }

        private void InitializeDataMap()
        {
            _dataMap = new Dictionary<string, IUpgradeItem>();
            _dataMap.Add("CN23.50.110-22", new UpgradeItem("CN23.50.110-22", "Alternative Jack Panel", "Installation of ACP for fourth occupant and ACP and jack panel in avionics compartment", "/Assets/upgrades/jackPanel.jpg", "", 22, 0, false));
            _dataMap.Add("CN23.50.110-23", new UpgradeItem("CN23.50.110-23", "Alternative Jack Panel", "Installation of ACP for fourth occupant and ACP and jack panel in avionics compartment", "/Assets/upgrades/jackPanel.jpg", "", 23, 0, false));
            _dataMap.Add("CN23.51.136-27", new UpgradeItem("CN23.51.136-27", "Boomset alternate equipment - Telex",
                                    "DC resistance, soft ear cushions, 70-inch straight cord", "/Assets/upgrades/telex_headphone.png",
                                    "/Assets/upgrades/telex_logo.png", 27,0, false));
            _dataMap.Add("CN23.51.136-30",  new UpgradeItem("CN23.51.136-30", "Boomset alternate equipment - Sennheiser",
                                    "DC resistance, soft ear cushions, 70-inch straight cord", "/Assets/upgrades/sennheiser_headphone.png",
                                    "/Assets/upgrades/sennheiser_logo.png", 30,0, false));
            _dataMap.Add("CN23.51.136-00",   new UpgradeItem("1046GT2102", "Boomset basic equipment - Holmberg",
                                    "DC resistance, soft ear cushions, 70-inch straight cord",
                                    "/Assets/upgrades/holmberg_headphone.png", "/Assets/upgrades/holmberg_logo.jpg", 0,0, true));
        }

        public IUpgradeItem GetUpgradeItemById(string uniqueId)
        {
            return _dataMap[uniqueId];
        }
    }
}
