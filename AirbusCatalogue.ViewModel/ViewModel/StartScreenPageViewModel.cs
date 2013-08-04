using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.Model.Customer;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Converter;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Configuration;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using AirbusCatalogue.ViewModel.ViewInterfaces.Aircraft;
using GalaSoft.MvvmLight.Ioc;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class StartScreenPageViewModel : GridHolderViewModel
    {
        private readonly CustomerInformationModel _customerModel;
        private string _imagePath;

        private ImageSource _image;
        private ICommand _itemWasClickedCommand;
        private ConfigurationModel _configurationModel;

        public StartScreenPageViewModel()
        {
            _customerModel = new CustomerInformationModel();
            _configurationModel = new ConfigurationModel();
        }

        public void ReloadCustomer(string customerId)
        {
            CustomerInformation customerInformation;
            if (customerId != null)
            {
                customerInformation = _customerModel.GetCustomerInformationById(customerId);
            }
            else
            {
                customerInformation = _customerModel.GetLastCustomerInformation();
            }
            _imagePath = customerInformation.CustomerLogoImagePath;
            DataGroupElements =
                new CustomerInformationDataToViewObjectsConverter().GetConvertedElements(customerInformation);
        }

        public ICommand ItemWasClickedCommand
        {
            get { return _itemWasClickedCommand ?? (_itemWasClickedCommand = new RelayCommand<DataCommon>(ItemWasSelected)); }
        }

        private void ItemWasSelected(DataCommon obj)
        {
            var navigation = SimpleIoc.Default.GetInstance<INavigationService>();
            if (obj.GetType() == typeof(ConfigurationDataItem))
            {
                var configurationDataItem = obj as ConfigurationDataItem;
                _configurationModel.SetConfiguration(configurationDataItem.Configuration);
                navigation.Navigate(SimpleIoc.Default.GetInstance<ISummary>().GetType());
            }
            else if (obj.UniqueId.Equals("startScreenImage"))
            {
                navigation.Navigate(SimpleIoc.Default.GetInstance<IAircraftFamilySelection>().GetType());
            }

        }


        

        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(DataCommon.BASE_URI, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }


        public override void Initialize(object parameter)
        {
            var customer = parameter as string;
            ReloadCustomer(customer);
        }
    }
}
