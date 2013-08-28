using System.Collections.Generic;
using System.Collections.ObjectModel;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using GalaSoft.MvvmLight.Ioc;
using AirbusCatalogue.Model.Repository;

namespace AirbusCatalogue.Model.Upgrades
{
    public class UpgradeModel
    {
        private IUpgradeRepository _upgradeRepository;
        public UpgradeModel()
        {
            _upgradeRepository = SimpleIoc.Default.GetInstance<IUpgradeRepository>();
        }
        public List<IUpgradeType> GetAllUpgradeTypes()
        {
            var result = new List<IUpgradeType>
                {
                    new UpgradeType("cabinUpgrade", "Cabin"),
                    new UpgradeType("systemUpgrade", "System"),
                    new UpgradeType("engineUpgrade", "Engines"),
                    new UpgradeType("fuselageUpgrade", "Fuselage")
                };
            return result;
        }

        public IUpgradeType GetUpgradeTypeById(string uniqueId)
        {
            if (uniqueId.Equals("cabin"))
            {
                var cabinChapters = new List<IAtaChapter>
                {
                    new AtaChapter("autoFlightAta", "Auto flight", 22, "Cockpit"),
                    new AtaChapter("communicationAta", "Communications", 23, "Cockpit"),
                    new AtaChapter("electricalPowerAta", "Electrical Power", 24, "Cockpit"),
                    new AtaChapter("equipmentAta", "Equipment/furnishings", 25, "Cockpit"),
                    new AtaChapter("fireProtectionAta", "Fire protection", 26, "Cockpit"),
                    new AtaChapter("fuelSystemsAta", "Fuel", 28, "Complete"),
                    new AtaChapter("navigationAta", "Navigation", 34, "Cockpit"),
                    new AtaChapter("oxygenAta", "Oxygen", 35, "Cockpit"),
                    new AtaChapter("windowsAta", "Windows", 56, "Cockpit"),
                    new AtaChapter("landingGearAta", "Landing gear", 32, "Complete"),
                    new AtaChapter("waterWasteAta", "Water/Waste", 38, "Complete"),
                    new AtaChapter("structuresAta", "Structures", 51, "Complete"),
                    new AtaChapter("doorsAta", "Doors", 52, "Complete"),
                    new AtaChapter("stabilizersAta", "Stabilizers", 55, "Complete"),
                    new AtaChapter("wingsAta", "Wings", 57, "Complete")
                };
                return new UpgradeType("cabinUpgrade", "Cabin", cabinChapters);
            }
            var ataChapters = new List<IAtaChapter>
                {
                    new AtaChapter("autoFlightAta", "Auto flight", 22, "Cockpit"),
                    new AtaChapter("communicationAta", "Communications", 23, "Cockpit"),
                    new AtaChapter("electricalPowerAta", "Electrical Power", 24, "Cockpit"),
                    new AtaChapter("equipmentAta", "Equipment/furnishings", 25, "Cockpit"),
                    new AtaChapter("fireProtectionAta", "Fire protection", 26, "Cockpit"),
                    new AtaChapter("fuelSystemsAta", "Fuel", 28, "Complete"),
                    new AtaChapter("navigationAta", "Navigation", 34, "Cockpit"),
                    new AtaChapter("oxygenAta", "Oxygen", 35, "Cockpit"),
                    new AtaChapter("windowsAta", "Windows", 56, "Cockpit"),
                    new AtaChapter("landingGearAta", "Landing gear", 32, "Complete"),
                    new AtaChapter("waterWasteAta", "Water/Waste", 38, "Complete"),
                    new AtaChapter("structuresAta", "Structures", 51, "Complete"),
                    new AtaChapter("doorsAta", "Doors", 52, "Complete"),
                    new AtaChapter("stabilizersAta", "Stabilizers", 55, "Complete"),
                    new AtaChapter("wingsAta", "Wings", 57, "Complete")
                };
            return new UpgradeType("systemUpgrade", "System", ataChapters);
        }

