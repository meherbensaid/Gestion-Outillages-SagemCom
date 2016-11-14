using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feeder.Models
{
   public class Personne
    {
        public int CIN{ get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
