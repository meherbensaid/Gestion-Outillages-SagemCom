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
    public partial class Etat_Buse : Form
    {
        public Etat_Buse()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {
            IGestionEtatDAO IGEDAO = new GestionEtatDAO();
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            Etat a = new Etat();
            IGestionEtat IGE = new GestionEtat();

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
                a = IGEDAO.GetEtat(comboBox5.Text, date, comboBox2.Text, "b");
                ICollection<TextBox> TextBoxes = AddTextBoxes(this);
                int k = 0;
                for (int i = 33; i > 0; i--)
                {
                    TextBoxes.ElementAt(k).Text = "" + a.Buses.ElementAt(i - 1).Quantite ;
                    k++;
                }
            }
            else
            {
                ICollection<Buse> BuseUsine=IGPDAO.ListerTotaleBusesUsine();
                ICollection<Buse> BuseinallUF = IGPDAO.ListerTotaleBuseAccueil(date, comboBox2.Text, "b");
                int k = 0;
                for (int i = 33; i > 0; i--)
                {
                    ICollection<TextBox> TextBoxes = AddTextBoxes(this);
                    TextBoxes.ElementAt(k).Text = "" + (BuseUsine.ElementAt(i - 1).Quantite - BuseinallUF.ElementAt(i - 1).Quantite);
                    k++;
                }
            }
            
        }
    }
}
