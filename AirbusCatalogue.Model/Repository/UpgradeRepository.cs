using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Upgrades;

namespace AirbusCatalogue.Model.Repository
{
    public class UpgradeRepository : IUpgradeRepository
    {
        private Dictionary<string, IUpgradeItem> _dataMap;

        public UpgradeRepository()
        {
            InitializeDataMap();
        }

        private void InitializeDataMap()
        {
            _dataMap = new Dictionary<string, IUpgradeItem>
                {
                    {
                        "CN23.50.110-22",
                        new UpgradeItem("CN23.50.110-22", "Alternative Jack Panel",
                                        "Installation of ACP for fourth occupant and ACP and jack panel in avionics compartment",
                                        "/Assets/upgrades/jackPanel.jpg", "", 22, 0, false)
                    },
                    {
                        "CN23.50.110-23",
                        new UpgradeItem("CN23.50.110-23", "Alternative Jack Panel",
                                        "Installation of ACP for fourth occupant and ACP and jack panel in avionics compartment",
                                        "/Assets/upgrades/jackPanel.jpg", "", 23, 0, false)
                    },
                    {
                        "CN23.51.136-27", new UpgradeItem("CN23.51.136-27", "Boomset alternate equipment - Telex",
                                                          "DC resistance, soft ear cushions, 70-inch straight cord",
                                                          "/Assets/upgrades/telex_headphone.png",
                                                          "/Assets/upgrades/telex_logo.png", 27, 0, false)
                    },
                    {
                        "CN23.51.136-30", new UpgradeItem("CN23.51.136-30", "Boomset alternate equipment - Sennheiser",
                                                          "DC resistance, soft ear cushions, 70-inch straight cord",
                                                          "/Assets/upgrades/sennheiser_headphone.png",
                                                          "/Assets/upgrades/sennheiser_logo.png", 30, 0, false)
                    },
                    {
                        "CN23.51.136-00", new UpgradeItem("1046GT2102", "Boomset basic equipment - Holmberg",
                                                          "DC resistance, soft ear cushions, 70-inch straight cord",
                                                          "/Assets/upgrades/holmberg_headphone.png",
                                                          "/Assets/upgrades/holmberg_logo.jpg", 0, 0, true)
                    },
                    {
                        "1046GT2103", new UpgradeItem("1046GT2103", "Single HF system - Rockwell Collins 900",
                                                      "HF - Antenna, HFDR antenna coupler, HFDR transceiver",
                                                      "/Assets/upgrades/rockwell.png", "", 116, 02, false)
                    },
                    {
                        "1046GT2104", new UpgradeItem("1046GT2104", "Single HF system - Honeywell",
                                                      "HF - Antenna (Airbus), HFDR antenna coupler, HFDR transceiver",
                                                      "/Assets/upgrades/rockwell.png",
                                                      "", 116, 05, false)
                    },
                    {
                        "1046GT2105",
                        new UpgradeItem("1046GT2105", "Single HF system & full Provision - Rockwell Collins 900",
                                        "HF - Antenna, HFDR antenna coupler, HFDR transceiver",
                                        "/Assets/upgrades/rockwell.png", "", 116, 02, false)
                    },
                    {
                        "1046GT2106", new UpgradeItem("1046GT2106", "Single HF system & full Provision - Honeywell",
                                                      "HF - Antenna, HFDR antenna coupler, HFDR transceiver",
                                                      "/Assets/upgrades/rockwell.png",
                                                      "", 116, 05, false)
                    },
                    {
                        "1046GT2107", new UpgradeItem("1046GT2107", "Basic equip. with turbo tuning & HF data activation capab.",
                                    "Radio Management Panel - Thales Avionics SA",
                                    "/Assets/upgrades/rmp.jpg", "", 100,00, true)
                    },
                    {
                        "1046GT2108", new UpgradeItem("1046GT2108", "Alternate equip. with turbo tuning & HF data activation capab.",
                                    "Radio Management Panel - Thales Avionics SA",
                                    "/Assets/upgrades/rmp.jpg", "", 100,03, false)
                    },
                    {
                        "1046GT2109", new UpgradeItem("1046GT2109", "Alternate equip. - with CPDLC function capability",
                                    "Radio Management Panel - Thales Avionics SA",
                                    "/Assets/upgrades/rmp.jpg", "", 100,04, false)
                    },
                    {
                        "1046GT2110", new UpgradeItem("1046GT2110", "Installation of ACP for fourth occupant - T.E.A.M.",
                                    "Audio Control Panel (ACP) - Audio Management Unit (AMU)",
                                    "/Assets/upgrades/jackPanel.jpg", "", 110,21, false)
                    },
                    {
                        "1046GT2111", new UpgradeItem("1046GT2111", "Installation of ACP and jack panel in avionics compartment - T.E.A.M.",
                                    "Audio Control Panel (ACP) - Audio Management Unit (AMU)",
                                    "/Assets/upgrades/jackPanel.jpg", "", 110,21, false)
                    },
                    {
                        "1046GT2112", new UpgradeItem("1046GT2112", "Installation of ACP for fourth occupant and ACP and jack panel in avionics compartment - T.E.A.M.",
                                    "Audio Control Panel (ACP) - Audio Management Unit (AMU)",
                                    "/Assets/upgrades/jackPanel.jpg", "", 110,21, false)
                    },
                    {
                        "1046GT2113", new UpgradeItem("1046GT2113", "Boomset basic equipment - Holmberg",
                                    "DC resistance, soft ear cushions, 70-inch straight cord",
                                    "/Assets/upgrades/holmberg_headphone.png", "/Assets/upgrades/holmberg_logo.jpg", 0,0, true)
                    },
                    {
                        "1046GT2114", new UpgradeItem("1046GT2114", "Boomset alternate equipment - Telex",
                                    "DC resistance, soft ear cushions, 70-inch straight cord", "/Assets/upgrades/telex_headphone.png",
                                    "/Assets/upgrades/telex_logo.png", 27,0, false)
                    },
                    {
                        "al", new UpgradeItem("al","Ambient Light","perfect Ambilight","Assets/upgrades/ambient.jpg","", 10,1, false)
                    },
                    {
                        "bt", new UpgradeItem("bt","bridgestone tyres","new bridgestone tyres","Assets/upgrades/bridgestone.jpg","",24, 3, false)
                    },
                    {
                        "CN33.21.136-01", new UpgradeItem("CN33.21.136-01","RGB-LED full colored lighting","The basic single integrated ballast unit is replaced by a hybrid LED-white fluorescent tube ballast unit.","/Assets/cabin/blue_light.jpg","", 33,1, false)
                    },
                    {
                        "CN33.21.136-02", new UpgradeItem("CN33.21.136-02","Fluorescent tube colored lighting","The basic single integrated ballast unit is replaced by double integrated ballast units (with one white fluorescent tube).","/Assets/cabin/ambient.jpg","", 33,2, false)
                    },
                    {
                        "isisId", new UpgradeItem("isisId","isis display","the isis cockpit display","Assets/upgrades/isis.jpg","",24,3, false)
                    },
                    {
                        "1046GT2116", new UpgradeItem("1046GT2116", "Boomset alternate equipment with two jack plugs - Telex",
                                    "DC resistance, soft ear cushions, 70-inch straight cord", "/Assets/upgrades/telex_headphone.png",
                                    "/Assets/upgrades/telex_logo.png", 27,0, false)
                    },
                    {
                        "1046GT2117",
                    new UpgradeItem("1046GT2117", "Boomset alternate equipment with two jack plugs - Sennheiser",
                                    "DC resistance, soft ear cushions, 70-inch straight cord", "/Assets/upgrades/sennheiser_headphone.png",
                                    "/Assets/upgrades/sennheiser_logo.png", 30,0, false)
                                    }
                    
                };
        }

                    

        public IUpgradeItem GetUpgradeItemById(string uniqueId)
        {
            return _dataMap[uniqueId];
        }
    }
}
