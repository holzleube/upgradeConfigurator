using AirbusCatalogue.Common.DataObjects.Aircrafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Repository
{
    public interface IAircraftRepository
    {
        IAircraft GetAircraftByMSN(string msn);

        List<IAircraft> GetAllAircrafts();
    }
}
