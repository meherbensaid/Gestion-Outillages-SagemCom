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
    public partial class Buse2 : Form
    {
        public string jour;
        public string equipe;
        public Personne Personne;
        public Etat etat;
        public Boolean verou;
        public Boolean verou1;
        public Buse2(string jour, string equipe, Personne P)
        {
            this.jour = jour;
            this.equipe = equipe;
            this.Personne = P;
            this.verou = true;
            this.verou1 = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void Buse2_Load(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            ICollection<Produit> Produits = new List<Produit>();



            foreach (var item in IGPDAO.ListerUF())
            {
                UF_Combo_Box.Items.Add(item);

            }

        }

        /// <summary>
        /// ////////////////////////////////////Get All Text Box////////////////////////////////
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>

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
        ICollection<TextBox> AddLAbel(Control ctrl)
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


        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////::
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /////////////////////////////////Get All Label ////////////////::

        ICollection<Label> GetLAbel(Control ctrl)
        {
            ICollection<Label> Labels = new List<Label>();
            foreach (Control subCtrl in ctrl.Controls)
            {
                if (subCtrl.HasChildren)
                {
                    GetLAbel(subCtrl);
                }
                var box = subCtrl as Label;
                if (box != null)
                {
                    Labels.Add(box);
                }

            }
            return Labels;
        }
        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void Calcul_Click(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            ICollection<Buse> AnciensBuses = new List<Buse>();
            ICollection<Buse> NouveauxBuses = new List<Buse>();

            AnciensBuses = IGPDAO.ListerBuses(AP_Combo_Box.Text);
            NouveauxBuses = IGPDAO.ListerBuses(NP_Combo_Box.Text);


            ICollection<TextBox> textBox = new List<TextBox>();
            textBox = AddTextBoxes(this);
            int k = 0;
            for (int i = 33; i > 0; i--)
            {
                textBox.ElementAt(k).Text = "" + (NouveauxBuses.ElementAt(i - 1).Quantite - AnciensBuses.ElementAt(i - 1).Quantite);
                k++;
            }

            /*textBox1.Text = "" + (NouveauxBuses.ElementAt(0).Quantite - AnciensBuses.ElementAt(0).Quantite);
            textBox2.Text = "" + (NouveauxBuses.ElementAt(1).Quantite - AnciensBuses.ElementAt(1).Quantite);
            textBox3.Text = "" + (NouveauxBuses.ElementAt(2).Quantite - AnciensBuses.ElementAt(2).Quantite);
            textBox4.Text = "" + (NouveauxBuses.ElementAt(3).Quantite - AnciensBuses.ElementAt(3).Quantite);
            textBox5.Text = "" + (NouveauxBuses.ElementAt(4).Quantite - AnciensBuses.ElementAt(4).Quantite);
            
            textBox6.Text = "" + (NouveauxBuses.ElementAt(5).Quantite - AnciensBuses.ElementAt(5).Quantite);
            textBox7.Text = "" + (NouveauxBuses.ElementAt(6).Quantite - AnciensBuses.ElementAt(6).Quantite);
            textBox8.Text = "" + (NouveauxBuses.ElementAt(7).Quantite - AnciensBuses.ElementAt(7).Quantite);
            textBox9.Text = "" + (NouveauxBuses.ElementAt(8).Quantite - AnciensBuses.ElementAt(8).Quantite);
            textBox10.Text = "" + (NouveauxBuses.ElementAt(9).Quantite - AnciensBuses.ElementAt(9).Quantite);
            textBox11.Text = "" + (NouveauxBuses.ElementAt(10).Quantite - AnciensBuses.ElementAt(10).Quantite);
            textBox12.Text = "" + (NouveauxBuses.ElementAt(11).Quantite - AnciensBuses.ElementAt(11).Quantite);
            textBox13.Text = "" + (NouveauxBuses.ElementAt(12).Quantite - AnciensBuses.ElementAt(12).Quantite);
            textBox14.Text = "" + (NouveauxBuses.ElementAt(13).Quantite - AnciensBuses.ElementAt(13).Quantite);
            textBox15.Text = "" + (NouveauxBuses.ElementAt(14).Quantite - AnciensBuses.ElementAt(14).Quantite);
            textBox16.Text = "" + (NouveauxBuses.ElementAt(15).Quantite - AnciensBuses.ElementAt(15).Quantite);
            textBox17.Text = "" + (NouveauxBuses.ElementAt(16).Quantite - AnciensBuses.ElementAt(16).Quantite);
            textBox18.Text = "" + (NouveauxBuses.ElementAt(17).Quantite - AnciensBuses.ElementAt(17).Quantite);
            textBox19.Text = "" + (NouveauxBuses.ElementAt(18).Quantite - AnciensBuses.ElementAt(18).Quantite);
            textBox20.Text = "" + (NouveauxBuses.ElementAt(19).Quantite - AnciensBuses.ElementAt(19).Quantite);
            textBox21.Text = "" + (NouveauxBuses.ElementAt(20).Quantite - AnciensBuses.ElementAt(20).Quantite);
            textBox22.Text = "" + (NouveauxBuses.ElementAt(21).Quantite - AnciensBuses.ElementAt(21).Quantite);
            textBox23.Text = "" + (NouveauxBuses.ElementAt(22).Quantite - AnciensBuses.ElementAt(22).Quantite);
            textBox24.Text = "" + (NouveauxBuses.ElementAt(23).Quantite - AnciensBuses.ElementAt(23).Quantite);
            textBox25.Text = "" + (NouveauxBuses.ElementAt(24).Quantite - AnciensBuses.ElementAt(24).Quantite);
            textBox26.Text = "" + (NouveauxBuses.ElementAt(25).Quantite - AnciensBuses.ElementAt(25).Quantite);
            textBox27.Text = "" + (NouveauxBuses.ElementAt(26).Quantite - AnciensBuses.ElementAt(26).Quantite);
            textBox28.Text = "" + (NouveauxBuses.ElementAt(27).Quantite - AnciensBuses.ElementAt(27).Quantite);
            textBox29.Text = "" + (NouveauxBuses.ElementAt(28).Quantite - AnciensBuses.ElementAt(28).Quantite);
            textBox30.Text = "" + (NouveauxBuses.ElementAt(29).Quantite - AnciensBuses.ElementAt(29).Quantite);
            textBox31.Text = "" + (NouveauxBuses.ElementAt(30).Quantite - AnciensBuses.ElementAt(30).Quantite);
            textBox32.Text = "" + (NouveauxBuses.ElementAt(31).Quantite - AnciensBuses.ElementAt(31).Quantite);
            textBox33.Text = "" + (NouveauxBuses.ElementAt(32).Quantite - AnciensBuses.ElementAt(32).Quantite);
                */
            this.verou1 = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (this.verou1)
            {
                MessageBox.Show("Vous devez appuiyer sur le boutton calcul d'abord");
            }
            else { 
            IGestionEtatDAO IGEDAO = new GestionEtatDAO();
            IGestionConfigurationDAO IGCDAO = new GestionConfigurationDAO();
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();

            ICollection<Buse> TotaleBusesDansUF = new List<Buse>();
            ICollection<Buse> TotaleBusesInLocale = new List<Buse>();

            ICollection<Buse> BusesConfig = new List<Buse>();


            Etat etat = IGEDAO.RechercherDernierEtat(UF_Combo_Box.Text,"b");
            BusesConfig = IGCDAO.ConfigBuse(UF_Combo_Box.Text);

            int[] ConfigB = new int[33];
            string[] ConfigBusesID = new string[33];
            int[] DernierEtatB = new int[33];
            int i = 0;
            foreach (var item in BusesConfig)
            {
                ConfigB[i] = item.Quantite;
                ConfigBusesID[i] = item.coordonnee;
                i++;
            }
            i = 0;
            foreach (var item in etat.Buses)
            {
                DernierEtatB[i] = item.Quantite;
                i++;
            }

            string[] CoordonneBuses = new string[33];
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

            int[] T = new int[33];

            ICollection<TextBox> TextBoxs = new List<TextBox>();
            TextBoxs = AddLAbel(this);
            int w = 0;
            for (int j = 33; j > 0; j--)
            {

                T[w] = DernierEtatB[w] + Convert.ToInt32(TextBoxs.ElementAt(j - 1).Text);
                w++;
            }
            TotaleBusesDansUF = IGPDAO.ListerTotaleBuseAccueil();
            TotaleBusesInLocale = IGPDAO.ListerTotaleBusesUsine();

            int[] TotaleBusesDansUF1 = new int[33];
            int[] TotaleBusesInLocale1 = new int[33];
            int[] BusesDisponible = new int[33];
            var k = 0;

            foreach (var item in TotaleBusesDansUF)
            {
                TotaleBusesDansUF1[k] = item.Quantite;
                k++;
            }
            k = 0;
            foreach (var item in TotaleBusesInLocale)
            {
                TotaleBusesInLocale1[k] = item.Quantite;
                k++;
            }

            for (int u = 0; u < 33; u++)
            {
                BusesDisponible[u] = TotaleBusesInLocale1[u] - TotaleBusesDansUF1[u];
            }

            int tmp = 0;
            for (int m = 32; m >= 0; m--)
            {

                if (Convert.ToInt32(TextBoxs.ElementAt(m).Text) > BusesDisponible[tmp])
                {
                    MessageBox.Show(" stock insuffisant du Buses " + CoordonneBuses[tmp] + " vous avez besoin de " + (Convert.ToInt32(TextBoxs.ElementAt(m).Text) - BusesDisponible[tmp]));

                }
                tmp++;
            }

            ////////////////2eme test ////////////


            for (int j = 0; j < 6; j++)
            {
                if (T[j] > ConfigB[j])
                {
                    MessageBox.Show("Vous avez depassé la configuration maximale " + CoordonneBuses[j] + " de " + (T[j] - ConfigB[j]));

                }
            }

            Etat e1 = new Etat();


            e1.UF = UF_Combo_Box.Text.ToString();
            e1.Technicien = (Technicien)Personne;
            e1.NumEquipe = Convert.ToInt32(equipe);
            ICollection<Buse> Buses = new List<Buse>();

            for (int j = 0; j < 33; j++)
            {
                Buses.Add(new Buse { Quantite = T[j] });
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
            e1.Buses = Buses;
            this.etat = e1;
            this.verou = false;
             //;/////////////////////// Foued : est se que je fais une separation entre l'ajout d'etat d'un changement de serie de feeeder et de buses wala lé ? ////

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IGestionEtatDAO IGEDAO = new GestionEtatDAO();
            if (this.verou)
            {
                MessageBox.Show("vous devez faire la verification tout d'abord");
            }
            else
            {
                IGEDAO.AjouterEtatBuses(this.etat);
            }
        }
    }
}
