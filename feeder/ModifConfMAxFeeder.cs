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
    public partial class ModifConfMAxFeeder : Form
    {
        public ModifConfMAxFeeder()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IGestionConfigurationDAO IGCDAO = new GestionConfigurationDAO();
            ICollection<Feeder> Feeders = IGCDAO.ConfigFeeder(comboBox1.Text);

            numericUpDown1.Value = Feeders.ElementAt(0).Quantite;
            numericUpDown2.Value = Feeders.ElementAt(1).Quantite;
            numericUpDown3.Value = Feeders.ElementAt(2).Quantite;
            numericUpDown4.Value = Feeders.ElementAt(3).Quantite;
            numericUpDown5.Value =Feeders.ElementAt(4).Quantite;
            numericUpDown6.Value =Feeders.ElementAt(5).Quantite;
        }

        private void ModifConfMAxFeeder_Load(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();

            foreach (var item in IGPDAO.ListerUF())
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IGestionConfigurationDAO IGCDAO = new GestionConfigurationDAO();
           

            ICollection<Feeder> Feeders = new List<Feeder>();

            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown1.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown2.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown3.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown4.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown5.Value) });
            Feeders.Add(new Feeder { Quantite = Convert.ToInt32(numericUpDown6.Value) });
            IGCDAO.ModifierConfigmax(Feeders, comboBox1.Text);

        }
    }
}
