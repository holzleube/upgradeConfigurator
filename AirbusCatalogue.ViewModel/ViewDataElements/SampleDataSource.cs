using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using AirbusCatalogue.ViewModel.Templates;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace AirbusCatalogue.ViewModel.ViewDataElements
{
    /// <summary>
    /// Base class for <see cref="BasicDataItem"/> and <see cref="AirbusCatalogue.ViewModel.ViewDataElements.DataGroup"/> that
    /// defines properties common to both.
    /// </summary>

    public abstract class DataCommon : BindableBase
    {
        public static Uri BASE_URI = new Uri("ms-appx:///");

        public DataCommon(String uniqueId, String title,  String imagePath)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._imagePath = imagePath;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private ImageSource _image = null;
        private String _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(BASE_URI, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(String path)
        {
            _image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class BasicDataItem : DataCommon
    {
        public BasicDataItem(String uniqueId, String title,  String imagePath, DataGroup group, int rowSpan, int colSpan)
            : base(uniqueId, title,  imagePath)
        {
            this._group = group;
            this.RowSpan = rowSpan;
            this.ColSpan = colSpan;
        }

        private string _content = string.Empty;
        public string Content
        {
            get { return this._content; }
            set { this.SetProperty(ref this._content, value); }
        }

        private DataGroup _group;

        public int RowSpan { get; set; }

        public int ColSpan { get; set; }

        public DataGroup Group
        {
            get { return this._group; }
            set { this.SetProperty(ref this._group, value); }
        }
    }

 
}
