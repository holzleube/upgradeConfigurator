﻿using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Configuration;
using AirbusCatalogue.ViewModel.ViewDataElements.Customer;
using AirbusCatalogue.ViewModel.ViewDataElements.Summary;
using AirbusCatalogue.ViewModel.ViewDataElements.Upgrades;
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
                if (item.GetType() == typeof(NewUpgradeSmallDataItem))
                {
                   return UpgradeTemplateSmall;
                }
                if (item.GetType() == typeof(ConfigurationDataItem))
                {
                    return ConfigurationTemplate;
                } 
                if (item.GetType() == typeof(NewUpgradeBigDataItem))
                {
                    return UpgradeTemplate;
                }
            }
            return base.SelectTemplateCore(item, container);
        }
    }
}