        public IAtaChapter GetAtaChapterById(string uniqueId)
        {

            var subAtaChapters = new List<ISubAtaChapter>
                {
                    new SubAtaChapter("11.116", "Installation of singe HF system (SFE)", 11, 116,
                                      "To install one HF system for voide communication in areas outside VHF coverage",
                                      "space provisions is made for single HF communication transceivers",
                                      "The modification consists of: ", "Individual", GetUpgradesFromRepoById(new List<string>(){"1046GT2103", "1046GT2104"})),
                    new SubAtaChapter("11.131", "Installation of single HF system and full provision for second one (SFE)",
                                      11, 131, "To install single HF system, with full provision for a secone one",
                                      "space provisions is made for dual HF communication transceivers",
                                      "The modification consists of: ", "Individual", GetUpgradesFromRepoById(new List<string>(){"1046GT2105", "1046GT2106"})),
                    new SubAtaChapter("13.100", "Installation of alternate Radio Management Panel (RMP)", 13, 100,
                                      "To provide alternate Radio Managment Panels",
                                      "The basic aircraft is equipped with two RMPs installed on the center pedestal",
                                      "The basic RMPs are replaced by alternate euqipment", "Individual", GetUpgradesFromRepoById(new List<string>(){"1046GT2107", "1046GT2108","1046GT2109"})),
                    new SubAtaChapter("50.110", "Installation of additional Audio Control Panel (ACP) and jack panel", 50,110,
                                      "To provide provision for two-way communication for a fourth occupant and/or additional communication capability in the avoinics compartment for maintenance purposes",
                                      "Three audio control panels for the Captain, the First Officer, and the thid occupant",
                                      "For the installation of an ACP for the fourth occupant the modification consists of:",
                                      "Individual", GetUpgradesFromRepoById(new List<string>(){"1046GT2110", "1046GT2111","1046GT2112"})),
                    new SubAtaChapter("51.136", "Boomsets alternate equipment", 51, 136,
                                      "To provide alternate equipment for boomsets",
                                      "two jack panels, one for the Captaion and one for the First Officer, each with two connectors, one at each pilots station",
                                      "The basic boomsets are replaced by alternate equipment complying with ARINC 535A and 538B specifications",
                                      "Individual", GetUpgradesFromRepoById(new List<string>(){"CN23.51.136-27","CN23.51.136-30"})),
                    new SubAtaChapter("51.136", "Boomsets alternate equipment with two jack plugs", 51, 139,
                                      "To provide alternate equipment for boomsets",
                                      "two jack panels, one for the Captaion and one for the First Officer, each with two connectors, one at each pilots station",
                                      "The basic boomsets are replaced by alternate equipment complying with ARINC 535A and 538B specifications",
                                      "Individual", GetUpgradesFromRepoById(new List<string>(){"1046GT2116", "1046GT2117"}))
                };
            IAtaChapter chapter = new AtaChapter("communicationAta", "Communications", 23, subAtaChapters, "Cockpit");
            return chapter;
        }
        private List<IUpgradeItem> GetUpgradesFromRepoById(List<string> idList)
        {
            var result = new List<IUpgradeItem>();
            foreach (var id in idList)
            {
              result.Add(_upgradeRepository.GetUpgradeItemById(id));
            }
            return result;
        }

        public void SelectUpgradeItem(IUpgradeItem upgradeItem)
        {
            var currentConfiguration = GetCurrentConfiguration();
            currentConfiguration.Upgrades.Add(upgradeItem);
            currentConfiguration.HasConfigurationChanged = true;
        }

        public void SelectUpgradeItem(List<IUpgradeItem> selectedUpgradeItems)
        {
            var currentConfiguration = GetCurrentConfiguration();
            foreach (var selectedUpgradeItem in selectedUpgradeItems)
            {
                if (currentConfiguration.Upgrades.Contains(selectedUpgradeItem))
                {
                    continue;
                }
                currentConfiguration.Upgrades.Add(selectedUpgradeItem);
                currentConfiguration.HasConfigurationChanged = true;
            }
        }

        private static IConfiguration GetCurrentConfiguration()
        {
            return SimpleIoc.Default.GetInstance<IConfiguration>();
        }

        public List<IUpgradeArea> GetUpgradeAreasByDeck(string deckName)
        {
            if (deckName.Equals("mainDeck"))
            {
                return new List<IUpgradeArea>
                {
                    new UpgradeArea("firstArea", "Zone 1",11, "/Assets/cabin/zones/zone_a.png"),
                    new UpgradeArea("secondArea", "Zone 2",11, "/Assets/cabin/zones/zone_b.png"),
                    new UpgradeArea("thirdArea", "Zone 3",6, "/Assets/cabin/zones/zone_c.png"),
                    new UpgradeArea("fourthArea", "Zone 4",15, "/Assets/cabin/zones/zone_d.png"),
                    new UpgradeArea("fifthArea", "Zone 5",4, "/Assets/cabin/zones/zone_e.png"),
                    new UpgradeArea("sixthArea", "Zone 6",13, "/Assets/cabin/zones/zone_f.png"),
                    new UpgradeArea("eightArea", "Zone 7",4, "/Assets/cabin/zones/zone_g.png"),
                    new UpgradeArea("ninthArea", "Zone 8",9, "/Assets/cabin/zones/zone_h.png"),
                    new UpgradeArea("tenthArea", "Zone 9",6, "/Assets/cabin/zones/zone_i.png")
                };
                    
            }
            return new List<IUpgradeArea>
                {
                    new UpgradeArea("firstArea", "Zone 10",6, "/Assets/cabin/zones/zone_j.png"),
                    new UpgradeArea("secondArea", "Zone 11",9, "/Assets/cabin/zones/zone_k.png"),
                    new UpgradeArea("thirdArea", "Zone 12",10, "/Assets/cabin/zones/zone_l.png"),
                    new UpgradeArea("fourthArea", "Zone 13",17, "/Assets/cabin/zones/zone_m.png"),
                    new UpgradeArea("fifthArea", "Zone 14",6, "/Assets/cabin/zones/zone_n.png"),
                    new UpgradeArea("fifthArea", "Zone 15",8, "/Assets/cabin/zones/zone_o.png"),
                    new UpgradeArea("sixthArea", "Zone 16",12, "/Assets/cabin/zones/zone_p.png")
                };
        }

        public List<IUpgradeItem> GetUpgradeItemsByArea(List<IUpgradeArea> zones)
        {
            return GetUpgradesFromRepoById(new List<string>(){"CN33.21.136-01", "CN33.21.136-02"});
        }
    }
}
