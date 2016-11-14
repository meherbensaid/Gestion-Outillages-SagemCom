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
    public partial class Prevision2 : Form
    {
        public Prevision2()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UF_Check_Box.Text == "")
            {

                MessageBox.Show("le choix de l'UF est obligatoire");
            }
            else
            {
                ICollection<Feeder_Prevision> Previsions = new List<Feeder_Prevision>();
                ICollection<Etat> Etats = new List<Etat>();

                int cmp = 0;


                if (checkBox1.Checked)
                {
                    Etat e1 = new Etat { NumEquipe = 1, UF = UF_Check_Box.Text, DateCS = "lundi" };

                    Etats.Add(e1);
                    cmp++;


                }

                if (checkBox2.Checked)
                {

                    Etat e2 = new Etat { NumEquipe = 2, UF = UF_Check_Box.Text, DateCS = "lundi" };
                    Etats.Add(e2);
                    cmp++;

                }
                if (checkBox3.Checked)
                {

                    Etat e3 = new Etat { NumEquipe = 3, UF = UF_Check_Box.Text, DateCS = "lundi" };
                    Etats.Add(e3);
                    cmp++;

                }
                if (checkBox4.Checked)
                {
                    Etat e4 = new Etat { NumEquipe = 1, UF = UF_Check_Box.Text, DateCS = "mardi" };
                    Etats.Add(e4);
                    cmp++;
                }
                if (checkBox5.Checked)
                {
                    Etat e5 = new Etat { NumEquipe = 2, UF = UF_Check_Box.Text, DateCS = "mardi" };
                    Etats.Add(e5);
                    cmp++;
                }
                if (checkBox6.Checked)
                {
                    Etat e6 = new Etat { NumEquipe = 3, UF = UF_Check_Box.Text, DateCS = "mardi" };
                    Etats.Add(e6);
                    cmp++;
                }
                if (checkBox7.Checked)
                {
                    Etat e7 = new Etat { NumEquipe = 1, UF = UF_Check_Box.Text, DateCS = "mercredi" };
                    Etats.Add(e7);
                    cmp++;
                }
                if (checkBox8.Checked)
                {
                    Etat e8 = new Etat { NumEquipe = 2, UF = UF_Check_Box.Text, DateCS = "mercredi" };
                    Etats.Add(e8);
                    cmp++;
                }
                if (checkBox9.Checked)
                {
                    Etat e9 = new Etat { NumEquipe = 3, UF = UF_Check_Box.Text, DateCS = "mercredi" };
                    Etats.Add(e9);
                    cmp++;
                }
                if (checkBox10.Checked)
                {
                    Etat e10 = new Etat { NumEquipe = 1, UF = UF_Check_Box.Text, DateCS = "jeudi" };
                    Etats.Add(e10);
                    cmp++;
                }
                if (checkBox11.Checked)
                {
                    Etat e11 = new Etat { NumEquipe = 2, UF = UF_Check_Box.Text, DateCS = "jeudi" };
                    Etats.Add(e11);
                    cmp++;
                }
                if (checkBox12.Checked)
                {
                    Etat e12 = new Etat { NumEquipe = 3, UF = UF_Check_Box.Text, DateCS = "jeudi" };
                    Etats.Add(e12);
                    cmp++;
                }
                if (checkBox13.Checked)
                {
                    Etat e13 = new Etat { NumEquipe = 1, UF = UF_Check_Box.Text, DateCS = "vendredi" };
                    Etats.Add(e13);
                    cmp++;
                }
                if (checkBox14.Checked)
                {
                    Etat e14 = new Etat { NumEquipe = 2, UF = UF_Check_Box.Text, DateCS = "vendredi" };
                    Etats.Add(e14);
                    cmp++;
                }
                if (checkBox15.Checked)
                {
                    Etat e15 = new Etat { NumEquipe = 3, UF = UF_Check_Box.Text, DateCS = "vendredi" };
                    Etats.Add(e15);
                    cmp++;
                }
                if (checkBox16.Checked)
                {
                    Etat e16 = new Etat { NumEquipe = 1, UF = UF_Check_Box.Text, DateCS = "samedi" };
                    Etats.Add(e16);
                    cmp++;
                }
                if (checkBox17.Checked)
                {
                    Etat e17 = new Etat { NumEquipe = 2, UF = UF_Check_Box.Text, DateCS = "samedi" };
                    Etats.Add(e17);
                    cmp++;
                }
                if (checkBox18.Checked)
                {
                    Etat e18 = new Etat { NumEquipe = 3, UF = UF_Check_Box.Text, DateCS = "samedi" };
                    Etats.Add(e18);
                    cmp++;
                }
                if (checkBox19.Checked)
                {
                    Etat e19 = new Etat { NumEquipe = 1, UF = UF_Check_Box.Text, DateCS = "diamnche" };
                    Etats.Add(e19);
                    cmp++;
                }
                if (checkBox20.Checked)
                {
                    Etat e20 = new Etat { NumEquipe = 2, UF = UF_Check_Box.Text, DateCS = "dimanche" };
                    Etats.Add(e20);
                    cmp++;
                }
                if (checkBox21.Checked)
                {
                    Etat e21 = new Etat { NumEquipe = 3, UF = UF_Check_Box.Text, DateCS = "dimanche" };
                    Etats.Add(e21);
                    cmp++;
                }

                if (cmp == 0)
                {
                    MessageBox.Show("vous devez cauchez au moins une case");
                }
                else
                {
                    // Buse_Prevision FP1 = new Buse_Prevision(Etats.ElementAt(0), Etats);
                    Buse_Prevision_ FP1 = new Buse_Prevision_(Etats.ElementAt(0), Etats, cmp);

                    FP1.Show();
                }
            }
        }

        private void Prevision2_Load(object sender, EventArgs e)
        {
            IGestionProduitDAO IGPDAO = new GestionProduitDAO();
            ICollection<Produit> Produits = new List<Produit>();



            foreach (var item in IGPDAO.ListerUF())
            {
                UF_Check_Box.Items.Add(item);

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
                    }
    }
}
