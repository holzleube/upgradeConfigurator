using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Model.Aircrafts;

namespace AirbusCatalogue.Model.Repository
{
    public class AircraftRepository
    {
        private Dictionary<string, IAircraft> _dataMap;

        public AircraftRepository()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            string image = "Assets/aircrafts/a320_transparent.png";
            _dataMap = new Dictionary<string, IAircraft>();
            _dataMap.Add("N-0001", new Aircraft("N-0001", "N-001", image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0002", new Aircraft("N-0002", "N-001", image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0003", new Aircraft("N-0003", "N-001", image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0004", new Aircraft("N-0004", "N-001", image, "001", "AFR01", "A320"));
            _dataMap.Add("N-2213", new Aircraft("N-2213", "N-2213", image, "001", "AFR01", "A320"));
            _dataMap.Add("N-2456", new Aircraft("N-2456", "N-2456", image, "001", "AFR01", "A320"));
            _dataMap.Add("N-3065", new Aircraft("N-3065", "N-3065", image, "001", "AFR01", "A320"));
            _dataMap.Add("N-2716", new Aircraft("N-2716", "N-2716", image, "001", "AFR01", "A320"));
            _dataMap.Add("N-2228", new Aircraft("N-2228", "N-2228", image, "001", "AFR01", "A320"));
        }

        public IAircraft GetAircraftByMSN(string msn)
        {
            return _dataMap[msn];
        }
    }



}
