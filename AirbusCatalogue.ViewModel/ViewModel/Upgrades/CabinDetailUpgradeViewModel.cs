using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.Model.Upgrades;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirbusCatalogue.ViewModel.ViewModel.Upgrades
{
    public class CabinDetailUpgradeViewModel:AUpgradeItemViewModel
    {
        private IUpgradeItem _selectedTdu;
        private UpgradeModel _model;
        private bool _isMainDeck;
        private string _headline;
        private ObservableCollection<IUpgradeItem> _upgradeItems;
        private ConfigurationModel _configurationModel;

        public CabinDetailUpgradeViewModel()
        {
            _model = new UpgradeModel();
            _configurationModel = new ConfigurationModel();
        }
        public override void Initialize(object parameter)
        {
            var upgradeToShow = parameter as IUpgradeItem;
            if (upgradeToShow == null) return;
            InitilizeViewData(upgradeToShow);
        }

        public string Headline
        {
            get { return _headline; }
            set
            {
                _headline = value;
                OnPropertyChanged();
            }
        }

        public List<IUpgradeArea> SelectedUpgradeAreas{get;set;}

        public bool IsMainDeck
        {
            get
            {
                return _isMainDeck;
            }
            set
            {
                _isMainDeck = value;
                SetCorrectFloorInGrid(value);
                OnPropertyChanged();
            }
        }

        private void SetCorrectFloorInGrid(bool isMainDeck)
        {
            var zones = new List<IUpgradeArea>();
            if (isMainDeck)
            {
                zones = _model.GetUpgradeAreasByDeck("mainDeck");
            }
            else
            {
                zones = _model.GetUpgradeAreasByDeck("upperDeck");
            }
            DataGroupElements = new ObservableCollection<IIdentable>(zones);
        }

        public ObservableCollection<IUpgradeItem> UpgradeItems
        {
            get { return _upgradeItems; }
            set
            {
                _upgradeItems = value;
                OnPropertyChanged();
            }
        }

        private void InitilizeViewData(IUpgradeItem upgradeToShow)
        {
            Headline = upgradeToShow.Name;
            IsMainDeck = true;
        }

        public void SetSelectedItems(IList<object> list)
        {
            var selectedAreas = new List<IUpgradeArea>();
            foreach (var element in list)
            {
                selectedAreas.Add(element as IUpgradeArea);
            }
            SelectedUpgradeAreas = selectedAreas;
            if (SelectedUpgradeAreas.Count > 0)
            {
                UpgradeItems = new ObservableCollection<IUpgradeItem>(_model.GetUpgradeItemsByArea(SelectedUpgradeAreas));
            }
            else
            {
                UpgradeItems = new ObservableCollection<IUpgradeItem>();
            }
        }
    }
}
