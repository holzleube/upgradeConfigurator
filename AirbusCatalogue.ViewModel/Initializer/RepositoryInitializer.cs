using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Repository;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.Initializer
{
    public class RepositoryInitializer
    {
        public static void RegisterRepositories()
        {
                SimpleIoc.Default.Register<IAircraftRepository>(() => new AircraftRepository());
                SimpleIoc.Default.Register<IUpgradeRepository>(() => new UpgradeRepository());
                SimpleIoc.Default.Register<ICustomerRepository>(() => new CustomerRepository());
        }
    }
}
