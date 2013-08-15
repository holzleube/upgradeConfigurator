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

namespace AirbusCatalogue.Model.Config
{
    public class DummyDataGenerator
    {
        private IUpgradeRepository _upgradeRepository;

        public DummyDataGenerator()
        {
            _upgradeRepository = SimpleIoc.Default.GetInstance<IUpgradeRepository>();
        }

        public List<IConfigurationGroup> GetDummyData(List<IAircraft> aircrafts)
        {
            var result = new List<IConfigurationGroup>();
            if (aircrafts.Count>=1)
            {
                var alternativeList = new List<IUpgradeAlternative>();
                var upgradeList = new List<IUpgradeItem>()
                    {
                        _upgradeRepository.GetUpgradeItemById("CN23.50.110-23"),
                    };
                var upgradeList2 = new List<IUpgradeItem>()
                    {
                        _upgradeRepository.GetUpgradeItemById("1046GT2103"),
                    };
                var alternative = new UpgradeAlternative("Alternative 1", upgradeList);
                var alternative2 = new UpgradeAlternative("Alternative 2", upgradeList2);
                alternativeList.Add(alternative);
                alternativeList.Add(alternative2);
                var aircraftList = new List<IAircraft>();
                var isOk = true;
                for (int i = 0; i < aircrafts.Count && isOk; i++)
                {
                    aircraftList.Add(aircrafts[i]);
                    if (i == 1)
                    {
                        isOk = false;
                    }
                }

                var configurationGroup = new ConfigurationGroup("Group 1", null, alternativeList,
                    aircraftList, "confGroup1");
                result.Add(configurationGroup);
            }
           
            if (aircrafts.Count >= 3)
            {
                var alternativeList = new List<IUpgradeAlternative>();
                var upgradeList = new List<IUpgradeItem>()
                    {
                        _upgradeRepository.GetUpgradeItemById("CN23.50.110-23"),
                    };
                var alternative = new UpgradeAlternative("Alternative 1", upgradeList);
                alternativeList.Add(alternative);

                var aircraftList = new List<IAircraft>();

                for (int i = 2; i < aircrafts.Count; i++)
                {
                    aircraftList.Add(aircrafts[i]);
                }

                var configurationGroup = new ConfigurationGroup("Group 2", null, alternativeList,
                    aircraftList, "confGroup2");
                result.Add(configurationGroup);
            }
            return result;
        }
    }
}
