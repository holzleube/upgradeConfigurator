using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewDataElements.Configuration;

namespace AirbusCatalogue.ViewModel.ViewModel.Configuration
{
    public class ConfigurationDetailViewModel:GridHolderViewModel
    {
        private readonly ConfigurationModel _model;

        public ConfigurationDetailViewModel()
        {
            _model = new ConfigurationModel();
        }

        public IConfigurationGroup ConfigurationGroup { get; set; }

        public override void Initialize(object parameter)
        {
            ConfigurationGroup = (IConfigurationGroup) parameter;
            InitDataGrid();
        }

        private void InitDataGrid()
        {
            AddConfigurationAlternative();
            AddUpgradeGroup();
            AddAircraftGroup(ConfigurationGroup.Aircrafts);
        }

        private void AddConfigurationAlternative()
        {
            var alternativeGroup = new ConfigurationGroup("possibleAlternatives", "alternatives", "\uE15E");
            if (ConfigurationGroup.Alternatives.Count > 1)
            {
                foreach (var alternative in ConfigurationGroup.Alternatives)
                {
                    var alternativeDataItem = new AlternativeDataItem(alternative, alternativeGroup);
                    alternativeGroup.Items.Add(alternativeDataItem);
                }
                DataGroupElements.Add(alternativeGroup);
            }
        }

        private void AddUpgradeGroup()
        {
            var currentConfig = _model.GetCurrentConfiguration();
            var upgradeGroup = new ConfigurationGroup("selectedUpgradesGroup", "upgrades", "\uE11C");
            foreach (var upgrade in currentConfig.Upgrades)
            {
                upgradeGroup.Items.Add(new UpgradeItemForConfigurationDetailDataItem(upgrade, upgradeGroup));
            }
               
            DataGroupElements.Add(upgradeGroup);
        }

        private void AddAircraftGroup(List<IAircraft> aircrafts)
        {
            if (aircrafts.Count == 0)
            {
                return;
            }
            var aircraftGroup = new ConfigurationGroup("selectedAircraftGroup", "aircrafts", "\uE0EB");
            aircraftGroup.Items.Add(new AircraftVersionSelectionGroup(aircraftGroup, aircrafts));
            DataGroupElements.Add(aircraftGroup);
        }
    }
}
