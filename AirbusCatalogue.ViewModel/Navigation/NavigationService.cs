using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AirbusCatalogue.ViewModel.Navigation
{
    public class NavigationService : INavigationService
    {

            public void Navigate(Type sourcePageType)
            {
                Frame.Navigate(sourcePageType);
            }
            public void Navigate(Type sourcePageType, object parameter)
            {
                Frame.Navigate(sourcePageType, parameter);
            }
            public void GoBack()
            {
                Frame.GoBack();
            }

            public Frame Frame { get; set; }
    }
}
