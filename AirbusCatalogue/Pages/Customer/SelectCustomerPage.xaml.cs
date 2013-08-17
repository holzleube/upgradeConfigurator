using System;
using System.Collections.Generic;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.ViewModel.ViewDataElements;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace AirbusCatalogue.Pages.Customer
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class SelectCustomerPage : AirbusCatalogue.Common.LayoutAwarePage
    {
        public SelectCustomerPage()
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
 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var collectionGroups = groupedItemsViewSource.View.CollectionGroups;
            ((ListViewBase)this.Zoom.ZoomedOutView).ItemsSource = collectionGroups;
            base.OnNavigatedTo(e);
        }

        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            //var itemId = ((BasicDataItem)e.ClickedItem).UniqueId;
            //this.Frame.Navigate(typeof(ItemDetailPage), itemId);
            var customerId = ((IIdentable) e.ClickedItem).UniqueId;
            Frame.Navigate(typeof(StartScreenPage), customerId);
        }
    }
}
