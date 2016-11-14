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
    public partial class ModifConfMaxBuse : Form
    {
        public ModifConfMaxBuse()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ModifConfMaxBuse_Load(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();

            comboBox1.Items.Clear();
            foreach (var item in IGPDAO.ListerUF())
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IGestionConfigurationDAO IGCDAO = new GestionConfigurationDAO();
           
            ICollection<Buse> P = IGCDAO.ConfigBuse(comboBox1.Text);
            textBox1.Text = P.ElementAt(0).Quantite.ToString();
            textBox2.Text = P.ElementAt(1).Quantite.ToString();
            textBox3.Text = P.ElementAt(2).Quantite.ToString();
            textBox4.Text = P.ElementAt(3).Quantite.ToString();
            textBox5.Text = P.ElementAt(4).Quantite.ToString();
            textBox6.Text = P.ElementAt(5).Quantite.ToString();
            textBox7.Text = P.ElementAt(6).Quantite.ToString();
            textBox8.Text = P.ElementAt(7).Quantite.ToString();
            textBox9.Text = P.ElementAt(8).Quantite.ToString();
            textBox10.Text = P.ElementAt(9).Quantite.ToString();
            textBox11.Text = P.ElementAt(10).Quantite.ToString();
            textBox12.Text = P.ElementAt(11).Quantite.ToString();
            textBox13.Text = P.ElementAt(12).Quantite.ToString();
            textBox14.Text = P.ElementAt(13).Quantite.ToString();
            textBox15.Text = P.ElementAt(14).Quantite.ToString();
            textBox16.Text = P.ElementAt(15).Quantite.ToString();
            textBox17.Text = P.ElementAt(16).Quantite.ToString();
            textBox18.Text = P.ElementAt(17).Quantite.ToString();
            textBox19.Text = P.ElementAt(18).Quantite.ToString();
            textBox20.Text = P.ElementAt(19).Quantite.ToString();
            textBox21.Text = P.ElementAt(20).Quantite.ToString();
            textBox22.Text = P.ElementAt(21).Quantite.ToString();
            textBox23.Text = P.ElementAt(22).Quantite.ToString();
            textBox24.Text = P.ElementAt(23).Quantite.ToString();
            textBox25.Text = P.ElementAt(24).Quantite.ToString();
            textBox26.Text = P.ElementAt(25).Quantite.ToString();
            textBox27.Text = P.ElementAt(26).Quantite.ToString();
            textBox28.Text = P.ElementAt(27).Quantite.ToString();
            textBox29.Text = P.ElementAt(28).Quantite.ToString();
            textBox30.Text = P.ElementAt(29).Quantite.ToString();
            textBox31.Text = P.ElementAt(30).Quantite.ToString();
            textBox32.Text = P.ElementAt(31).Quantite.ToString();
            textBox33.Text = P.ElementAt(32).Quantite.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IGestionConfigurationDAO IGCDAO = new GestionConfigurationDAO();
            

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


           

            IGCDAO.ModifierConfigmaxBuse(Buses, comboBox1.Text);
        }
    }
}
