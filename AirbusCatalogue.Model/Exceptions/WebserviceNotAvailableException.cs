using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Exceptions
{
    public class WebserviceNotAvailableException:Exception
    {
        public WebserviceNotAvailableException(string message) : base(message)
        {
            
        }
    }
}
