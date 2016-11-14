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
    class GestionTechnicienDAO:IGestionTechnicienDAO
    {
        public void AjouterTechnicien(Personne T)
        {
            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();
                
                
                SqlCommand cmd = new SqlCommand(String.Format("USE [GestionDeProjet]  INSERT INTO [dbo].[Techniciens]([Nom],[Prenom],[Login],[Password],[CIN]) VALUES('"+T.Nom+"','"+T.Prenom+"','"+T.Login+"','"+T.Password+"','"+T.CIN+"');"), conn);

                cmd.ExecuteNonQuery();
                
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


      public  Boolean exist(Personne P)
        {
            int cmp = 0;
            int cmp1 = 0;
             Personne T=null;
            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                SqlConnection conn = new SqlConnection("Data Source=MEHER;Initial Catalog=GestionDeProjet;Integrated Security=True");
                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT CIN,Login,Password from dbo.Techniciens ;"), conn);

               
               
                reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    
                      T = new Technicien();
                      if (Convert.ToInt32(reader.GetValue(0)) == P.CIN)
                      {
                          cmp1 = 1;
                      }
                      else
                      {
                          MessageBox.Show("login : " + reader.GetValue(1) + "  , password :" + reader.GetValue(2));
                          if ((reader.GetValue(1).ToString().Trim().Equals(P.Login)) && (reader.GetValue(2).ToString().Trim().Equals(P.Password)))
                          {
                              cmp1 = 1;
                          }
                      }
                

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (cmp1==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     public  Personne RechercherTechnicien(string login , string password)
      {
          Personne T = null;
          try
          {
              //textBox5.Text = DateTime.Now.Month.ToString();
              SqlConnection conn = new SqlConnection("Data Source=MEHER;Initial Catalog=GestionDeProjet;Integrated Security=True");
            
              
              conn.Open();

              SqlDataReader reader;
              SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.Techniciens WHERE Login='"+login+"' AND Password='"+password+"' ;"), conn);



              reader = cmd.ExecuteReader();
              while (reader.Read())
              {
                  T = new Technicien();
                 
                  

                      T.Nom = reader.GetValue(0).ToString();
                      T.Prenom = reader.GetValue(1).ToString();
                      T.Login = reader.GetValue(2).ToString();
                      T.Password = reader.GetValue(3).ToString();
                      T.CIN = Convert.ToInt32(reader.GetValue(4));
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
             SqlConnection conn = new SqlConnection("Data Source=MEHER;Initial Catalog=GestionDeProjet;Integrated Security=True");
             conn.Open();

             SqlCommand cmd = new SqlCommand(string.Format("UPDATE [dbo].[Techniciens] SET [Password] ='"+Nouveau_Mdp + "' WHERE (CIN="+P.CIN+");"), conn);
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
