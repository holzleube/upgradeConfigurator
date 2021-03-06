﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewDataElements.Configuration;
using AirbusCatalogue.ViewModel.ViewDataElements.Customer;
using AirbusCatalogue.ViewModel.ViewDataElements.Summary;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.VariableTemplate
{
    class SummaryTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ProgrammTile { get; set; }
        public DataTemplate AircraftTile { get; set; }
        public DataTemplate SelectionTile { get; set; }
        public DataTemplate ConfigurationTile { get; set; }
        public DataTemplate EmptyConfigurationTile { get; set; }
        public DataTemplate ConfigurationGroupTile { get; set; }
        public DataTemplate ConfigureTile { get; set; }
        public DataTemplate AlternativeTile { get; set; }
        public DataTemplate UnknownConfiguration { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element == null || item == null)
            {
                return base.SelectTemplateCore(item, container);
            }
            if (item is AircraftProgrammDataItem)
            {
                return ProgrammTile;
            }
            if (item.GetType() == typeof(AircraftVersionSelectionGroup))
            {
                return AircraftTile;
            }
            if (item.GetType() == typeof(SummarySelectionDataItem))
            {
                return SelectionTile;
            }
            if (item.GetType() == typeof(IncompleteConfigurationDataItem))
            {
                return EmptyConfigurationTile;
            }
            if (item.GetType() == typeof(ConfigurationGroupDataItem))
            {
                return ConfigurationGroupTile;
            }
            if (item.GetType() == typeof(ConfigureDataItem))
            {
                return ConfigureTile;
            }
            if (item.GetType() == typeof(UpgradeItemForConfigurationDetailDataItem))
            {
                return SelectionTile;
            } 
            if (item.GetType() == typeof(AlternativeDataItem))
            {
                return AlternativeTile;
            }
            if (item.GetType() == typeof(UnknownConfigurationDataItem))
            {
                return UnknownConfiguration;
            }
            if (item.GetType() == typeof(DependencyObject))
            {
                var group = item as DataGroup;

                Debug.Assert(group != null, "group != null");
                if (group.Title.Equals("aircraft type"))
                {
                    return AircraftTile;
                }
                return AlternativeTile;
            }
            return base.SelectTemplateCore(item, container);

        }
    }
}
