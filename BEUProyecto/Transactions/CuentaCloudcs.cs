using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
    class CuentaCloudcs
    {
        string cloud_name;
        string api_key;
        string api_secret;
        CuentaCloudcs(string name,string apikey,string apisecret)
        {
            this.cloud_name = name;
            this.api_key = apikey;
            this.api_secret = apisecret;
        }
    }
}
