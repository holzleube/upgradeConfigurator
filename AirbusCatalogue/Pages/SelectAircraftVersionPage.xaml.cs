using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using AirbusCatalogue.ViewModel.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace AirbusCatalogue.Pages
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class SelectAircraftVersionPage : IAircraftVersionSelection
    {
        private SelectAircraftVersionViewModel _viewModel;

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
            //foreach (var item in _viewModel.SelectedItems)
            //{
            //    //itemGridView.SelectedItems.Add(item);
            //}
        }

      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var collectionGroups = groupedItemsViewSource.View.CollectionGroups;
            ((ListViewBase)this.Zoom.ZoomedOutView).ItemsSource = collectionGroups;
        }

        //private void RemoveItemFromViewModel(object removedItem)
        //{
        //    _viewModel.SelectedItems.Remove((DataCommon)removedItem);
        //}

        //private void AddItemToViewModel(object addItem)
        //{
        //    _viewModel.SelectedItems.Add((DataCommon)addItem);
        //}

        private void ItemClicked(object sender, ItemClickEventArgs e)
        {
            _viewModel.UpdateSelection(e.ClickedItem);
            //if (itemGridView.SelectedItems.Contains(e.ClickedItem))
            //{
            //    itemGridView.SelectedItems.Remove(e.ClickedItem);
            //    RemoveItemFromViewModel(e.ClickedItem);
            //}
            //else
            //{
            //    itemGridView.SelectedItems.Add(e.ClickedItem);
            //    AddItemToViewModel(e.ClickedItem);
            //}
        }
    }
}
