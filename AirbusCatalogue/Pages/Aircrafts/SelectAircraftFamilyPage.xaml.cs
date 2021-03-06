using System;
using System.Collections.Generic;
using AirbusCatalogue.ViewModel.ViewInterfaces.Aircraft;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Ioc;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace AirbusCatalogue.Pages.Aircrafts
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class SelectAircraftFamilyPage : AirbusCatalogue.Common.LayoutAwarePage, IAircraftFamilySelection
    {
        public SelectAircraftFamilyPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
          
        }

        
    }
}
