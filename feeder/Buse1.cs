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
    public partial class Buse1 : Form
    {
        Personne Personne;
        public Buse1(Personne P)
        {
            this.Personne = P;
            InitializeComponent();
        }



        private void BL1_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Lundi", "1", this.Personne);
            fm2.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Lundi", "2", this.Personne);
            fm2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Lundi", "3", this.Personne);
            fm2.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Mardi", "1", this.Personne);
            fm2.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Mardi", "2", this.Personne);
            fm2.Show();
        }

       

       private void button5_Click_1(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Mercredi", "1", this.Personne);
            fm2.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Mercredi", "2", this.Personne);
            fm2.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Mercredi", "3", this.Personne);
            fm2.Show();
        }

       
       
         private void button12_Click_1(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Jeudi", "1", this.Personne);
            fm2.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Jeudi", "2", this.Personne);
            fm2.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Jeudi", "3", this.Personne);
            fm2.Show();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Vendredi", "1", this.Personne);
            fm2.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            Buse2 fm2 = new Buse2("Vendredi", "2", this.Personne);
            fm2.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            Buse2 fm2 = new Buse2("Vendredi", "3", this.Personne);
            fm2.Show();
        }

        
        private void button9_Click_1(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Mardi", "3", this.Personne);
            fm2.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Samedi", "1", this.Personne);
            fm2.Show(); 
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Samedi", "2", this.Personne);
            fm2.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Samedi", "3", this.Personne);
            fm2.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Dimanche", "1", this.Personne);
            fm2.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Dimanche", "2", this.Personne);
            fm2.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Buse2 fm2 = new Buse2("Dimanche", "3", this.Personne);
            fm2.Show();
        }

       
       

       

       

     
    }
}
