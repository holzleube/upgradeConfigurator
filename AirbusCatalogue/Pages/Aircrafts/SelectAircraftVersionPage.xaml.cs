using System;
using System.Collections.Generic;
using AirbusCatalogue.ViewModel.ViewInterfaces.Aircraft;
using AirbusCatalogue.ViewModel.ViewModel.Aircraft;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace AirbusCatalogue.Pages.Aircrafts
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class SelectAircraftVersionPage : IAircraftVersionSelection
    {
        private readonly SelectAircraftVersionViewModel _viewModel;

        public SelectAircraftVersionPage()
        {
            this.InitializeComponent();
            _viewModel = new SelectAircraftVersionViewModel();
            DataContext = _viewModel;
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
            SetSelectedItemsOnView();
        }

        private void SetSelectedItemsOnView()
        {
            foreach (var item in _viewModel.SelectedItems)
            {
                itemGridView.SelectedItems.Add(item);
            }
        }

      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var collectionGroups = groupedItemsViewSource.View.CollectionGroups;
            ((ListViewBase)this.Zoom.ZoomedOutView).ItemsSource = collectionGroups;
        }


        private void ItemClicked(object sender, ItemClickEventArgs e)
        {
            _viewModel.UpdateSelection(e.ClickedItem);
            bottomAppBar.IsOpen = true;
            if (itemGridView.SelectedItems.Contains(e.ClickedItem))
            {
                itemGridView.SelectedItems.Remove(e.ClickedItem);
            }
            else
            {
                itemGridView.SelectedItems.Add(e.ClickedItem);
            }
            if (itemGridView.SelectedItems.Count == 0)
            {
                bottomAppBar.IsOpen = false;
            }
            SetSelectedItemsOnView();
        }

        private void UpdateZoomOutView(object sender, SelectionChangedEventArgs e)
        {
            var collectionGroups = groupedItemsViewSource.View.CollectionGroups;
            ((ListViewBase)this.Zoom.ZoomedOutView).ItemsSource = collectionGroups;
            SetSelectedItemsOnView();
        }
    }
}
