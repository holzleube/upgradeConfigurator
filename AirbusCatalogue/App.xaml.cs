using AirbusCatalogue.Common;

using System;
using AirbusCatalogue.Pages;
using AirbusCatalogue.Pages.Aircrafts;
using AirbusCatalogue.Pages.Configuration;
using AirbusCatalogue.Pages.Customer;
using AirbusCatalogue.Pages.Upgrades;
using AirbusCatalogue.ViewModel.Initializer;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using AirbusCatalogue.ViewModel.ViewInterfaces.Aircraft;
using AirbusCatalogue.ViewModel.ViewInterfaces.Configuration;
using AirbusCatalogue.ViewModel.ViewInterfaces.Customer;
using AirbusCatalogue.ViewModel.ViewInterfaces.Upgrades;
using GalaSoft.MvvmLight.Ioc;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SelectAircraftPage = AirbusCatalogue.Pages.Aircrafts.SelectAircraftFamilyPage;
using SelectAircraftVersionPage = AirbusCatalogue.Pages.Aircrafts.SelectAircraftVersionPage;
using SelectUpgradeTypePage = AirbusCatalogue.Pages.Upgrades.SelectUpgradeTypePage;
using SystemUpgradePage = AirbusCatalogue.Pages.Upgrades.SystemUpgradePage;

// The Grid App template is documented at http://go.microsoft.com/fwlink/?LinkId=234226

namespace AirbusCatalogue
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            SimpleIoc.Default.Register<IStartScreen, StartScreenPage>();
            SimpleIoc.Default.Register<ISummary, SummaryPage>();
            SimpleIoc.Default.Register<ICustomerSelection, SelectCustomerPage>();
            SimpleIoc.Default.Register<IAircraftFamilySelection, SelectAircraftFamilyPage>();
            SimpleIoc.Default.Register<IAircraftVersionSelection, SelectAircraftVersionPage>();
            SimpleIoc.Default.Register<IUpgradeTypeSelection, SelectUpgradeTypePage>();
            SimpleIoc.Default.Register<ISystemUpgrade, SystemUpgradePage>();
            SimpleIoc.Default.Register<IUpgradeSelection, SelectUpgradePage>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IConfigurationAlternativeSelection, ConfigurationDetailPage>();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                //Associate the frame with a SuspensionManager key                                
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
                RepositoryInitializer.RegisterRepositories();
            }
            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(GlobalPage)))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
}
