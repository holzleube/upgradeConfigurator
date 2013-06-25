using AirbusCatalogue.Common;
using AirbusCatalogue.Customer;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using GalaSoft.MvvmLight.Ioc;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AirbusCatalogue.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GlobalPage : Page
    {
        public GlobalPage()
        {
            this.InitializeComponent();
            
            frame1.Navigate(typeof(StartScreenPage), "emirates");
            
            var nav = SimpleIoc.Default.GetInstance<INavigationService>();
            nav.Frame = frame1;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void OnFrameNavigated(object sender, NavigationEventArgs args)
        {
            var page = args.Content as LayoutAwarePage;

            if (page == null)
                return;

            var viewModel = page.DataContext as ViewModelBase;

            if (viewModel == null)
                return;

            viewModel.Initialize(args.Parameter);
        }

       
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (frame1.CanGoBack)
            {
                frame1.GoBack();
            }
            //else if (rootPage != null && rootPage.Frame.CanGoBack)
            //{
            //    rootPage.Frame.GoBack();
            //}
        }

        private void Page1Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(typeof(SelectCustomerPage), this);
        }

        private void Page2Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(typeof(SelectCustomerPage), this);
        }

        private void Start_Button_Clicked(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(typeof(StartScreenPage));
        }
    }
}
