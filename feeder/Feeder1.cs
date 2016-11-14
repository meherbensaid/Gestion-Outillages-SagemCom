using feeder.DAL;
using feeder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace feeder
{
    public partial class Feeder1 : Form
    {
        public Personne Personne;
        public Feeder1(Personne P)
        {
            this.Personne = P;
            InitializeComponent();
            
        }

       
        

       

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Lundi","1",this.Personne);
            fm2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Me1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Lundi", "2", this.Personne);
            fm2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Lundi", "3", this.Personne);
            fm2.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Mardi", "1", this.Personne);
            fm2.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Mardi", "2", this.Personne);
            fm2.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Mardi", "3", this.Personne);
            fm2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Mercredi", "1", this.Personne);
            fm2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Mercredi", "2", this.Personne);
            fm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Mercredi", "3", this.Personne);
            fm2.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Jeudi", "1", this.Personne);
            fm2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Jeudi", "2", this.Personne);
            fm2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Jeudi", "3", this.Personne);
            fm2.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Vendredi", "1", this.Personne);
            fm2.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            Feeder2 fm2 = new Feeder2("Vendredi", "2", this.Personne);
            fm2.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            Feeder2 fm2 = new Feeder2("Vendredi", "3", this.Personne);
            fm2.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {

            Feeder2 fm2 = new Feeder2("Samedi", "1", this.Personne);
            fm2.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {

            Feeder2 fm2 = new Feeder2("Samedi", "2", this.Personne);
            fm2.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {

            Feeder2 fm2 = new Feeder2("Samedi", "3", this.Personne);
            fm2.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {

            Feeder2 fm2 = new Feeder2("Dimanche", "1", this.Personne);
            fm2.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {

            Feeder2 fm2 = new Feeder2("Dimanche", "2", this.Personne);
            fm2.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Feeder2 fm2 = new Feeder2("Dimanche", "3", this.Personne);
            fm2.Show();
        }
        }
    }

