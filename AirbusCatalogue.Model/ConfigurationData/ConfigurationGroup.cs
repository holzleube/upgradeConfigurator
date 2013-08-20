using System.Collections.Generic;
using System.Linq;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using System.Runtime.Serialization;
using AirbusCatalogue.Model.Aircrafts;

namespace AirbusCatalogue.Model.ConfigurationData
{
    [DataContract]
    [KnownType(typeof(Aircraft))]
    [KnownType(typeof(UpgradeAlternative))]
    [KnownType(typeof(ConfigurationState))]
    public class ConfigurationGroup : IConfigurationGroup
    {
        public ConfigurationGroup(string name, IUpgradeAlternative selectedAlternative, List<IUpgradeAlternative> alternatives, List<IAircraft> aircrafts, string uniqueId)
        {
            Name = name;
            SelectedAlternative = selectedAlternative;
            Alternatives = alternatives;
            Aircrafts = aircrafts;
            UniqueId = uniqueId;
            GroupConfigurationState = CalculateConfigurationState();
        }

        private ConfigurationState CalculateConfigurationState()
        {
            if (Alternatives.Count > 1)
            {
                return ConfigurationState.ALTERNATIVE;
            }
            if (Alternatives.Count == 1)
            {
                SelectedAlternative = Alternatives.Single();
                return ConfigurationState.VALID;
            }
            return ConfigurationState.IMPOSSIBLE;

        }

        [DataMember]
        public string UniqueId { get; set; }
        [DataMember]
        public List<IAircraft> Aircrafts { get; set; }
        [DataMember]
        public List<IUpgradeAlternative> Alternatives { get; set; }
        [DataMember]
        public IUpgradeAlternative SelectedAlternative { get; set; }
        [DataMember]
        public ConfigurationState GroupConfigurationState { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}