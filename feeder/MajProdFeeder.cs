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
    public partial class MajProdFeeder : Form
    {
        public Boolean Verou;
        public MajProdFeeder()
        {
            
            InitializeComponent();
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            
            foreach (var item in IGPDAO.ListerUF())
            {
               comboBox1.Items.Add(item);
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();

            comboBox2.Items.Clear();
            foreach (var item in IGPDAO.ListerProduit(comboBox1.Text))
            {
                comboBox2.Items.Add(item.Nom);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            var a = comboBox2.Text;
            Produit P = IGPDAO.GetProduitByNom(a);

         

            numericUpDown1.Value= P.Feeders.ElementAt(0).Quantite;
            numericUpDown2.Value = P.Feeders.ElementAt(1).Quantite;
            numericUpDown3.Value = P.Feeders.ElementAt(2).Quantite;
            numericUpDown4.Value = P.Feeders.ElementAt(3).Quantite;
            numericUpDown5.Value = P.Feeders.ElementAt(4).Quantite;
            numericUpDown6.Value = P.Feeders.ElementAt(5).Quantite;

           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            Produit P = new Produit();

            ICollection<Feeder> Feeders = new List<Feeder>();

            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown1.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown2.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown3.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown4.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown5.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown6.Value) });

            P.Feeders = Feeders;

            IGPDAO.ModifierProduit(P, comboBox2.Text);

        }

        private void MajProdFeeder_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
