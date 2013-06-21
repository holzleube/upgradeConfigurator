using AirbusCatalogue.ViewModel.ViewDataElements;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AirbusCatalogue.VariableTemplate
{
    public class VariableTiles : DataTemplateSelector
    {
        public DataTemplate TopTemplate { get; set; }
        public DataTemplate SmallTemplate { get; set; }
        public DataTemplate UpgradeTemplate { get; set; }
        public DataTemplate UpgradeTemplateMiddle { get; set; }
        public DataTemplate UpgradeTemplateSmall { get; set; }
        public DataTemplate ConfigurationTemplate { get; set; }
        
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element != null && item != null)
            {
                if (item.GetType() == typeof(HubPageDataItem))
                {
                        return TopTemplate;
                }
                if (item.GetType() == typeof(NewUpgradeDataItem))
                {
                    if (((NewUpgradeDataItem) item).Priority == 1)
                    {
                        return UpgradeTemplate;
                    }
                    if (((NewUpgradeDataItem)item).Priority == 2)
                    {
                        return UpgradeTemplateMiddle;
                    }
                    if (((NewUpgradeDataItem)item).Priority == 3)
                    {
                        return UpgradeTemplateSmall;
                    }

                }
                if (item.GetType() == typeof(ConfigurationDataItem))
                {
                    return ConfigurationTemplate;
                }
                if (item.GetType() == typeof(CustomerDataItem))
                {
                    return ConfigurationTemplate;
                }
                return SmallTemplate;

                //if ((item as CategoryDataItem).UniqueId.StartsWith("Top"))
                //    return TopTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("Small"))
                //    return SmallTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("World"))
                //    return UpgradeTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("life"))
                //    return ConfigurationTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("Multimedia"))
                //    return MultimediaTemplate;


            }
            return base.SelectTemplateCore(item, container);
        }
    }
}
