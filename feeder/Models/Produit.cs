using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feeder.Models
{
   public class Produit
    {
        public string Nom { get; set; }
        public string UF { get; set; }
        public ICollection<Feeder> Feeders { get; set; }
        public ICollection<Buse> Buses { get; set; }

    }
}
