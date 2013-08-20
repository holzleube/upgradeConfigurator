using System;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Model.Templates;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.Serialization;

namespace AirbusCatalogue.Model.Aircrafts
{
    [DataContract]
    public class AircraftProgramm : AAircraftBase, IAircraftProgramm
    {

        public AircraftProgramm(string uniqueId, string name, string imagePath) :base(uniqueId, name, imagePath)
        {
           
        }

        //private BitmapImage _image;
        //public ImageSource Image
        //{
        //    get
        //    {
        //        if (this._image == null && this.ImagePath != null)
        //        {
        //            this._image = new BitmapImage(new Uri(BASE_URI, this.ImagePath));
        //        }
        //        return this._image;
        //    }
        //}
    }
}
