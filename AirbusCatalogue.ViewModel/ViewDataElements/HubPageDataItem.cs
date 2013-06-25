﻿using System;

namespace AirbusCatalogue.ViewModel.ViewDataElements
{
    public class HubPageDataItem : BasicDataItem
    {
        public HubPageDataItem(String uniqueId, String imagePath, DataGroup group)
            : base(uniqueId, "start screen image", imagePath, group, 64,111)
        {
            
        }
    }
}