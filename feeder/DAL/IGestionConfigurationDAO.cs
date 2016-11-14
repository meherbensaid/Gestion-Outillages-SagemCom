using feeder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feeder.DAL
{
    interface IGestionConfigurationDAO
    {
        ICollection<Feeder> ConfigFeeder(string U);
         ICollection<Buse> ConfigBuse(string UF);
          void ModifierConfigmax(ICollection<Feeder> Feeders, string UF);
          void ModifierConfigmaxBuse(ICollection<Buse> Buses, string UF);

    }
}
