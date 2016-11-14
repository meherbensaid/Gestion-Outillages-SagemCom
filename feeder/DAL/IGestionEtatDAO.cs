using feeder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feeder.DAL
{
    interface IGestionEtatDAO
    {

        Etat GetEtat(string UF, String date, string poste, string type);
        Etat RechercherDernierEtat(string UF,string type);
        void AjouterEtat(Etat e);
        void AjouterEtatBuses(Etat e);
        void AjouterPrevision(Etat e);
        Etat EtatPrevision();
        
    }
}
