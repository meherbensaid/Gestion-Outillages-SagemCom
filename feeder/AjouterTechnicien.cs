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
    public partial class AjouterTechnicien : Form
    {
        public AjouterTechnicien()
        {
            InitializeComponent();
        }

        private void Boutton_Ajouter_Click(object sender, EventArgs e)
        {
            IGestionTechnicienDAO IGTDAO = new GestionTechnicienDAO();

            Technicien T = new Technicien { CIN = Convert.ToInt32(textBox1.Text), Login = textBox4.Text, Password = textBox5.Text };

            var exist=IGTDAO.exist(T);

            if (exist)
            {
                MessageBox.Show("Ce Technicien existe deja");
            }
            else
            {
                Personne T1 = new Technicien();




                T.CIN = Convert.ToInt32(textBox1.Text);
                T.Nom = textBox2.Text;
                T.Prenom = textBox3.Text;
                T.Login = textBox4.Text;
                T.Password = textBox5.Text;
                IGTDAO.AjouterTechnicien(T);
                MessageBox.Show("Le Technicien a été ajouté");
            }
            }
    }
}
