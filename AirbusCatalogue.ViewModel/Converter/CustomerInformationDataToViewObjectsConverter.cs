using System.Collections.ObjectModel;
using AirbusCatalogue.Model.Customer;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Configuration;
using AirbusCatalogue.ViewModel.ViewDataElements.Summary;
using AirbusCatalogue.ViewModel.ViewDataElements.Upgrades;

namespace AirbusCatalogue.ViewModel.Converter
{
    public class CustomerInformationDataToViewObjectsConverter
    {

        public ObservableCollection<DataCommon> GetConvertedElements(CustomerInformation customerInformation)
        {
            var convertedGroups = new ObservableCollection<DataCommon>();
            var group1 = new HubDataGroup("startPageHubData");
            var startScreenImage = new HubPageDataItem("startScreenImage",
                   customerInformation.CustomerStartPageImagePath
                   , group1);
            group1.Items.Add(startScreenImage);

            var group2 = new DataGroup("new upgrades",
                    "new upgrades",
                    "Assets/LightGray.png"
                   );
            foreach (var upgradeItem in customerInformation.UpgradeRecommendations)
            {
                BasicDataItem item;
                if (upgradeItem.Priority == 1)
                {
                    item = new NewUpgradeBigDataItem(upgradeItem, group2);
                }
                else
                {
                    item = new NewUpgradeSmallDataItem(upgradeItem, group2);
                }
                
                group2.Items.Add(item); 
            }

            
            var group3 = GetLastConfigurationsGroup(customerInformation);
            AddIfNotEmpty(convertedGroups, group1);
            AddIfNotEmpty(convertedGroups, group3);
            AddIfNotEmpty(convertedGroups, group2);
            return convertedGroups;
        }

        private static void AddIfNotEmpty(ObservableCollection<DataCommon> convertedGroups, DataGroup group1)
        {
            if (group1.Items.Count > 0)
            {
                convertedGroups.Add(group1);
            }
        }

        private static DataGroup GetLastConfigurationsGroup(CustomerInformation customerInformation)
        {
            var group3 = new DataGroup("last configurations",
                                       "last configurations",
                                       "Assets/LightGray.png");
            foreach (var configuration in customerInformation.LastConfigurations)
            {
                group3.Items.Add(new ConfigurationDataItem(configuration, group3));
            }
            return group3;
        }
    }
}
