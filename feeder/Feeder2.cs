using feeder.DAL;
using feeder.metier;
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
    public partial class Feeder2 : Form
    {
        public string jour;
        public string equipe;
        public Personne personne;
        public Etat etat;
        public Boolean verou;
        public Boolean verou1;
        public Feeder2(string jour,string equipe,Personne personne)
        {
            this.jour = jour;
            this.equipe = equipe;
            this.personne = personne;
            this.verou = true;
            this.verou1 = true;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            ICollection<Produit> Produits = new List<Produit>();



            foreach (var item in IGPDAO.ListerUF())
            {
                UF_Combo_Box.Items.Add(item);
              
            }
           

        }

        private void AP_Combo_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Calcul_Click(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            ICollection<Feeder> Anciensfeeders = new List<Feeder>();
            ICollection<Feeder> Nouveauxfeeders = new List<Feeder>();

            Anciensfeeders = IGPDAO.ListerFeeder(AP_Combo_Box.Text);
            Nouveauxfeeders = IGPDAO.ListerFeeder(NP_Combo_Box.Text);
            int i=0;
             int [] NF = new int[6];
              int [] AF = new int[6];
             foreach (var item in Anciensfeeders)
             {
                 AF[i] = item.Quantite;
                 i++;
             }


             i = 0;
             foreach (var item in Nouveauxfeeders)
             {
                NF[i] =item.Quantite;
                i++;
             }
             textBox1.Text = (NF[0]-AF[0]).ToString();
             textBox2.Text = (NF[1]-AF[1]).ToString();
             textBox3.Text = (NF[2]-AF[2]).ToString();
             textBox4.Text = (NF[3]-AF[3]).ToString();
             textBox5.Text = (NF[4]-AF[4]).ToString();
             textBox6.Text = (NF[5]-AF[5]).ToString();

             this.verou1 = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjouterTechnicien AT = new AjouterTechnicien();
            AT.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();

            AP_Combo_Box.Items.Clear();
            
            NP_Combo_Box.Items.Clear();
            foreach (var item1 in IGPDAO.ListerProduit(UF_Combo_Box.Text))
            {
                AP_Combo_Box.Items.Add(item1.Nom);
                
                NP_Combo_Box.Items.Add(item1.Nom);
            }
         
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            foreach (var item1 in IGPDAO.ListerProduit(UF_Combo_Box.Text))
            {
                AP_Combo_Box.Items.Remove(item1.Nom);
                NP_Combo_Box.Items.Remove(item1.Nom);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.verou1)
            {
                MessageBox.Show("Vous devez appuiyer sur le boutton calcul d'abord");
            }
            else {
            IGestionEtatDAO IGEDAO=new GestionEtatDAO();
              IGestionConfigurationDAO IGCDAO=new GestionConfigurationDAO();
            IGestionProduitDAO IGPDAO=new GestionProduitDAO();

             ICollection<Feeder> TotaleFeederDansUF=new List<Feeder>();
             ICollection<Feeder> TotaleFeederInLocale = new List<Feeder>();

           ICollection<Feeder> FeedersConfig=new List<Feeder>();
          
            Etat etat = IGEDAO.RechercherDernierEtat(UF_Combo_Box.Text,"f");

            FeedersConfig = IGCDAO.ConfigFeeder(UF_Combo_Box.Text);



            int[] ConfigF = new int[6];
            string[] ConfigFeederID = new string[6];
            int[] DernierEtatF = new int[6];
            int i = 0;
            foreach (var item in FeedersConfig)
            {
                ConfigF[i] = item.Quantite;
                ConfigFeederID[i] = item.Coordonnee;
                i++;
            }
            i = 0;
            foreach (var item in etat.Feeders)
            {
                DernierEtatF[i] = item.Quantite;
                i++;
            }

            string [] Coordonnefeeder=new string [6];

            Coordonnefeeder[0] = "F2X8";
            Coordonnefeeder[1] = "F12X16";
            Coordonnefeeder[2] = "F24X32";
            Coordonnefeeder[3] = "F44X56";
            Coordonnefeeder[4] = "F72";
            Coordonnefeeder[5] = "F88";

            int[] T = new int[6];
            T[0] = DernierEtatF[0] + Convert.ToInt32(textBox1.Text);
            T[1] = DernierEtatF[1] + Convert.ToInt32(textBox2.Text);
            T[2] = DernierEtatF[2] + Convert.ToInt32(textBox3.Text);
            T[3] = DernierEtatF[3] + Convert.ToInt32(textBox4.Text);
            T[4] = DernierEtatF[4] + Convert.ToInt32(textBox5.Text);
            T[5] = DernierEtatF[5] + Convert.ToInt32(textBox6.Text);



            TotaleFeederDansUF = IGPDAO.ListerTotaleFeederAccueil();
            TotaleFeederInLocale = IGPDAO.ListerTotaleFeederUsine();

            int[] TotaleFeederDansUF1 = new int[6];
            int[] TotaleFeederInLocale1 = new int[6];
            int[] FeederDisponible = new int[6];
            var k=0;
            foreach (var item in TotaleFeederDansUF)
            {
                TotaleFeederDansUF1[k]=item.Quantite;
                k++;
            }
            k = 0;
            foreach (var item in TotaleFeederInLocale)
            {
                TotaleFeederInLocale1[k] = item.Quantite;
                k++;
            }

            for (int w = 0; w < 6; w++)
            {
                FeederDisponible[w] = TotaleFeederInLocale1[w] - TotaleFeederDansUF1[w];
            }
            
            if (Convert.ToInt32(textBox1.Text) > FeederDisponible[0])
            {
                MessageBox.Show(" stock insuffisant du feeder " + Coordonnefeeder[0] + " vous avez besoin de " + (Convert.ToInt32(textBox1.Text) - FeederDisponible[0]));
               
            }
            if (Convert.ToInt32(textBox2.Text) > FeederDisponible[1])
            {
                MessageBox.Show(" stock insuffisant du feeder " + Coordonnefeeder[1] + " vous avez besoin de " + (Convert.ToInt32(textBox2.Text) - FeederDisponible[1]));
               
            }
            if (Convert.ToInt32(textBox3.Text) > FeederDisponible[2])
            {
                MessageBox.Show(" stock insuffisant du feeder " + Coordonnefeeder[2] + " vous avez besoin de " + (Convert.ToInt32(textBox2.Text) - FeederDisponible[2]));
            }
            if (Convert.ToInt32(textBox4.Text) > FeederDisponible[3])
            {
                MessageBox.Show(" stock insuffisant du feeder " + Coordonnefeeder[3] + " vous avez besoin de " + (Convert.ToInt32(textBox3.Text) - FeederDisponible[3]));
               
            }
            if (Convert.ToInt32(textBox5.Text) > FeederDisponible[4])
            {
                MessageBox.Show(" stock insuffisant du feeder " + Coordonnefeeder[4] + "vous avez besoin de " + (Convert.ToInt32(textBox4.Text) - FeederDisponible[4]));
               
            }
            if (Convert.ToInt32(textBox6.Text) > FeederDisponible[5])
            {
                MessageBox.Show(" stock insuffisant du feeder " + Coordonnefeeder[5] + " vous avez besoin de " + (Convert.ToInt32(textBox5.Text) - FeederDisponible[5]));
               
            }
        /////////////////////2eme test ////////////////    
           for (int j = 0; j < 6; j++)
            {
                if (T[j] > ConfigF[j])
                {
                    MessageBox.Show("Vous avez depassé la configuration maximale "  + Coordonnefeeder[j] + " de " + (T[j] - ConfigF[j]));
                   
                }
            }

           Etat e1 = new Etat();
           {
              
               e1.UF=UF_Combo_Box.Text.ToString();
               e1.Technicien = (Technicien)personne;
               e1.NumEquipe=Convert.ToInt32(equipe);
               


             /*  int[] T3 = new int[6];
            T3[0] = Convert.ToInt32(textBox1.Text);
            T3[1] =  Convert.ToInt32(textBox2.Text);
            T3[2] = Convert.ToInt32(textBox3.Text);
            T3[3] =  Convert.ToInt32(textBox4.Text);
            T3[4] =  Convert.ToInt32(textBox5.Text);
            T3[5] =Convert.ToInt32(textBox6.Text);
            */
               ICollection<Feeder> Feeders=new List<Feeder>();

               for (int j = 0; j < 6; j++)
			{
                   Feeders.Add(new Feeder { Quantite=T[j]});
			}

////////////////////Date//////////////////////////
               IGestionEtat IGE = new GestionEtat();
               string D = DateTime.Text;
               int i1 = D.IndexOf(" ");
               var jour = D.Substring(0, i1);
               var mot1 = D.Substring(i1 + 1);
               int i2 = mot1.IndexOf(" ");
               var jour_nbr = mot1.Substring(0, i2);

               var mot2 = mot1.Substring(i2 + 1);
               int i3 = mot2.IndexOf(" ");
               var mois = mot2.Substring(0, i3);
               var mois_nbr = IGE.GetDate(mois);
               var anne = mot2.Substring(i3 + 1);

               var date = jour_nbr + "-" + mois_nbr + "-" + anne;
               e1.DateCS = date;
/////////////////////////////////////
               e1.Feeders = Feeders;
               this.etat = e1;
               this.verou = false;
             // IGEDAO.AjouterEtat(e1);
           }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IGestionProduitDAO a = new GestionProduitDAO();
            ICollection<Feeder> vect = a.ListerTotaleFeederAccueil();

            foreach (var item in vect)
            {
                MessageBox.Show(item.FedderID +" : "+ item.Quantite);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.verou)
            {
                MessageBox.Show("vous devez verifier les Feeders avant de faire un changement de serie ");
            }
            else
            {
                IGestionEtatDAO IGEDAO = new GestionEtatDAO();
                IGEDAO.AjouterEtat(this.etat);
                this.verou = true;
            }
            }
        
    }
}
