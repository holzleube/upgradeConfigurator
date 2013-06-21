using AirbusCatalogue.ViewModel.ViewDataElements;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AirbusCatalogue.VariableTemplate
{
    class CustomerTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ImageTile { get; set; }
        public DataTemplate ImageAndTextTile { get; set; }
        
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element == null || item == null)
            {
                return base.SelectTemplateCore(item, container);
            }
                if (item.GetType() == typeof (CustomerDataItem))
                {
                    return ((CustomerDataItem) item).IsTextVisible ? ImageAndTextTile : ImageTile;
                }
                return base.SelectTemplateCore(item, container);
           
        }
    }
}
