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
    public partial class Buse_Prevision_ : Form
    {
        public Etat Etat;
        public ICollection<Etat> Etats;
        public int suivant;
        public static int variable = 0;
        public int etat_initial;
        public int verou_poste;
        public int cmp;
        public Boolean verou2;
        public Buse_Prevision_()
        {
           
            InitializeComponent();

        }
        public Buse_Prevision_(Etat Etat, ICollection<Etat> Etats,int cmp)
        {
            this.cmp = cmp;
            this.Etat = Etats.ElementAt(0);
            this.Etats = Etats;
            this.verou2 = true;
           
            InitializeComponent();
            this.Text = "jour : " + this.Etat.DateCS + " poste : " + this.Etat.NumEquipe;
           
        }
        ICollection<TextBox> AddTextBoxes(Control ctrl)
        {
            ICollection<TextBox> textBoxes = new List<TextBox>();
            foreach (Control subCtrl in ctrl.Controls)
            {
                if (subCtrl.HasChildren)
                {
                    AddTextBoxes(subCtrl);
                }
                var box = subCtrl as TextBox;
                if (box != null)
                {
                    textBoxes.Add(box);
                }

            }
            return textBoxes;
        }

        private void test_Load(object sender, EventArgs e)
        {
            if (this.Etats.Count == cmp)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Meher_\Documents\Visual Studio 2013\Projects\feeder_meher\feeder\bin\Debug\Rapport_Prevision_Buse.txt", false))
                {

                }
            }
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();

            foreach (var item1 in IGPDAO.ListerProduit(this.Etat.UF))
            {
                comboBox1.Items.Add(item1.Nom);
                comboBox2.Items.Add(item1.Nom);
               
            }
        }

        private void calcul_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("vous devez choisir l'ancien produit");
            }

            else if (comboBox2.Text == "")
            {
                MessageBox.Show("vous devez choisir le nouveau produit");
            }
            else { 
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            ICollection<Buse> AnciensBuses = new List<Buse>();
            ICollection<Buse> NouveauxBuses = new List<Buse>();

            AnciensBuses = IGPDAO.ListerBuses(comboBox1.Text);
            NouveauxBuses = IGPDAO.ListerBuses(comboBox2.Text);
            ICollection<TextBox> TextBoxes = AddTextBoxes(this);


            int k = 0;
            for (int i = 33; i > 0; i--)
            {
                TextBoxes.ElementAt(k).Text = "" + (NouveauxBuses.ElementAt(i - 1).Quantite - AnciensBuses.ElementAt(i - 1).Quantite);
                k++;
            }
            this.verou2 = false;
        
        }}

        private void verif_Click(object sender, EventArgs e)
        {
            if (this.verou2)
            {


                MessageBox.Show("vous devez appuiyer sur le boutton calcul");

            }
            else
            {



                IGestionEtatDAO IGEDAO = new GestionEtatDAO();
                IGestionConfigurationDAO IGCDAO = new GestionConfigurationDAO();
                IGestionProduitDAO IGPDAO = new GestionProduitDAO();

                ICollection<Buse> TotaleBuseDansUF = new List<Buse>();
                ICollection<Buse> TotaleBuseInLocale = new List<Buse>();

                ICollection<Buse> BusesConfig = new List<Buse>();

                string UF = Etat.UF;
                Etat etat = null;



                if (variable == 0)
                {
                    etat = IGEDAO.RechercherDernierEtat(UF, "b");
                    variable++;

                }
                else
                {
                    etat = IGEDAO.EtatPrevision();

                }

                etat.DateCS = this.Etat.DateCS;
                etat.NumEquipe = this.Etat.NumEquipe;
                etat.UF = Etat.UF;



                BusesConfig = IGCDAO.ConfigBuse(Etat.UF);



                int[] ConfigB = new int[33];
                string[] ConfigBuseID = new string[33];
                int[] DernierEtatB = new int[33];
                int i = 0;
                foreach (var item in BusesConfig)
                {
                    ConfigB[i] = item.Quantite;
                    ConfigBuseID[i] = item.coordonnee;
                    i++;
                }
                i = 0;
                foreach (var item in etat.Buses)
                {
                    DernierEtatB[i] = item.Quantite;
                    i++;
                }

                ICollection<TextBox> TextBoxes = this.AddTextBoxes(this);
                int[] T = new int[33];
                int k = 0;
                for (int a = 32; a >= 0; a--)
                {


                    T[k] = DernierEtatB[k] + Convert.ToInt32(TextBoxes.ElementAt(a).Text);
                    k++;
                }



                TotaleBuseDansUF = IGPDAO.ListerTotaleBuseAccueil();
                TotaleBuseInLocale = IGPDAO.ListerTotaleBusesUsine();

                int[] TotaleBuseDansUF1 = new int[33];
                int[] TotaleBuseInLocale1 = new int[33];
                int[] BuseDisponible = new int[33];

                string [] CoordonneBuses=new string[33];
                CoordonneBuses[0] = "110S";
                CoordonneBuses[1] = "115S";
                CoordonneBuses[2] = "120S";
                CoordonneBuses[3] = "130S";
                CoordonneBuses[4] = "235S";
                CoordonneBuses[5] = "110";
                CoordonneBuses[6] = "115";
                CoordonneBuses[7] = "120";
                CoordonneBuses[8] = "130";
                CoordonneBuses[9] = "140";
                CoordonneBuses[10] = "185";
                CoordonneBuses[11] = "235";
                CoordonneBuses[12] = "1002";
                CoordonneBuses[13] = "1003";
                CoordonneBuses[14] = "1004";
                CoordonneBuses[15] = "1005";
                CoordonneBuses[16] = "1006";
                CoordonneBuses[17] = "1159";
                CoordonneBuses[18] = "1647";
                CoordonneBuses[19] = "5700";
                CoordonneBuses[20] = "1403";
                CoordonneBuses[21] = "5490";
                CoordonneBuses[22] = "1001";
                CoordonneBuses[23] = "4498";
                CoordonneBuses[24] = "5150";
                CoordonneBuses[25] = "240S";
                CoordonneBuses[26] = "5739";
                CoordonneBuses[27] = "1497";
                CoordonneBuses[28] = "2013";
                CoordonneBuses[29] = "111";
                CoordonneBuses[30] = "112";
                CoordonneBuses[31] = "113";
                CoordonneBuses[32] = "161";
                // var test1 = true;
                for (int j = 0; j < 33; j++)
                {
                    if (T[j] > ConfigB[j])
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Meher_\Documents\Visual Studio 2013\Projects\feeder_meher\feeder\bin\Debug\Rapport_Prevision_Buse.txt", true))
                        {
                            file.WriteLine("Vous avez depassé la configuration maximale" + CoordonneBuses[j] + " de " + (T[j] - ConfigB[j]) + " Buses pour le "+this.Etat.DateCS+" poste N°"+this.Etat.NumEquipe);
                        }
                        MessageBox.Show("Vous avez depassé la configuration maximale" + CoordonneBuses[j] + " de " + (T[j] - ConfigB[j]) + " Buses pour le "+this.Etat.DateCS+" poste N°"+this.Etat.NumEquipe);

                    }
                }
                ICollection<Buse> Buses1 = new List<Buse>();



                for (int w = 0; w < 33; w++)
                {
                    Buses1.Add(new Buse { Quantite = T[w] });
                }
                etat.Buses = Buses1;
                IGEDAO.AjouterPrevision(etat);
                if (Etats.Count - 1 > 0)
                {
                    Etats.Remove(this.Etat);
                    Close();
                    Buse_Prevision_ suivant = new Buse_Prevision_(Etats.ElementAt(0), Etats, this.cmp);
                    suivant.Show();
                }

            }

            
          
        }
    }
}
