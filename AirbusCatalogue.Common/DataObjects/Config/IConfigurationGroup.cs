using System.Collections.Generic;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Common.DataObjects.Config
{
    public interface IConfigurationGroup:IIdentable, INameable
    {
        List<IAircraft> Aircrafts { get; set; }

        List<IUpgradeAlternative> Alternatives { get; set; }

        IUpgradeAlternative SelectedAlternative { get; set; }
    }
}
