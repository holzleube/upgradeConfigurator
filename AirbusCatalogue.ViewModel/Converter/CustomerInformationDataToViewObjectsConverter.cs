using System.Collections.ObjectModel;
using AirbusCatalogue.Model.Customer;
using AirbusCatalogue.ViewModel.ViewDataElements;

namespace AirbusCatalogue.ViewModel.Converter
{
    public class CustomerInformationDataToViewObjectsConverter
    {

        public ObservableCollection<DataGroup> GetConvertedElements(CustomerInformation customerInformation)
        {
            var convertedGroups = new ObservableCollection<DataGroup>();
            var group1 = new HubDataGroup("startPageHubData");
            var startScreenImage = new HubPageDataItem("startScreenImage",
                   customerInformation.CustomerStartPageImagePath
                   , group1);
            group1.Items.Add(startScreenImage);

            var group2 = new DataGroup("new upgrades",
                    "new upgrades",
                    "Assets/LightGray.png",
                    "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante");
            foreach (var upgradeItem in customerInformation.UpgradeRecommendations)
            {
                var rowSpan = GetRowSpanFromPriority(upgradeItem.Priority);
                var colSpan = GetColSpanFromPriority(upgradeItem.Priority);
                group2.Items.Add(new NewUpgradeDataItem(upgradeItem, group2, rowSpan,colSpan)); 
            }
            
            var group3 = new DataGroup("last configurations",
                                       "last configurations",
                                       "Assets/LightGray.png",
                                       "");
            foreach (var configuration in customerInformation.LastConfigurations)
            {
                group3.Items.Add(new ConfigurationDataItem(configuration, group3));
            }
            convertedGroups.Add(group1);
            convertedGroups.Add(group2);
            convertedGroups.Add(group3);

            return convertedGroups;
        }

        private int GetRowSpanFromPriority(int priority)
        {
            if (priority == 1)
            {
                return 35;
            }
            if (priority == 2)
            {
                return 30;
            }
           return 20;
            
        }

        private int GetColSpanFromPriority(int priority)
        {
            if (priority == 1)
            {
                return 50;
            }
            if (priority == 2)
            {
                return 30;
            }
           return 25;
            
        }
    }
}
