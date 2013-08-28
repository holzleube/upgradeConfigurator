using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.BasicData;
using AirbusCatalogue.ViewModel.Navigation;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.Templates
{
    /// <summary>
    /// This viewModel base class is important for passing paramters when you are
    /// navigating. This interface is used in View for checking a given ViewModel and 
    /// pass the navigation Parameter to the viewModel.
    /// 
    /// It has also two navigation methods for navigating and passing parameters between viewModels
    /// </summary>
    public abstract class ViewModelBase: BindableBase
    {
        public abstract void Initialize(object parameter);

        protected void NavigateToClass(object classToNavigate)
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(classToNavigate.GetType());
        }

        protected void NavigateToClass(object classToNavigate, object parameter)
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(classToNavigate.GetType(), parameter);
        }
    }
}
