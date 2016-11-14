using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feeder.Models
{
  public  class Etat
    {
      
        public int EtatID { get; set; }
        public String UF { get; set; }

        public ICollection<Feeder> Feeders { get; set; }

        public ICollection <Buse>Buses { get; set; }
        public string DateCS { get; set; }
        public int NumEquipe { get; set; }

        public Technicien Technicien { get; set; }
    }
}
