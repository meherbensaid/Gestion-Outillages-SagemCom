using feeder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feeder.DAL
{
    interface IGestionAdminDAO
    {
        Personne RechercherAdmin(string login, string password);
        void Changer_Mdp(Personne P, string Nouveau_Mdp);
    }
}
