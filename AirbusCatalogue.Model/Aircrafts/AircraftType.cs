﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Aircrafts
{
    public class AircraftType:AAircraftBase
    {
        public AircraftType(string uniqueId, string name, string imagePath) : base(uniqueId, name, imagePath)
        {
        }
    }
}
