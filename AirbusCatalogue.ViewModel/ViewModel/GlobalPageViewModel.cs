using System;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class GlobalPageViewModel
    {
        public RelayCommand NavigateToSummaryPage
        {
            get { return new RelayCommand(NavigateToSummary);}
        }
        
        public RelayCommand NavigateToUpgradePage
        {
            get { return new RelayCommand(NavigateToUpgrade);}
        }

        public RelayCommand NavigateToAircraftSelectionPage
        {
            get { return new RelayCommand(NavigateToAircraftSelection);}
        }

        private void NavigateToUpgrade()
        {
            var upgradePage = SimpleIoc.Default.GetInstance<IUpgradeSelection>();
            Navigate(upgradePage.GetType());
        }

        private void NavigateToAircraftSelection()
        {
            var aircraftSelectionPage = SimpleIoc.Default.GetInstance<IAircraftVersionSelection>();
            Navigate(aircraftSelectionPage.GetType());
        }

        private void NavigateToSummary()
        {
            var summaryPage = SimpleIoc.Default.GetInstance<ISummary>();
            Navigate(summaryPage.GetType());
        }

        private void Navigate(Type classToNavigate)
        {
            var navigation = SimpleIoc.Default.GetInstance<INavigationService>();
            navigation.Navigate(classToNavigate);
        }
    }
}
