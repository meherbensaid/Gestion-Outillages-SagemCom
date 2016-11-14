using feeder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feeder.DAL
{
    interface IGestionProduitDAO
    {
        ICollection<Produit> ListerProduit(string UF);
       ICollection<string> ListerUF();

       ICollection<Feeder> ListerFeeder(string NomProduit); ICollection<Buse> ListerBuses(string NomProduit);
       ICollection<Feeder> ListerTotaleFeederAccueil(); ICollection<Buse> ListerTotaleBuseAccueil();
        ICollection<Feeder> ListerTotaleFeederAccueil( String date, string poste, string type);
        ICollection<Buse> ListerTotaleBuseAccueil(String date, string poste, string type);
        ICollection<Feeder> ListerTotaleFeederUsine(); ICollection<Buse> ListerTotaleBusesUsine();

        Produit GetProduitByNom(string nom);

        void ModifierProduit(Produit P, string NomProduit); void ModifierProduitBuse(Produit P, string NomProduit);
         
     //  void ModifierFeeder(int nf1, int nf2, int nf3, int nf4, int nf5, int nf6);
      
    }
}
