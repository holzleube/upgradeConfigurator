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
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.Model.Transferable
{
    /// <summary>
    /// This class helps to convert the server result to the right data objects for the app.
    /// </summary>
    public class TransferableConverter
    {
        private const string GROUP_NAME = "Group ";
        private const string ALTERNATIVE_NAME = "Alternative ";
        private readonly IUpgradeRepository _upgradeRepository;
        private readonly IAircraftRepository _aircraftRepository;

        public TransferableConverter()
        {
            _upgradeRepository = SimpleIoc.Default.GetInstance<IUpgradeRepository>();
            _aircraftRepository = SimpleIoc.Default.GetInstance<IAircraftRepository>();
        }

        /// <summary>
        /// Main method to get configuration groups from server result transferable
        /// </summary>
        /// <param name="transferable"></param>
        /// <returns></returns>
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
