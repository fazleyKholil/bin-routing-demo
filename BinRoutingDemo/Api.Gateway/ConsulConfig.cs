using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Gateway
{
    public class ConsulConfig
    {
        public string address { get; set; }

        public string ServiceID { get; set; }
        public string ServiceName { get; set; }
    }
}
