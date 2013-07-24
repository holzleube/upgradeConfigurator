﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.Model.ConfigurationService;
using AirbusCatalogue.Model.Exceptions;
using AirbusCatalogue.Model.Repository;
using AirbusCatalogue.Model.Transferable;
using AirbusCatalogue.Model.Upgrades;
using GalaSoft.MvvmLight.Ioc;


namespace AirbusCatalogue.Model.Config
{
    public class ConfigurationModel
    {
        private UpgradeRepository _upgradeRepository;
        

        public ConfigurationModel()
        {
            _upgradeRepository = new UpgradeRepository();
        }
        public IConfiguration GetCurrentConfiguration()
        {
            return GetConfiguration();
        }

        private static IConfiguration GetConfiguration()
        {
            return SimpleIoc.Default.GetInstance<IConfiguration>();
        }

        public async Task ConfigureCurrentConfiguration()
        {
            var webserviceClient =
                new AirbusConfigurationWebServiceClient();
            try
            {
                var result = await webserviceClient.getConfigurationResultAsync(new string[] { "N-2213", "N-3065", "N-2228", "N-2456", "N-2716" },
                                                                      "CN23.51.136-27");
                var transferable = GetConfigurationResultTransferable(result.getConfigurationResultReturn);
               
                GetConfiguration().ConfigurationGroups = new TransferableConverter().GetBuildAlternativesFromTransferable(transferable);
                await Task.Delay(TimeSpan.FromSeconds(3));
                GetConfiguration().HasConfigurationChanged = false;
            }
            catch (Exception e)
            {
                throw new WebserviceNotAvailableException("The webservice is not available, please try again later");
            } 
        }

        private ConfigurationResultTransferable[] GetConfigurationResultTransferable(string json)
        {
            var bytes = Encoding.Unicode.GetBytes(json);
            using (var stream = new MemoryStream(bytes))
            {
                var serializer = new DataContractJsonSerializer(typeof(ConfigurationResultTransferable[]));
                return (ConfigurationResultTransferable[])serializer.ReadObject(stream);
            }
        }

        public void SelectAlternativeInGroup(IConfigurationGroup configurationGroupToUpdate)
        {
            var configurationGroup = FindConfigurationGroupInConfiguration(configurationGroupToUpdate.UniqueId);
            configurationGroup.SelectedAlternative = configurationGroupToUpdate.SelectedAlternative;
            configurationGroup.GroupConfigurationState = ConfigurationState.VALID;
            CalculateNewConfigurationState();
        }

        private void CalculateNewConfigurationState()
        {
            ConfigurationState state = ConfigurationState.VALID;
            foreach (var configurationGroup in GetConfiguration().ConfigurationGroups)
            {
                if (!configurationGroup.GroupConfigurationState.Equals(ConfigurationState.VALID))
                {
                    state = ConfigurationState.ALTERNATIVE;
                }
            }
            GetConfiguration().State = state;
        }

        private IConfigurationGroup FindConfigurationGroupInConfiguration(string uniqueId)
        {
            return GetConfiguration().ConfigurationGroups.FirstOrDefault(confGroup => confGroup.UniqueId.Equals(uniqueId));
        }

        public void RemoveGroupFromConfiguration(IConfigurationGroup configurationGroup)
        {
            var currentConfiguration = GetConfiguration();
            currentConfiguration.ConfigurationGroups.Remove(configurationGroup);
            foreach (var aircraft in configurationGroup.Aircrafts)
            {
                currentConfiguration.SelectedAircrafts.Remove(aircraft);
            }
        }
    }
}
