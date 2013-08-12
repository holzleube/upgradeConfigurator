using System.Collections.Generic;
using System.Collections.ObjectModel;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.Model.Upgrades
{
    public class UpgradeModel
    {
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
                                      "The modification consists of: ", "Individual", GetHFUpgradeItems()),
                    new SubAtaChapter("11.131", "Installation of single HF system and full provision for second one (SFE)",
                                      11, 131, "To install single HF system, with full provision for a secone one",
                                      "space provisions is made for dual HF communication transceivers",
                                      "The modification consists of: ", "Individual", GetHFFullProvisionUpgradeItems()),
                    new SubAtaChapter("13.100", "Installation of alternate Radio Management Panel (RMP)", 13, 100,
                                      "To provide alternate Radio Managment Panels",
                                      "The basic aircraft is equipped with two RMPs installed on the center pedestal",
                                      "The basic RMPs are replaced by alternate euqipment", "Individual", GetRMPUpgradeItems()),
                    new SubAtaChapter("50.110", "Installation of additional Audio Control Panel (ACP) and jack panel", 50,110,
                                      "To provide provision for two-way communication for a fourth occupant and/or additional communication capability in the avoinics compartment for maintenance purposes",
                                      "Three audio control panels for the Captain, the First Officer, and the thid occupant",
                                      "For the installation of an ACP for the fourth occupant the modification consists of:",
                                      "Individual", GetJackPanelUpgrades()),
                    new SubAtaChapter("51.136", "Boomsets alternate equipment", 51, 136,
                                      "To provide alternate equipment for boomsets",
                                      "two jack panels, one for the Captaion and one for the First Officer, each with two connectors, one at each pilots station",
                                      "The basic boomsets are replaced by alternate equipment complying with ARINC 535A and 538B specifications",
                                      "Individual", GetUpgradeItems()),
                    new SubAtaChapter("51.136", "Boomsets alternate equipment with two jack plugs", 51, 139,
                                      "To provide alternate equipment for boomsets",
                                      "two jack panels, one for the Captaion and one for the First Officer, each with two connectors, one at each pilots station",
                                      "The basic boomsets are replaced by alternate equipment complying with ARINC 535A and 538B specifications",
                                      "Individual", GetJackUpgradeItems())
                };
            IAtaChapter chapter = new AtaChapter("communicationAta", "Communications", 23, subAtaChapters, "Cockpit");
            return chapter;
        }

        private List<IUpgradeItem> GetHFUpgradeItems()
        {
            return new List<IUpgradeItem>
                {
                    new UpgradeItem("1046GT2103", "Single HF system - Rockwell Collins 900",
                                    "HF - Antenna, HFDR antenna coupler, HFDR transceiver",
                                    "/Assets/upgrades/rockwell.png", "", 116,02, false),
                    new UpgradeItem("1046GT2104", "Single HF system - Honeywell",
                                    "HF - Antenna (Airbus), HFDR antenna coupler, HFDR transceiver", "/Assets/upgrades/rockwell.png",
                                    "", 116,05, false)
                };
        }
        private List<IUpgradeItem> GetHFFullProvisionUpgradeItems()
        {
            return new List<IUpgradeItem>
                {
                    new UpgradeItem("1046GT2105", "Single HF system & full Provision - Rockwell Collins 900",
                                    "HF - Antenna, HFDR antenna coupler, HFDR transceiver",
                                    "/Assets/upgrades/rockwell.png", "", 116,02, false),
                    new UpgradeItem("1046GT2106", "Single HF system & full Provision - Honeywell",
                                    "HF - Antenna, HFDR antenna coupler, HFDR transceiver", "/Assets/upgrades/rockwell.png",
                                    "", 116,05, false)
                };
        }

        private List<IUpgradeItem> GetRMPUpgradeItems()
        {
            return new List<IUpgradeItem>
                {
                    new UpgradeItem("1046GT2107", "Basic equip. with turbo tuning & HF data activation capab.",
                                    "Radio Management Panel - Thales Avionics SA",
                                    "/Assets/upgrades/rmp.jpg", "", 100,00, true),
                   new UpgradeItem("1046GT2108", "Alternate equip. with turbo tuning & HF data activation capab.",
                                    "Radio Management Panel - Thales Avionics SA",
                                    "/Assets/upgrades/rmp.jpg", "", 100,03, false),
                   new UpgradeItem("1046GT2109", "Alternate equip. - with CPDLC function capability",
                                    "Radio Management Panel - Thales Avionics SA",
                                    "/Assets/upgrades/rmp.jpg", "", 100,04, false)
                };
        }

        private List<IUpgradeItem> GetJackPanelUpgrades()
        {
            return new List<IUpgradeItem>
                {
                    new UpgradeItem("1046GT2110", "Installation of ACP for fourth occupant - T.E.A.M.",
                                    "Audio Control Panel (ACP) - Audio Management Unit (AMU)",
                                    "/Assets/upgrades/jackPanel.jpg", "", 110,21, false),
                    new UpgradeItem("1046GT2111", "Installation of ACP and jack panel in avionics compartment - T.E.A.M.",
                                    "Audio Control Panel (ACP) - Audio Management Unit (AMU)",
                                    "/Assets/upgrades/jackPanel.jpg", "", 110,21, false),
                    new UpgradeItem("1046GT2112", "Installation of ACP for fourth occupant and ACP and jack panel in avionics compartment - T.E.A.M.",
                                    "Audio Control Panel (ACP) - Audio Management Unit (AMU)",
                                    "/Assets/upgrades/jackPanel.jpg", "", 110,21, false),
                };
        }

       

        private static List<IUpgradeItem> GetUpgradeItems()
        {
            return new List<IUpgradeItem>
                {
                    new UpgradeItem("1046GT2113", "Boomset basic equipment - Holmberg",
                                    "DC resistance, soft ear cushions, 70-inch straight cord",
                                    "/Assets/upgrades/holmberg_headphone.png", "/Assets/upgrades/holmberg_logo.jpg", 0,0, true),
                    new UpgradeItem("1046GT2114", "Boomset alternate equipment - Telex",
                                    "DC resistance, soft ear cushions, 70-inch straight cord", "/Assets/upgrades/telex_headphone.png",
                                    "/Assets/upgrades/telex_logo.png", 27,0, false),
                    new UpgradeItem("1046GT2115", "Boomset alternate equipment - Sennheiser",
                                    "DC resistance, soft ear cushions, 70-inch straight cord", "/Assets/upgrades/sennheiser_headphone.png",
                                    "/Assets/upgrades/sennheiser_logo.png", 30,0, false)
                };
        }

        private static List<IUpgradeItem> GetJackUpgradeItems()
        {
            return new List<IUpgradeItem>
                {
                    new UpgradeItem("1046GT2116", "Boomset alternate equipment with two jack plugs - Telex",
                                    "DC resistance, soft ear cushions, 70-inch straight cord", "/Assets/upgrades/telex_headphone.png",
                                    "/Assets/upgrades/telex_logo.png", 27,0, false),
                    new UpgradeItem("1046GT2117", "Boomset alternate equipment with two jack plugs - Sennheiser",
                                    "DC resistance, soft ear cushions, 70-inch straight cord", "/Assets/upgrades/sennheiser_headphone.png",
                                    "/Assets/upgrades/sennheiser_logo.png", 30,0, false)
                };
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
    }
}
