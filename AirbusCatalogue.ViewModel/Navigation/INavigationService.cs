using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AirbusCatalogue.ViewModel.Navigation
{
    /// <summary>
    /// This interface has methods for navigating through the application.
    /// It is necessary for registering a frame in IOC Container.
    /// </summary>
    public interface INavigationService
    {
        void Navigate(Type sourcePageType);

        void Navigate(Type sourcePageType, object parameter);

        void GoBack();

        Frame Frame { get; set; }
    }
}
