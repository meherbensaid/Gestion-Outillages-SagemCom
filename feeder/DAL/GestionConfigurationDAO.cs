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
    class GestionConfigurationDAO: IGestionConfigurationDAO
    {
      public ICollection<Feeder> ConfigFeeder(string UF)
        {
            ICollection<Feeder> Feeders = new List<Feeder>();

            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);

                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format(" SELECT [TF1],[TF2],[TF3],[TF4],[TF5],[TF6] FROM [dbo].[reel] WHERE UF='" + UF + "' ;"), conn);

              
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                  
                  
                    for (int i = 0; i < 6; i++)
                    {
                        Feeder f = new Feeder { Coordonnee = "TF"+(i+1), Quantite = Convert.ToInt32(reader.GetValue(i)) };
                        Feeders.Add(f);
                       
                    }

                   

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
          return Feeders;
        }

      public ICollection<Buse> ConfigBuse(string UF)
      {
          ICollection<Buse> Buses = new List<Buse>();

          var buse_text = "";
          for (int i = 1; i < 34; i++)
          {
              if (i < 33)
              {
                  buse_text = buse_text + "[TB" + i + "],";
              }
              else
              {
                  buse_text = buse_text + "[TB" + i + "]";
              }
              }
          try
          {
              //textBox5.Text = DateTime.Now.Month.ToString();
               SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
              conn.Open();

              SqlDataReader reader;
              SqlCommand cmd = new SqlCommand(String.Format(" SELECT "+buse_text+" FROM [dbo].[reel] WHERE UF='" + UF + "' ;"), conn);


              reader = cmd.ExecuteReader();
              while (reader.Read())
              {


                  for (int i = 0; i < 33; i++)
                  {
                      Buse b = new Buse { coordonnee = "TB" + (i + 1), Quantite = Convert.ToInt32(reader.GetValue(i))};
                      Buses.Add(b);

                  }



              }
              conn.Close();
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.ToString());
          }

          return Buses;
      }
      public void ModifierConfigmax(ICollection<Feeder> Feeders, string UF)
      {
          try
          {
               SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
              conn.Open();


              SqlCommand cmd = new SqlCommand(string.Format("UPDATE [dbo].[reel] SET [TF1] = '" + Feeders.ElementAt(0).Quantite + "',[TF2] = '" + Feeders.ElementAt(1).Quantite + "',[TF3] ='" + Feeders.ElementAt(2).Quantite + "',[TF4] = '" + Feeders.ElementAt(3).Quantite + "',[TF5] = '" + Feeders.ElementAt(4).Quantite + "',[TF6] = '" + Feeders.ElementAt(5).Quantite + "' WHERE (UF='" + UF + "');"), conn);
              cmd.ExecuteNonQuery();


              conn.Close();
              MessageBox.Show("la modification de la configuration a été faite avec succés");
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.ToString());
          }
      }
      public void ModifierConfigmaxBuse(ICollection<Buse> Buses, string UF)
      {
          var buses = "";

          for (int i = 0; i < 33; i++)
          {
              if (i == 32)
              {
                  buses = buses + "[TB" + (i + 1) + "] = '" + Buses.ElementAt(i).Quantite + "'";
              }
              else
              {
                  buses = buses + "[TB" + (i + 1) + "] = '" + Buses.ElementAt(i).Quantite + "',";
              }
          }
          try
          {
               SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
              conn.Open();

              SqlCommand cmd = new SqlCommand(string.Format("UPDATE [dbo].[reel] SET " + buses + " WHERE (UF='" + UF + "');"), conn);
              cmd.ExecuteNonQuery();


              conn.Close();
              MessageBox.Show("la modification de la config max des buses  a été  faite avec succés");
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.ToString());
          }
      }
    
    }
}
