using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        private IUpgradeRepository _upgradeRepository;
        

        public ConfigurationModel()
        {
            _upgradeRepository = SimpleIoc.Default.GetInstance<IUpgradeRepository>();
        }
        public IConfiguration GetCurrentConfiguration()
        {
            return GetConfiguration();
        }

        private IConfiguration GetConfiguration()
        {
            return SimpleIoc.Default.GetInstance<IConfiguration>();
        }
        
        public void SetConfiguration(IConfiguration configuration)
        {
            SimpleIoc.Default.Unregister<IConfiguration>();
            SimpleIoc.Default.Register<IConfiguration>(() => configuration);
            
        }

        public async Task ConfigureCurrentConfiguration()
        {
            var config = GetCurrentConfiguration();
            //await Task.Delay(TimeSpan.FromSeconds(3));
            //config.ConfigurationGroups = new DummyDataGenerator().GetDummyData(config.SelectedAircrafts);
            
            //SetRightConfigurationState();
            //config.HasConfigurationChanged = false;
            var webserviceClient =
                new AirbusConfigurationWebServiceClient();

            try
            {
                var aircraftList = config.SelectedAircrafts.Select(x => x.UniqueId).ToArray();
                var result = await webserviceClient.getConfigurationResultAsync(aircraftList,
                                                                      config.Upgrades[0].UniqueId);
                var transferable = GetConfigurationResultTransferable(result.getConfigurationResultReturn);

                GetConfiguration().ConfigurationGroups = new TransferableConverter().GetBuildAlternativesFromTransferable(transferable);
                await Task.Delay(TimeSpan.FromSeconds(3));
                SetRightConfigurationState();
                GetConfiguration().HasConfigurationChanged = false;
            }
            catch (Exception e)
            {
                throw new WebserviceNotAvailableException("The webservice is not available, please try again later");
            } 
        }

        private void SetRightConfigurationState()
        {
            if (GetConfiguration().ConfigurationGroups.Count == 0)
            {
                GetConfiguration().State = ConfigurationState.ALTERNATIVE;
            }
            foreach (var configurationGroup in GetConfiguration().ConfigurationGroups)
            {
                if (configurationGroup.GroupConfigurationState.Equals(ConfigurationState.ALTERNATIVE) || 
                    configurationGroup.GroupConfigurationState.Equals(ConfigurationState.IMPOSSIBLE) )
                {
                    GetConfiguration().State = ConfigurationState.ALTERNATIVE;
                    return;
                }
            }
            GetConfiguration().State = ConfigurationState.VALID;
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
