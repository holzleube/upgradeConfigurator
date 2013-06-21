using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Customer;
using AirbusCatalogue.Model.CustomerModel;
using AirbusCatalogue.ViewModel.Converter;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class StartScreenPageViewModel : BindableBase
    {
        private readonly CustomerInformationModel _customerModel;
        private ObservableCollection<DataGroup> _startPageDataGroups;

        public StartScreenPageViewModel()
        {
            _customerModel = new CustomerInformationModel();
        }

        public void ReloadCustomer(string customerId)
        {
            var customerInformation = _customerModel.GetCustomerInformationById(customerId);
            _imagePath = customerInformation.CustomerLogoImagePath;
            StartPageDataGroups =
                new CustomerInformationDataToViewObjectsConverter().GetConvertedElements(customerInformation);
        }

        public ObservableCollection<DataGroup> StartPageDataGroups
        {
            get
            {
                return _startPageDataGroups;
            }
            set
            {
                _startPageDataGroups = value;
                OnPropertyChanged();
            }
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

        
    }
}
