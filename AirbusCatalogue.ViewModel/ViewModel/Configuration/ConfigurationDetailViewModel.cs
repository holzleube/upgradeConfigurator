using System.Collections.Generic;
using System.Windows.Input;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewDataElements.Configuration;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.ViewModel.Configuration
{
    public class ConfigurationDetailViewModel:GridHolderViewModel
    {
        private readonly ConfigurationModel _model;
        private ICommand _gridViewItemWasSelectedCommand;
        private ICommand _alternativeWasChosenCommand;
        private AlternativeDataItem _selectedAlternativeItem;

        public ConfigurationDetailViewModel()
        {
            _model = new ConfigurationModel();
        }

        public IConfigurationGroup ConfigurationGroup { get; set; }

        public ICommand GridViewItemWasSelectedCommand
        {
            get { return _gridViewItemWasSelectedCommand ?? (_gridViewItemWasSelectedCommand = new RelayCommand<DataCommon>(GridViewItemWasSelected)); }
            set
            {
                _gridViewItemWasSelectedCommand = value;
                OnPropertyChanged();
            }
        } 
        public ICommand AlternativeWasChosenCommand
        {
            get { return _alternativeWasChosenCommand ?? (_alternativeWasChosenCommand = new RelayCommand(AlternativeWasChosen)); }
            set
            {
                _alternativeWasChosenCommand = value;
                OnPropertyChanged();
            }
        }

        private void AlternativeWasChosen()
        {
            if (SelectedAlternativeItem != null)
            {
                ConfigurationGroup.SelectedAlternative = SelectedAlternativeItem.UpgradeAlternative;
                _model.SelectAlternativeInGroup(ConfigurationGroup);
                NavigateToSummary();
            }
        }

        private void NavigateToSummary()
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            var navigationClass = SimpleIoc.Default.GetInstance<ISummary>();
            navigationService.Navigate(navigationClass.GetType());
        }

        private void GridViewItemWasSelected(DataCommon obj)
        {
            if (obj.GetType() == typeof (AlternativeDataItem))
            {
                var alternativeObject = (AlternativeDataItem)obj;
                if (SelectedAlternativeItem == null)
                {
                    SelectedAlternativeItem = alternativeObject;
                    return;
                }
                if (SelectedAlternativeItem.Equals(alternativeObject))
                {
                    SelectedAlternativeItem = null;
                    return;
                }
                SelectedAlternativeItem = alternativeObject;
            }
        }

        public AlternativeDataItem SelectedAlternativeItem
        {
            get
            {
                return _selectedAlternativeItem;
            }
            set
            {
                _selectedAlternativeItem = value;
                OnPropertyChanged();
            }
        }

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
            if (ConfigurationGroup.Alternatives.Count < 1)
            {
                return;
            }
            foreach (var alternative in ConfigurationGroup.Alternatives)
            {
                 var alternativeDataItem = new AlternativeDataItem(alternative, alternativeGroup);
                 alternativeGroup.Items.Add(alternativeDataItem);
                 if (ConfigurationGroup.SelectedAlternative != null)
                 {
                     CheckIfAlternativeIsSelectedAndSetSelected(alternative, alternativeDataItem);
                 }
            }
            DataGroupElements.Add(alternativeGroup);
        }

        private void CheckIfAlternativeIsSelectedAndSetSelected(IUpgradeAlternative alternative,
                                                                AlternativeDataItem alternativeDataItem)
        {
            if (ConfigurationGroup.SelectedAlternative.Equals(alternative))
            {
                SelectedAlternativeItem = alternativeDataItem;
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
