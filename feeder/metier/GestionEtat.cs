using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feeder.metier
{
    class GestionEtat:IGestionEtat
    {
        public string GetDate(string mois)
        {
            
           
               if(mois.Equals( "janvier")) {return "01";} 
               else if (mois.Equals("fevrier")){ return "02";}
               else if (mois.Equals("mars")){ return "03";}
               else if (mois.Equals("avril")){ return "04";} 
               else if (mois.Equals("mai")){return "05";}
               else if(mois.Equals( "juin")){ return "06";} 
               else if (mois.Equals("jullet")){ return "07";} 
               else if (mois.Equals("aout")){ return "08";}
               else if (mois.Equals("septembre")){ return "09";} 
               else if (mois.Equals("octobre")){ return "10";} 
               else if (mois.Equals("november")){ return "11";}
               else { return "12"; } 
               
                   }
    }
}
