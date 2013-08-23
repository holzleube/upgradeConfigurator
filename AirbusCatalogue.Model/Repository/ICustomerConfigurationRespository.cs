using AirbusCatalogue.Common.DataObjects.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Repository
{
    public interface ICustomerConfigurationRespository
    {
        List<IConfigurationFile> GetCurentConfigurationsByCustomerId(string customerId);

        void SaveConfigurationForCustomer(IConfigurationFile configuration, string customerId);
        

    }
}
