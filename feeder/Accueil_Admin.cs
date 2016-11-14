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
    public partial class Accueil_Admin : Form
    {
        public Personne Personne;
        public Accueil_Admin(Personne P)
        {
            this.Personne = P;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjouterTechnicien A = new AjouterTechnicien();
            A.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MajProdFeeder MajPFeeder = new MajProdFeeder();
            MajPFeeder.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Changer_MDP CMPA = new Changer_MDP(this.Personne);
            
            CMPA.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MajProdBuse MajP = new MajProdBuse();
            MajP.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ModifConfMAxFeeder MCMF = new ModifConfMAxFeeder();
            MCMF.Show();
        }

        private void Accueil_Admin_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifConfMaxBuse MCMB = new ModifConfMaxBuse();
            MCMB.Show();
        }
    }
}
