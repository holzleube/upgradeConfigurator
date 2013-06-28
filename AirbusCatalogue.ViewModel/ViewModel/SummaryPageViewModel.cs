using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewDataElements.Configuration;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;


namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class SummaryPageViewModel : GridHolderViewModel
    {
        private readonly ConfigurationModel _model;
        private ICommand _selectAircraftCommand;

        public IConfiguration Configuration { get; set; }


        public SummaryPageViewModel()
        {
            _model = new ConfigurationModel();
            InitializeDataGrid();
            
        }

        private void InitializeDataGrid()
        {
            Configuration = _model.GetCurrentConfiguration();
            AddAircraftGroup(Configuration.SelectedAircrafts); 
        }

        private void AddAircraftGroup(List<IAircraft> aircrafts)
        {
            if (aircrafts.Count == 0)
            {
                return;
            }
            var aircraftGroup = new ConfigurationGroup("selectedAircraftGroup", "selected aircrafts", "&#xE0EB;");
            var aircraftItems = GetSelectedAircraftItemsOrderedByVersions(aircrafts, aircraftGroup);
            aircraftGroup.Items = aircraftItems;
            DataGroupElements.Add(aircraftGroup);
        }

        private ObservableCollection<BasicDataItem> GetSelectedAircraftItemsOrderedByVersions(IEnumerable<IAircraft> aircrafts, DataGroup aircraftGroup)
        {
            var aircraftsByCategory = aircrafts.GroupBy(x => x.Version)
                .Select(x => new AircraftVersionSelectionGroup(aircraftGroup, x.ToList()));
            return new ObservableCollection<BasicDataItem>(aircraftsByCategory);
        }

        public ICommand SelectAircraftCommand
        {
            get { return _selectAircraftCommand ?? (_selectAircraftCommand = new RelayCommand(NavigateToSelectAircraft)); }
            set 
            { 
                _selectAircraftCommand = value;
                OnPropertyChanged();
            }
        }

        private void NavigateToSelectAircraft()
        {
            var classToNavigate = SimpleIoc.Default.GetInstance<IAircraftVersionSelection>();
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(classToNavigate.GetType(), Configuration.Programm);
        }

        public override void Initialize(object parameter)
        {

        }
    }
}
