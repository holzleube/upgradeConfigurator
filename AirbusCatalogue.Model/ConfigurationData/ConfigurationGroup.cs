using System.Collections.Generic;
using System.Linq;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;

namespace AirbusCatalogue.Model.ConfigurationData
{
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

        public string UniqueId { get; set; }
        public List<IAircraft> Aircrafts { get; set; }
        public List<IUpgradeAlternative> Alternatives { get; set; }
        public IUpgradeAlternative SelectedAlternative { get; set; }
        public ConfigurationState GroupConfigurationState { get; set; }
        public string Name { get; set; }
    }
}