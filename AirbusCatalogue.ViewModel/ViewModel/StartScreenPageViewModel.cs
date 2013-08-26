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
using AirbusCatalogue.ViewModel.ViewInterfaces.Upgrades;
using AirbusCatalogue.ViewModel.ViewDataElements.Upgrades;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class StartScreenPageViewModel : GridHolderViewModel
    {
        private readonly CustomerInformationModel _customerModel;
        private string _imagePath;

        private ImageSource _image;
        private ICommand _itemWasClickedCommand;
        private ConfigurationModel _configurationModel;
        private string _customerImage;

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
            _customerImage = customerInformation.CustomerStartPageImagePath;
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
                navigation.Navigate(SimpleIoc.Default.GetInstance<ISummary>().GetType(), configurationDataItem.Configuration);
            }
            else if (obj.UniqueId.Equals("startScreenImage"))
            {
                navigation.Navigate(SimpleIoc.Default.GetInstance<IAircraftFamilySelection>().GetType());
            }
            else if (obj is IUpgradeDataItem)
            {
                var upgradeObj = obj as IUpgradeDataItem;
                
                navigation.Navigate(SimpleIoc.Default.GetInstance<ICabinDetailUpgrade>().GetType(), upgradeObj.DataItem);
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

        public string CustomerImage
        {
            get
            {
                return this._customerImage;
            }
            set
            {
                this._customerImage = value;
                OnPropertyChanged();
            }
        }


        public override void Initialize(object parameter)
        {
            var customer = parameter as string;
            ReloadCustomer(customer);
        }
    }
}
