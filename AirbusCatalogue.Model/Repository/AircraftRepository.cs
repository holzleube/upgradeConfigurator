﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Model.Aircrafts;

namespace AirbusCatalogue.Model.Repository
{
    public class AircraftRepository:IAircraftRepository
    {
        private Dictionary<string, IAircraft> _dataMap;
        private const string A320Image = "Assets/allTypes/head_a320.png";
        private const string A321Image = "Assets/allTypes/head_a321.png";
        private const string A319Image = "Assets/allTypes/head_a319.png";

        public AircraftRepository()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            string image = "Assets/aircrafts/a320_transparent.png";
            _dataMap = new Dictionary<string, IAircraft>();
            _dataMap.Add("N-0002", new Aircraft("N-0002", "N-0002",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0005", new Aircraft("N-0005", "N-0005",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0007", new Aircraft("N-0007", "N-0007",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0009", new Aircraft("N-0009", "N-0009",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0014", new Aircraft("N-0014", "N-0014",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0019", new Aircraft("N-0019", "N-0019",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0020", new Aircraft("N-0020", "N-0020",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0021", new Aircraft("N-0021", "N-0021",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0061", new Aircraft("N-0061", "N-0061",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0062", new Aircraft("N-0062", "N-0062",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0063", new Aircraft("N-0063", "N-0063",  A320Image, "001", "AFR01", "A320"));
            _dataMap.Add("N-0077", new Aircraft("N-0077","N-004", A321Image, "001", "AFR02", "A321"));
            _dataMap.Add("N-0796", new Aircraft("N-0796","N-005", A321Image, "001", "AFR02", "A321"));
            _dataMap.Add("N-1133", new Aircraft("N-1133","N-005", A321Image, "001", "AFR02", "A321"));
            _dataMap.Add("N-1299", new Aircraft("N-1299","N-005", A321Image, "001", "AFR02", "A321"));
            _dataMap.Add("N-1476", new Aircraft("N-1476","N-006", A321Image, "001", "AFR02", "A321"));
            _dataMap.Add("N-0938", new Aircraft("N-0938","N-007", A319Image, "001", "AFR03", "A319"));
            _dataMap.Add("N-0985", new Aircraft("N-0985","N-008", A319Image, "001", "AFR03", "A319"));
            _dataMap.Add("N-0998", new Aircraft("N-0998","N-009", A319Image, "001", "AFR03", "A319"));
            _dataMap.Add("N-1000", new Aircraft("N-1000","N-010", A319Image, "001", "AFR03", "A319"));
            _dataMap.Add("N-1020", new Aircraft("N-1020","N-011", A319Image, "001", "AFR03", "A319"));
            _dataMap.Add("N-1025", new Aircraft("N-1025","N-012", A319Image, "001", "AFR03", "A319"));
            _dataMap.Add("N-1873", new Aircraft("N-1873","N-013", A320Image, "001", "AFR06", "A320"));
            _dataMap.Add("N-1874", new Aircraft("N-1874","N-013", A320Image, "001", "AFR06", "A320"));
            _dataMap.Add("N-1894", new Aircraft("N-1894","N-013", A320Image, "001", "AFR06", "A320"));
            _dataMap.Add("N-2140", new Aircraft("N-2140","N-014", A320Image, "001", "AFR06", "A320"));
            _dataMap.Add("N-1924", new Aircraft("N-1924","N-015", A320Image, "001", "AFR10", "A320"));
            _dataMap.Add("N-1949", new Aircraft("N-1949","N-016", A320Image, "001", "AFR10", "A320"));
            _dataMap.Add("N-2213", new Aircraft("N-2213","N-013", A319Image, "001", "AFR11", "A319"));
            _dataMap.Add("N-2228", new Aircraft("N-2228","N-013", A319Image, "001", "AFR11", "A319"));
            _dataMap.Add("N-2279", new Aircraft("N-2279","N-013", A319Image, "001", "AFR11", "A319"));
            _dataMap.Add("N-2456", new Aircraft("N-2456","N-013", A319Image, "001", "AFR11", "A319"));
            _dataMap.Add("N-2716", new Aircraft("N-2716","N-013", A319Image, "001", "AFR11", "A319"));
            _dataMap.Add("N-3065", new Aircraft("N-3065","N-014", A319Image, "001", "AFR11", "A319"));
        }


        public IAircraft GetAircraftByMSN(string msn)
        {
            return _dataMap[msn];
        }


        public List<IAircraft> GetAllAircrafts()
        {
            return _dataMap.Select(x => x.Value).ToList();
        }
    }



}
