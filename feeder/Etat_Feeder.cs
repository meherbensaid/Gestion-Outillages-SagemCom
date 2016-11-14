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
    public partial class Etat_Feeder : Form
    {
        public Etat_Feeder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IGestionEtatDAO IGEDAO = new GestionEtatDAO();
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            Etat a = new Etat();
            IGestionEtat IGE=new GestionEtat();

                string D = dateTimePicker1.Text;
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
            if (comboBox5.Text != "Local")
            {
                a = IGEDAO.GetEtat(comboBox5.Text, date, comboBox2.Text,"f");
                textBox6.Text = ""+a.Feeders.ElementAt(0).Quantite;
                textBox5.Text = ""+a.Feeders.ElementAt(1).Quantite;
                textBox4.Text = ""+a.Feeders.ElementAt(2).Quantite;
                textBox9.Text = ""+a.Feeders.ElementAt(3).Quantite;
                textBox8.Text = ""+a.Feeders.ElementAt(4).Quantite;
                textBox7.Text = ""+a.Feeders.ElementAt(5).Quantite;
            }
            else
            {
                ICollection<Feeder> FeederdanslesUF = IGPDAO.ListerTotaleFeederAccueil(date,comboBox2.Text, "f");
                ICollection<Feeder> FeederDansUsine = IGPDAO.ListerTotaleFeederUsine();
                textBox6.Text = "" +( FeederDansUsine.ElementAt(0).Quantite - FeederdanslesUF.ElementAt(0).Quantite);
                textBox5.Text = "" +( FeederDansUsine.ElementAt(1).Quantite - FeederdanslesUF.ElementAt(1).Quantite);
                textBox4.Text = "" +( FeederDansUsine.ElementAt(2).Quantite - FeederdanslesUF.ElementAt(2).Quantite);
                textBox9.Text = "" +( FeederDansUsine.ElementAt(3).Quantite - FeederdanslesUF.ElementAt(3).Quantite);
                textBox8.Text = "" + (FeederDansUsine.ElementAt(4).Quantite - FeederdanslesUF.ElementAt(4).Quantite);
                textBox7.Text = "" + (FeederDansUsine.ElementAt(5).Quantite - FeederdanslesUF.ElementAt(5).Quantite);
            }
           
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
