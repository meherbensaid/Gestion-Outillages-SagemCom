using feeder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace feeder.DAL
{
    class GestionAdminDAO: IGestionAdminDAO
    {
        public Personne RechercherAdmin(string login, string password)
        {
            Personne T = null;
            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);

              //   SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.Admins WHERE Login='" + login + "' AND MotDePasse='" + password + "' ;"), conn);



                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    T = new Admin();



                    T.Nom = reader.GetValue(2).ToString();
                    T.Prenom = reader.GetValue(3).ToString();
                    T.Login = reader.GetValue(1).ToString();
                    T.Password = reader.GetValue(7).ToString();
                    T.CIN = Convert.ToInt32(reader.GetValue(5));
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return T;
        }
        public void Changer_Mdp(Personne P, string Nouveau_Mdp)
        {
            try
            {
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();

                SqlCommand cmd = new SqlCommand(string.Format("UPDATE [dbo].[Admins] SET [MotDePasse] ='" + Nouveau_Mdp + "' WHERE (MatriculeId=" + P.CIN + ");"), conn);
                cmd.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("mot de passe a été changé !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
