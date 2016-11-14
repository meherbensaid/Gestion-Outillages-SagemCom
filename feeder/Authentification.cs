using feeder.DAL;
using feeder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace feeder
{
    public partial class Authentification : Form
    {
        public Authentification()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Login = textBox1.Text;
            var Password = textBox2.Text;
            
            Personne P = null;
            IGestionTechnicienDAO IGTDAO = new GestionTechnicienDAO();
            IGestionAdminDAO IGADAO = new GestionAdminDAO();
            if (comboBox1.Text.Equals("Technicien"))
            {
                P = IGTDAO.RechercherTechnicien(Login, Password);

                if (P == null)
                {
                    MessageBox.Show("erreur ");
                }

                else
                {
                    Accueil_Technicien A = new Accueil_Technicien(P);
                    A.Show();
                }
            }
            else
            {
                P = IGADAO.RechercherAdmin(Login, Password);

                if (P == null)
                {
                    MessageBox.Show("erreur ");
                }

                else
                {

                    Accueil_Admin A = new Accueil_Admin(P);
                    A.Show();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            IGestionEtatDAO IGEDAO = new GestionEtatDAO();

           

           // Etat a = new Etat();
           // a = IGEDAO.RechercherDernierEtat("STB2");
              // Buses=IGPDAO.ListerTotaleBuseAccueil();
            ICollection<Buse> Buses=new List<Buse>();
            ICollection<Feeder> Feeders = new List<Feeder>();
           /* for (int i = 0; i < 33; i++)
            {
                Buses.Add(new Buse { Quantite = i+10 });
            }
            for (int i = 0; i < 6; i++)
            {
                Feeders.Add(new Feeder { Quantite = i });
            }
            Etat b = new Etat { Buses=Buses,Feeders=Feeders,UF="aa",NumEquipe=1};
            b.DateCS=@"10/06/2012";
            Technicien T = new Technicien { Nom = "ali" };
            b.Technicien = T;
            IGEDAO.AjouterPrevision(b);
        
         
            Produit P = new Produit();
            P = IGPDAO.GetProduitByNom("E1 X29 MCU 252");
            */

            IGestionConfigurationDAO IGCDAO = new GestionConfigurationDAO();

            Buses = IGCDAO.ConfigBuse("ATR");

            MessageBox.Show("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
           ICollection<Feeder> F= IGPDAO.ListerTotaleFeederAccueil("13-12-2015","1","f");
            MessageBox.Show("");
        }
    }
}
