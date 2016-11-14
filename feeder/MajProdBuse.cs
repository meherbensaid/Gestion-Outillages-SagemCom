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
    public partial class MajProdBuse : Form
    {
        public MajProdBuse()
        {
            InitializeComponent();
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();

            foreach (var item in IGPDAO.ListerUF())
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            var a = comboBox2.Text;
            Produit P = IGPDAO.GetProduitByNom(a);
            textBox1.Text = P.Buses.ElementAt(0).Quantite.ToString() ;
            textBox2.Text = P.Buses.ElementAt(1).Quantite.ToString();
            textBox3.Text = P.Buses.ElementAt(2).Quantite.ToString();
            textBox4.Text = P.Buses.ElementAt(3).Quantite.ToString();
            textBox5.Text = P.Buses.ElementAt(4).Quantite.ToString();
            textBox6.Text = P.Buses.ElementAt(5).Quantite.ToString();
            textBox7.Text = P.Buses.ElementAt(6).Quantite.ToString();
            textBox8.Text = P.Buses.ElementAt(7).Quantite.ToString();
            textBox9.Text = P.Buses.ElementAt(8).Quantite.ToString();
            textBox10.Text = P.Buses.ElementAt(9).Quantite.ToString();
            textBox11.Text = P.Buses.ElementAt(10).Quantite.ToString();
            textBox12.Text = P.Buses.ElementAt(11).Quantite.ToString();
            textBox13.Text = P.Buses.ElementAt(12).Quantite.ToString();
            textBox14.Text = P.Buses.ElementAt(13).Quantite.ToString();
            textBox15.Text = P.Buses.ElementAt(14).Quantite.ToString();
            textBox16.Text = P.Buses.ElementAt(15).Quantite.ToString();
            textBox17.Text = P.Buses.ElementAt(16).Quantite.ToString();
            textBox18.Text = P.Buses.ElementAt(17).Quantite.ToString();
            textBox19.Text = P.Buses.ElementAt(18).Quantite.ToString();
            textBox20.Text = P.Buses.ElementAt(19).Quantite.ToString();
            textBox21.Text = P.Buses.ElementAt(20).Quantite.ToString();
            textBox22.Text = P.Buses.ElementAt(21).Quantite.ToString();
            textBox23.Text = P.Buses.ElementAt(22).Quantite.ToString();
            textBox24.Text = P.Buses.ElementAt(23).Quantite.ToString();
            textBox25.Text = P.Buses.ElementAt(24).Quantite.ToString();
            textBox26.Text = P.Buses.ElementAt(25).Quantite.ToString();
            textBox27.Text = P.Buses.ElementAt(26).Quantite.ToString();
            textBox28.Text = P.Buses.ElementAt(27).Quantite.ToString();
            textBox29.Text = P.Buses.ElementAt(28).Quantite.ToString();
            textBox30.Text = P.Buses.ElementAt(29).Quantite.ToString();
            textBox31.Text = P.Buses.ElementAt(30).Quantite.ToString();
            textBox32.Text = P.Buses.ElementAt(31).Quantite.ToString();
            textBox33.Text = P.Buses.ElementAt(32).Quantite.ToString();
        }

        private void MajProdBuse_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            Produit P = new Produit();

            ICollection<Buse> Buses = new List<Buse>();

            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox1.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox2.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox3.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox4.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox5.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox6.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox7.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox8.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox9.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox10.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox11.Text) });

            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox12.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox13.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox14.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox15.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox16.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox17.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox18.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox19.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox20.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox21.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox22.Text) });


            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox23.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox24.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox25.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox26.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox27.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox28.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox29.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox30.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox31.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox32.Text) });
            Buses.Add(new Buse { Quantite = Convert.ToInt32(textBox33.Text) });


            P.Buses = Buses;

            IGPDAO.ModifierProduitBuse(P, comboBox2.Text);

        }
    }
}
