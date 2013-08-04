using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.Model.Templates;
using AirbusCatalogue.Model.Upgrades;

namespace AirbusCatalogue.Model.Customer
{
    public class CustomerInformation : Identable
    {
        public CustomerInformation(string uniqueId, List<Configuration> lastConfiguration, List<IUpgradeItem> newUpgrades,
                                   string customerLogoImagePath, string startPageImagePath) : base(uniqueId)
        {
            LastConfigurations = lastConfiguration;
            UpgradeRecommendations = newUpgrades;
            CustomerLogoImagePath = customerLogoImagePath;
            CustomerStartPageImagePath = startPageImagePath;
        }

        public List<Configuration> LastConfigurations { get; set; }

        public List<IUpgradeItem> UpgradeRecommendations { get; set; }

        public string CustomerLogoImagePath { get; set; }

        public string CustomerStartPageImagePath { get; set; }
    }

}
