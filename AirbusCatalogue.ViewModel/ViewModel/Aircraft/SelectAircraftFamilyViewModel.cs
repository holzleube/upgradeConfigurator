using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.ViewModel.Aircraft
{
    /// <summary>
    /// This View Model has the logic for aircraft family selection. Normally its the first view if
    /// a new configuration is started.
    /// </summary>
    public class SelectAircraftFamilyViewModel : GridHolderViewModel
    {
        private AircraftModel _model;
        private ICommand _familySelectedCommand;

        public SelectAircraftFamilyViewModel()
        {
            Headline = "select aircraft family";
            _model = new AircraftModel();
            InitializeDataSource();
        }

        private void InitializeDataSource()
        {

            DataGroupElements = new ObservableCollection<DataCommon>
                {
                    new AircraftProgrammGroup(_model.GetAllAircraftProgramms())
                }; 
        }

        public ICommand SelectAircraftCommand
        {
            get { return _familySelectedCommand ?? (_familySelectedCommand = new RelayCommand<DataCommon>(SaveSelectionAndNavigateToSummaryPage)); }
            set
            {
                _familySelectedCommand = value;
                OnPropertyChanged();
            }
        }

        private void SaveSelectionAndNavigateToSummaryPage(DataCommon data)
        {
            var selectedProgramm = GetSelectedProgramm(data.UniqueId);
            _model.SelectAircraftProgramm(selectedProgramm);
            var classToNavigate = SimpleIoc.Default.GetInstance<ISummary>();
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(classToNavigate.GetType());
        }

        private AircraftProgramm GetSelectedProgramm(string uniqueId)
        {
            return _model.GetAllAircraftProgramms().FirstOrDefault(programm => programm.UniqueId.Equals(uniqueId));
        }

        public override void Initialize(object parameter)
        {
            
        }
    }
}
