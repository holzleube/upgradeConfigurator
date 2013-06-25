using System;
using System.Collections.ObjectModel;
using AirbusCatalogue.Model.Customer;
using AirbusCatalogue.ViewModel.Converter;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class StartScreenPageViewModel : GridHolderViewModel
    {
        private readonly CustomerInformationModel _customerModel;
        

        public StartScreenPageViewModel()
        {
            _customerModel = new CustomerInformationModel();
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

        

        private string _imagePath;

        private ImageSource _image;

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
