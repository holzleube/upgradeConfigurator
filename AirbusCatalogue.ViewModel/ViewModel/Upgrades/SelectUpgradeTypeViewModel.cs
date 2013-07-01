using System.Windows.Input;
using AirbusCatalogue.Model.Upgrades;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewInterfaces.Upgrades;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.ViewModel.Upgrades
{
    public class SelectUpgradeTypeViewModel:BindableBase
    {
        public SelectUpgradeTypeViewModel()
        {
            _model = new UpgradeModel();
        }

        private ICommand _upgradeTypeSelectedCommand;
        private readonly UpgradeModel _model;

        public ICommand UpgradeTypeSelectedCommand
        {
            get { return _upgradeTypeSelectedCommand ?? (_upgradeTypeSelectedCommand = new RelayCommand<string>(NavigateToRightType)); }
            set
            {
                _upgradeTypeSelectedCommand = value;
                OnPropertyChanged();
            }
        }

        private void NavigateToRightType(string obj)
        {
            var type = _model.GetUpgradeTypeById(obj);
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            var typePage = SimpleIoc.Default.GetInstance<ISystemUpgrade>();
            navigationService.Navigate(typePage.GetType(), type);
        }
    }
}
