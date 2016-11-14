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
    public partial class Changer_MDP : Form
    {
        Personne Personne;

        public Changer_MDP(Personne P)
        {
            this.Personne = P;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var GetType=this.Personne.GetType().ToString();
            

            var type = GetType.Substring(14);
          

            if (type.Equals("Admin")) {
                IGestionAdminDAO IGADAO = new GestionAdminDAO();
                IGADAO.Changer_Mdp(this.Personne, textBox1.Text);
              
            }
            if (type.Equals("Technicien"))
            {
               
                IGestionTechnicienDAO IGTDAO = new GestionTechnicienDAO();
                IGTDAO.Changer_Mdp(this.Personne, textBox1.Text);
            }
            }
    }
}
