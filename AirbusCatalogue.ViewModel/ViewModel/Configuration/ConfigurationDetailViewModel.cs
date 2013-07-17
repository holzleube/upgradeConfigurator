using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.ViewModel.Templates;

namespace AirbusCatalogue.ViewModel.ViewModel.Configuration
{
    public class ConfigurationDetailViewModel:GridHolderViewModel
    {
        private ConfigurationModel _model;

        public ConfigurationDetailViewModel()
        {
            _model = new ConfigurationModel();
        }

        public IConfigurationGroup ConfigurationGroup { get; set; }

        public override void Initialize(object parameter)
        {
            ConfigurationGroup = (IConfigurationGroup) parameter;
        }
    }
}
