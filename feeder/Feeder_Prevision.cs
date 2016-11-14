using feeder.DAL;
using feeder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace feeder
{
    public partial class Feeder_Prevision : Form
    {
        public Etat Etat;
        public ICollection<Etat> Etats;
        public int  suivant;
        public static int variable = 0;
        public int etat_initial;
        public  int verou_poste;
        public ICollection<Feeder_Prevision> Previsions;
        public int cmp;

        public Feeder_Prevision(Etat Etat, ICollection<Etat> Etats,int cmp)
        {this.cmp=cmp;
           // this.etat_initial = etat_initial;
            this.Etat = Etats.ElementAt(0);
            this.Etats = Etats;
           // this.Text = "meher";
           
            InitializeComponent();
            this.Text = "jour : " + this.Etat.DateCS + " poste : " + this.Etat.NumEquipe;
        }

       /* public Feeder_Prevision(Etat Etat, ICollection<Etat> Etats, int suivant, int etat_initial)
        {
            this.etat_initial = etat_initial;
            this.Etat = Etat;
            this.Etats = Etats;
            this.suivant =suivant;
            InitializeComponent();
            this.Text = "jour : " + Etat.DateCS + " poste : " + Etat.NumEquipe;
            this.verou_poste = this.etat_initial;
        }
        */
        private void Feeder_Prevision_Load(object sender, EventArgs e)
        {
            if (this.Etats.Count == cmp)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Meher_\Documents\Visual Studio 2013\Projects\feeder_meher\feeder\bin\Debug\Rapport_Prevision.txt", false))
                {
                   
                }
            }
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();

            foreach (var item1 in IGPDAO.ListerProduit(Etat.UF))
            {
                AP_Combo_Box.Items.Add(item1.Nom);

                NP_Combo_Box.Items.Add(item1.Nom);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                    
                    IGestionEtatDAO IGEDAO = new GestionEtatDAO();
                    IGestionConfigurationDAO IGCDAO = new GestionConfigurationDAO();
                    IGestionProduitDAO IGPDAO = new GestionProduitDAO();

                    ICollection<Feeder> TotaleFeederDansUF = new List<Feeder>();
                    ICollection<Feeder> TotaleFeederInLocale = new List<Feeder>();

                    ICollection<Feeder> FeedersConfig = new List<Feeder>();

                    string UF = Etat.UF;
                    Etat etat = null;



                    if (variable == 0)
                    {
                        etat = IGEDAO.RechercherDernierEtat(UF,"f");
                        variable++;

                    }
                    else
                    {
                        etat = IGEDAO.EtatPrevision();

                    }

                    etat.DateCS = this.Etat.DateCS;
                    etat.NumEquipe = this.Etat.NumEquipe;
                    etat.UF = Etat.UF;

                    /* Etat etat_meher = new Etat();
                     etat_meher.UF = UF;
                     etat_meher.DateCS = this.Etat.DateCS;
                     etat_meher.NumEquipe = this.Etat.NumEquipe;

                     int[] Tab_feeder_quantite = new int[6];
                     int m = 0; 
                    foreach (var item in etat.Feeders)
                     {
                         Tab_feeder_quantite[m] = item.Quantite;
                         m++; 
                    }
                    ICollection<Feeder> Feederrs = new List<Feeder>();
                    for (int l = 0; l <6; l++)
                    {
                        Feederrs.Add(new Feeder { Quantite = Tab_feeder_quantite[l] ,FedderID="TF"+(l+1)});
                    }
                     etat_meher.Feeders = Feederrs;
                    */


                    FeedersConfig = IGCDAO.ConfigFeeder(Etat.UF);



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

                    int[] T = new int[6];
                    T[0] = DernierEtatF[0] + Convert.ToInt32(textBox1.Text);
                    T[1] = DernierEtatF[1] + Convert.ToInt32(textBox2.Text);
                    T[2] = DernierEtatF[2] + Convert.ToInt32(textBox3.Text);
                    T[3] = DernierEtatF[3] + Convert.ToInt32(textBox4.Text);
                    T[4] = DernierEtatF[4] + Convert.ToInt32(textBox5.Text);
                    T[5] = DernierEtatF[5] + Convert.ToInt32(textBox6.Text);

                    string[] Coordonnefeeder = new string[6];
                    Coordonnefeeder[0] = "F2X8";
                    Coordonnefeeder[1] = "F12X16";
                    Coordonnefeeder[2] = "F24X32";
                    Coordonnefeeder[3] = "F44X56";
                    Coordonnefeeder[4] = "F72";
                    Coordonnefeeder[5] = "F88";

                    TotaleFeederDansUF = IGPDAO.ListerTotaleFeederAccueil();
                    TotaleFeederInLocale = IGPDAO.ListerTotaleFeederUsine();

                    int[] TotaleFeederDansUF1 = new int[6];
                    int[] TotaleFeederInLocale1 = new int[6];
                    int[] FeederDisponible = new int[6];

                   // var test1 = true;
                    for (int j = 0; j < 6; j++)
                    {
                        if (T[j] > ConfigF[j])
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Meher_\Documents\Visual Studio 2013\Projects\feeder_meher\feeder\bin\Debug\Rapport_Prevision.txt", true))
                            {
                                file.WriteLine("Vous avez depassé la configuration maximale" + Coordonnefeeder[j] + " de " + (T[j] - ConfigF[j]) + " Feederes pour le "+this.Etat.DateCS+" poste N°"+this.Etat.NumEquipe);
                               
                            }
                            MessageBox.Show("Vous avez depassé la configuration maximale" + Coordonnefeeder[j] + " de " + (T[j] - ConfigF[j]) + " Feederes pour le "+this.Etat.DateCS);
                           
                        }
                    }
                    ICollection<Feeder> Feeders1 = new List<Feeder>();


                    
                        for (int w = 0; w < 6; w++)
                        {
                            Feeders1.Add(new Feeder { Quantite = T[w] });
                        }
                        etat.Feeders = Feeders1;
                        IGEDAO.AjouterPrevision(etat);
                        if (Etats.Count-1 > 0)
                        {
                            Etats.Remove(this.Etat);
                            Close();
                            Feeder_Prevision suivant = new Feeder_Prevision(Etats.ElementAt(0), Etats,cmp);
                            suivant.Show();
                        }
                        
                       
                }
                
            
            catch(Exception  ){
                MessageBox.Show("les champs doivent etre remplis par des chiffres");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            ICollection<Feeder> Anciensfeeders = new List<Feeder>();
            ICollection<Feeder> Nouveauxfeeders = new List<Feeder>();

            Anciensfeeders = IGPDAO.ListerFeeder(AP_Combo_Box.Text);
            Nouveauxfeeders = IGPDAO.ListerFeeder(NP_Combo_Box.Text);
            int i = 0;
            int[] NF = new int[6];
            int[] AF = new int[6];
            foreach (var item in Anciensfeeders)
            {
                AF[i] = item.Quantite;
                i++;
            }


            i = 0;
            foreach (var item in Nouveauxfeeders)
            {
                NF[i] = item.Quantite;
                i++;
            }
            textBox1.Text = (NF[0] - AF[0]).ToString();
            textBox2.Text = (NF[1] - AF[1]).ToString();
            textBox3.Text = (NF[2] - AF[2]).ToString();
            textBox4.Text = (NF[3] - AF[3]).ToString();
            textBox5.Text = (NF[4] - AF[4]).ToString();
            textBox6.Text = (NF[5] - AF[5]).ToString();
        }
    }
}
