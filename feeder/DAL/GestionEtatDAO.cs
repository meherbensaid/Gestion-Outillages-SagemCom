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
    class GestionEtatDAO: IGestionEtatDAO
    {
        public Etat GetEtat(string UF, String date, string poste,string type)
        {
            Etat e = new Etat();
            e.Feeders = new List<Feeder>();

            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format(" SELECT [id],[jour],[TF1],[TF2],[TF3],[TF4],[TF5],[TF6],[TB1],[TB2],[TB3],[TB4],[TB5],[TB6],[TB7],[TB8],[TB9],[TB10],[TB11],[TB12],[TB13],[TB14],[TB15],[TB16],[TB17],[TB18],[TB19],[TB20],[TB21],[TB22],[TB23],[TB24],[TB25],[TB26],[TB27],[TB28],[TB29],[TB30],[TB31],[TB32],[TB33] FROM [dbo].[nouveau_etat] WHERE UF='" + UF + "' AND type='" + type + "' AND date='" + date +"' AND equipe='" + poste+"' ;"), conn);

                int j = 2;
                int h = 8;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    e.Buses = new List<Buse>();
                    e.Feeders = new List<Feeder>();
                    e.EtatID = Convert.ToInt32(reader.GetValue(0));
                    for (int i = 0; i < 6; i++)
                    {
                        if (reader.IsDBNull(j))
                        {

                            Feeder f = new Feeder { Coordonnee = "TF" + (i + 1), Quantite = 0 };
                            e.Feeders.Add(f);
                        }
                        else
                        {


                            Feeder f = new Feeder { Coordonnee = "TF" + (i + 1), Quantite = Convert.ToInt32(reader.GetValue(j)) };
                            e.Feeders.Add(f);
                        }

                        j++;// Convert.ToInt32(reader.GetValue(0));
                    }

                    j = 2;


                    for (int i = 0; i < 33; i++)
                    {


                        if (reader.IsDBNull(h))
                        {
                            Buse b = new Buse { coordonnee = "TB" + (i + 1), Quantite = 0 };
                            e.Buses.Add(b);
                        }
                        else
                        {

                            Buse b = new Buse { coordonnee = "TB" + (i + 1), Quantite = Convert.ToInt32(reader.GetValue(h)) };
                            e.Buses.Add(b);

                        }
                        h++;// Convert.ToInt32(reader.GetValue(0));
                    }

                    h = 8;

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return e;
        }
        public Etat RechercherDernierEtat(string UF,string type)
        {


            Etat e = new Etat();
            e.Feeders = new List<Feeder>();

            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format(" SELECT [id],[jour],[TF1],[TF2],[TF3],[TF4],[TF5],[TF6],[TB1],[TB2],[TB3],[TB4],[TB5],[TB6],[TB7],[TB8],[TB9],[TB10],[TB11],[TB12],[TB13],[TB14],[TB15],[TB16],[TB17],[TB18],[TB19],[TB20],[TB21],[TB22],[TB23],[TB24],[TB25],[TB26],[TB27],[TB28],[TB29],[TB30],[TB31],[TB32],[TB33] FROM [dbo].[nouveau_etat] WHERE UF='" + UF + "' AND type='"+type+"' ;"), conn);

                int j = 2;
                int h = 8;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    e.Buses = new List<Buse>();
                    e.Feeders = new List<Feeder>();
                   e.EtatID= Convert.ToInt32(reader.GetValue(0));
                   for (int i = 0; i < 6; i++)
                   {
                       if (reader.IsDBNull(j))
                       {

                           Feeder f = new Feeder { Coordonnee = "TF" + (i + 1), Quantite = 0 };
                           e.Feeders.Add(f);
                       }
                       else
                       {


                           Feeder f = new Feeder { Coordonnee = "TF" + (i + 1), Quantite = Convert.ToInt32(reader.GetValue(j)) };
                           e.Feeders.Add(f);
                       }
                      
                       j++;// Convert.ToInt32(reader.GetValue(0));
                   }
                  
                   j = 2;


                   for (int i = 0; i < 33; i++)
                   {
                      
                       
                       if (reader.IsDBNull(h))
                       {
                           Buse b = new Buse { coordonnee = "TB" + (i + 1), Quantite = 0 };
                           e.Buses.Add(b);
                       }
                       else
                       {

                           Buse b = new Buse { coordonnee = "TB" + (i + 1), Quantite = Convert.ToInt32(reader.GetValue(h)) };
                           e.Buses.Add(b);
                       
                          }
                       h++;// Convert.ToInt32(reader.GetValue(0));
                   }

                   h = 8;

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return e;
            
        }

        public void AjouterEtat(Etat e)
        {
            int i=0;
            int [] T=new int [6];
            foreach (var item in e.Feeders)
	{
		 T[i]=item.Quantite;
                i++;
	}

           
            var test="INSERT  INTO [dbo].[nouveau_etat]([UF],[Jour],[TF1],[TF2],[TF3],[TF4],[TF5],[TF6],[equipe],[Technicin],[date],[type]) VALUES('" + e.UF + "','" + e.DateCS + "','" + T[0] + "','" + T[1] + "','" + T[2] + "','" + T[3] + "','" + T[4] + "','" + T[5]+"',"  + e.NumEquipe + ",'" + e.Technicien.Nom + "','" + e.DateCS + "','f');";
            try
            {
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();


              

                SqlCommand cmd = new SqlCommand(string.Format(test), conn);



                cmd.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("l'ajout état de feeder est fait avec succés");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }


        public void AjouterEtatBuses(Etat e)
        {
           

            var buses = "";
            for (int j = 0; j < 33; j++)
            {

                buses = buses + "'" + e.Buses.ElementAt(j).Quantite + "',";

            }
            var test = "INSERT  INTO [dbo].[nouveau_etat]([UF],[Jour],[TB1],[TB2],[TB3],[TB4],[TB5],[TB6],[TB7],[TB8],[TB9],[TB10],[TB11],[TB12],[TB13],[TB14],[TB15],[TB16],[TB17],[TB18],[TB19],[TB20],[TB21],[TB22],[TB23],[TB24],[TB25],[TB26],[TB27],[TB28],[TB29],[TB30],[TB31],[TB32],[TB33],[equipe],[Technicin],[date],[type]) VALUES('" + e.UF + "','" + e.DateCS + "'," + buses + e.NumEquipe + ",'" + e.Technicien.Nom + "','" + e.DateCS + "','b');";
            try
            {
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();




                SqlCommand cmd = new SqlCommand(string.Format(test), conn);



                cmd.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("l'ajout état de buse est fait avec succés");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void AjouterPrevision(Etat e)
        {
            int i = 0;
            int[] T = new int[6];
            foreach (var item in e.Feeders)
            {
                T[i] = item.Quantite;
                i++;
            }

            var buses = "";

            for (int j = 0; j < 33; j++)
            {
                if (j == 32)
                {
                    buses = buses + "[TB" + (j + 1) + "] = '" + e.Buses.ElementAt(j).Quantite + "'";
                }
                else
                {
                    buses = buses + "[TB" + (j + 1) + "] = '" + e.Buses.ElementAt(j).Quantite + "',";
                }
            }

            var tmp = "UPDATE [dbo].[Prevision_etat] SET [UF] ='" + e.UF + "',[Jour] = '" + e.DateCS + "',[TF1] = '" + T[0] + "',[TF2] = '" + T[1] + "',[TF3] ='" + T[2] + "',[TF4] = '" + T[3] + "',[TF5] = '" + T[4] + "',[TF6] = '" + T[5] + "',[equipe] = '" + e.NumEquipe + "',[date] = '" + e.DateCS + "'" + buses + " WHERE (ID=5);";

            try
            {
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();

                SqlCommand cmd = new SqlCommand(string.Format("UPDATE [dbo].[Prevision_etat] SET [UF] ='"+e.UF+"',[Jour] = '"+e.DateCS+"',[TF1] = '"+T[0]+"',[TF2] = '"+T[1]+"',[TF3] ='"+T[2]+"',[TF4] = '"+T[3]+"',[TF5] = '"+T[4]+"',[TF6] = '"+T[5]+"',[equipe] = '"+e.NumEquipe+"',[date] = '"+e.DateCS+"',"+buses+" WHERE (ID=5);"), conn);
                cmd.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("l'ajout de prevision est fait avec succés");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        public  Etat EtatPrevision()
        {


            Etat e = new Etat();
            e.Feeders = new List<Feeder>();


            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format(" SELECT [id],[jour],[TF1],[TF2],[TF3],[TF4],[TF5],[TF6],[TB1],[TB2],[TB3],[TB4],[TB5],[TB6],[TB7],[TB8],[TB9],[TB10],[TB11],[TB12],[TB13],[TB14],[TB15],[TB16],[TB17],[TB18],[TB19],[TB20],[TB21],[TB22],[TB23],[TB24],[TB25],[TB26],[TB27],[TB28],[TB29],[TB30],[TB31],[TB32],[TB33] FROM [dbo].[Prevision_etat] WHERE (ID=5) ;"), conn);

                int j = 2;
                int h = 8;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    e.Feeders = new List<Feeder>();
                    e.Buses = new List<Buse>();
                    e.EtatID = Convert.ToInt32(reader.GetValue(0));
                    e.NumEquipe = Convert.ToInt32(reader.GetValue(8));
                    for (int i = 0; i < 6; i++)
                    {
                        Feeder f = new Feeder { FedderID = "TF" + (i+1), Quantite = Convert.ToInt32(reader.GetValue(j)) };
                        e.Feeders.Add(f);
                        j++;// Convert.ToInt32(reader.GetValue(0));
                    }

                    j = 2;


                    for (int i = 0; i < 33; i++)
                    {
                        Buse b = new Buse { BuseID = "TB" + (i+1), Quantite = Convert.ToInt32(reader.GetValue(h)) };
                        e.Buses.Add(b);
                        h++;// Convert.ToInt32(reader.GetValue(0));
                    }
                    h = 8;

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return e;

        }
    }
}
