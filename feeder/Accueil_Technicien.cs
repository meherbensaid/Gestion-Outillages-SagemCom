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
    public partial class Accueil_Technicien : Form
    {
        public Personne Personne;
        public Accueil_Technicien(Personne P  )
        {
            this.Name = "Accueil";
            this.Personne = P;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Feeder1 f1 = new Feeder1(Personne);
            f1.Show();
        }

        private void AjoutTech_Click(object sender, EventArgs e)
        {
            AjouterTechnicien AT = new AjouterTechnicien();
            AT.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          Changer_MDP CMP=new Changer_MDP(this.Personne );
            CMP.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Buse1 B = new Buse1(this.Personne);
            B.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Prevision P = new Prevision();
            P.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Prevision2 P = new Prevision2();
            P.Show();
        }

        private void Etat_feeder_Click(object sender, EventArgs e)
        {
            Etat_Feeder EF = new Etat_Feeder();
            EF.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Etat_Buse EB = new Etat_Buse();
            EB.Show();
        }
    }
}
