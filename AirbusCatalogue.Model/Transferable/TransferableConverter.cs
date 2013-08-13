using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.Model.Repository;

namespace AirbusCatalogue.Model.Transferable
{
    public class TransferableConverter
    {
        private const string GROUP_NAME = "Group ";
        private const string ALTERNATIVE_NAME = "Alternative ";
        private readonly UpgradeRepository _upgradeRepository;
        private readonly AircraftRepository _aircraftRepository;

        public TransferableConverter()
        {
            _upgradeRepository = new UpgradeRepository();
            _aircraftRepository = new AircraftRepository();
        }

        public List<IConfigurationGroup> GetBuildAlternativesFromTransferable(IEnumerable<ConfigurationResultTransferable> transferable)
        {
            var result = new List<IConfigurationGroup>();
            var groupCounter = 1;
            foreach (var configurationResultTransferable in transferable)
            {
                var alternativeList = GetAlternativeList(configurationResultTransferable);
                var aircrafts = GetAircraftList(configurationResultTransferable);

                var configurationGroup = new ConfigurationGroup(GROUP_NAME + groupCounter, null, alternativeList,
                    aircrafts, "confGroup" + groupCounter);
                result.Add(configurationGroup);
                groupCounter++;
            }
            return result;
        }

        
        private List<IAircraft> GetAircraftList(ConfigurationResultTransferable configurationResultTransferable)
        {
            return configurationResultTransferable.msnList.
                Select(msn => _aircraftRepository.GetAircraftByMSN(msn)).ToList();
        }

        private List<IUpgradeAlternative> GetAlternativeList(ConfigurationResultTransferable configurationResultTransferable)
        {
            var alternativeList = new List<IUpgradeAlternative>();
            var alternativeCounter = 1;
            foreach (var alternative in configurationResultTransferable.alternatives)
            {
                var upgrades = GetUpgradeList(alternative);
                var upgradeAlternatives = new UpgradeAlternative(ALTERNATIVE_NAME + alternativeCounter, upgrades);
                alternativeList.Add(upgradeAlternatives);
                alternativeCounter++;
            }
            return alternativeList;
        }

        private List<IUpgradeItem> GetUpgradeList(AlternativeTransferable alternative)
        {
            var upgrades = new List<IUpgradeItem>();
            foreach (var epacTdu in alternative.epacTdus)
            {
                var upgradeItem = _upgradeRepository.GetUpgradeItemById(epacTdu);
                if(upgrades.Contains(upgradeItem))
                {
                    continue;
                }
                upgrades.Add(upgradeItem);
            }
            return upgrades;
        }
    }

   
}
