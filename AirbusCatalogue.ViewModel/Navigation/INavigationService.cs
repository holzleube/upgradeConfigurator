using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AirbusCatalogue.ViewModel.Navigation
{
    public interface INavigationService
    {
        void Navigate(Type sourcePageType);

        void Navigate(Type sourcePageType, object parameter);

        void GoBack();

        Frame Frame { get; set; }
    }
}
