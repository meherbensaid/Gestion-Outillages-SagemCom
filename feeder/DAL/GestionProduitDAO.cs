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
    class GestionProduitDAO : IGestionProduitDAO
    {
        public static int var = 0;
        public ICollection<Produit> ListerProduit(string UF) {
            ICollection<Produit> Produits = new List<Produit>();
           
            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT nom from dbo.prod WHERE UF='"+UF+"' ;"), conn);
                
                
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Produit P = new Produit();
                    P.Nom = reader.GetValue(0).ToString();
                    Produits.Add(P);
                    
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return Produits;
            

        }


        public ICollection<string> ListerUF() {
            ICollection<string> UFS = new List<string>();

            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT Distinct UF from dbo.prod ;"), conn);

               
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                    var UF = reader.GetValue(0).ToString();
                    UFS.Add(UF);

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return UFS;
            

        }

       public ICollection<Feeder> ListerFeeder(string NomProduit)
        {
            ICollection<Feeder> Fedders = new List<Feeder>();
            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                 SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.prod  WHERE nom ='{0}';",NomProduit), conn);
               
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    for (int i = 1; i < 7; i++)
                    {
                        Feeder feeder = new Feeder();
                       
                        feeder.Quantite = Convert.ToInt32(reader.GetValue(i).ToString());
                        feeder.FedderID = "TF" + i;
                        Fedders.Add(feeder);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return Fedders;
        }

      public ICollection<Buse> ListerBuses(string NomProduit)
       {
           ICollection<Buse> Buses = new List<Buse>();
           try
           {
               //textBox5.Text = DateTime.Now.Month.ToString();
                SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
               conn.Open();
               SqlDataReader reader;
               SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.prod  WHERE nom ='{0}';", NomProduit), conn);

               reader = cmd.ExecuteReader();
               while (reader.Read())
               {

                   for (int i = 7; i < 40; i++)
                   {
                       Buse Buse = new Buse();

                       Buse.Quantite = Convert.ToInt32(reader.GetValue(i).ToString());
                       Buse.BuseID = "TB" + (i-6);
                       Buses.Add(Buse);

                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
           return Buses;
       }
      public ICollection<Feeder> ListerTotaleFeederAccueil( String date, string poste, string type)
      {
          IGestionEtatDAO IGEDAO = new GestionEtatDAO();

          Etat e_Energie = IGEDAO.GetEtat("ENERGIE",date,poste,type);
          Etat e_STB1 = IGEDAO.GetEtat("STB1",date,poste,type);
          Etat e_STB2 = IGEDAO.GetEtat("STB2",date,poste,type);
          Etat e_ATR = IGEDAO.GetEtat("ATR",date,poste,type);
          Etat e_Indus = IGEDAO.GetEtat("Indus",date,poste,type);

          int[] T1 = new int[6];
          int[] T2 = new int[6];
          int[] T3 = new int[6];
          int[] T4 = new int[6];
          int[] T5 = new int[6];

          int i = 0;

          foreach (var item in e_Energie.Feeders)
          {
              T1[i] = item.Quantite;
              i++;
          }
          i = 0;

          foreach (var item in e_STB1.Feeders)
          {
              T2[i] = item.Quantite;
              i++;
          }
          i = 0;

          foreach (var item in e_STB2.Feeders)
          {
              T3[i] = item.Quantite;
              i++;
          }
          i = 0;
          foreach (var item in e_ATR.Feeders)
          {
              T4[i] = item.Quantite;
              i++;
          }
          i = 0;
          foreach (var item in e_Indus.Feeders)
          {
              T5[i] = item.Quantite;
              i++;
          }

          ICollection<Feeder> Fedders = new List<Feeder>();

          for (int j = 0; j < 6; j++)
          {
              Fedders.Add(new Feeder { Quantite = T1[j] + T2[j] + T3[j] + T4[j] + T5[j], FedderID = "TF" + (j + 1) });
          }



          return Fedders;
      }
      public ICollection<Buse> ListerTotaleBuseAccueil(string date, string poste, string type)
      {
          IGestionEtatDAO IGEDAO = new GestionEtatDAO();

          Etat e_Energie = IGEDAO.GetEtat("ENERGIE", date, poste, type);
          Etat e_STB1 = IGEDAO.GetEtat("STB1", date, poste, type);
          Etat e_STB2 = IGEDAO.GetEtat("STB2", date, poste, type);
          Etat e_ATR = IGEDAO.GetEtat("ATR", date, poste, type);
          Etat e_Indus = IGEDAO.GetEtat("Indus", date, poste, type);

          int[] T1 = new int[33];
          int[] T2 = new int[33];
          int[] T3 = new int[33];
          int[] T4 = new int[33];
          int[] T5 = new int[33];

          int i = 0;
          if (e_Energie.Buses != null)
          {
              foreach (var item in e_Energie.Buses)
              {
                  T1[i] = item.Quantite;
                  i++;
              }
          }
          i = 0;
          if (e_STB1.Buses != null)
          {
              foreach (var item in e_STB1.Buses)
              {
                  T2[i] = item.Quantite;
                  i++;
              }
          }
          i = 0;
          if (e_STB2.Buses != null)
          {
              foreach (var item in e_STB2.Buses)
              {
                  T3[i] = item.Quantite;
                  i++;
              }
          }
          i = 0;
          if (e_ATR.Buses != null)
          {
              foreach (var item in e_ATR.Buses)
              {
                  T4[i] = item.Quantite;
                  i++;
              }
          }
          i = 0;
          if (e_Indus.Buses != null)
          { 
          foreach (var item in e_Indus.Buses)
          {
              T5[i] = item.Quantite;
              i++;
          }
          }
          ICollection<Buse> Buses = new List<Buse>();

          for (int j = 0; j < 33; j++)
          {
              Buses.Add(new Buse { Quantite = T1[j] + T2[j] + T3[j] + T4[j] + T5[j], BuseID = "TF" + (j + 1) });
          }



          return Buses;
      }
       public ICollection<Feeder> ListerTotaleFeederAccueil()
       {
           IGestionEtatDAO IGEDAO = new GestionEtatDAO();

           Etat e_Energie = IGEDAO.RechercherDernierEtat("Energie","f");
           Etat e_STB1 = IGEDAO.RechercherDernierEtat("STB1","f");
           Etat e_STB2 = IGEDAO.RechercherDernierEtat("STB2","f");
           Etat e_ATR = IGEDAO.RechercherDernierEtat("ATR","f");
           Etat e_Indus = IGEDAO.RechercherDernierEtat("Indus","f");

           int[] T1 = new int[6];
           int[] T2 = new int[6];
           int[] T3 = new int[6];
           int[] T4 = new int[6];
           int[] T5 = new int[6];

           int i = 0;

           foreach (var item in e_Energie.Feeders)
           {
               T1[i] = item.Quantite;
               i++;
           }
           i = 0;

           foreach (var item in e_STB1.Feeders)
           {
               T2[i] = item.Quantite;
               i++;
           }
           i = 0;

           foreach (var item in e_STB2.Feeders)
           {
               T3[i] = item.Quantite;
               i++;
           }
           i = 0;
           foreach (var item in e_ATR.Feeders)
           {
               T4[i] = item.Quantite;
               i++;
           }
           i = 0;
           foreach (var item in e_Indus.Feeders)
           {
               T5[i] = item.Quantite;
               i++;
           }

           ICollection<Feeder> Fedders = new List<Feeder>();

           for (int j = 0; j < 6; j++)
           {
               Fedders.Add(new Feeder { Quantite = T1[j] + T2[j] + T3[j] + T4[j] + T5[j], FedderID = "TF" + (j + 1) });
           }



           return Fedders;
          
       }
       public ICollection<Buse> ListerTotaleBuseAccueil() {


           IGestionEtatDAO IGEDAO = new GestionEtatDAO();

           Etat e_Energie = IGEDAO.RechercherDernierEtat("Energie","b");
           Etat e_STB1 = IGEDAO.RechercherDernierEtat("STB1","b");
           Etat e_STB2 = IGEDAO.RechercherDernierEtat("STB2","b");
           Etat e_ATR = IGEDAO.RechercherDernierEtat("ATR","b");
           Etat e_Indus = IGEDAO.RechercherDernierEtat("Indus","b");

          

           ICollection<Buse> Buses = new List<Buse>();

           for (int j = 0; j < 33; j++)
           {
               var energie = 0; ;
               var stb1 = 0;
               var stb2=0;
               var atr = 0;
               var indus = 0;

               if(e_Energie.Buses !=null){
                   energie = e_Energie.Buses.ElementAt(j).Quantite;
               }
              
               if (e_ATR.Buses != null)
               {
                   atr = e_ATR.Buses.ElementAt(j).Quantite;
               }
               if (e_Indus.Buses != null)
               {
                   indus = e_Indus.Buses.ElementAt(j).Quantite;
               }
               if (e_STB1.Buses != null)
               {
                   stb1 = e_STB1.Buses.ElementAt(j).Quantite;
               }
               if (e_STB2.Buses != null)
               {
                   stb2 = e_STB2.Buses.ElementAt(j).Quantite;
               }
               Buses.Add(new Buse { Quantite = energie+stb1+stb2+atr+indus, BuseID = "TB" + (j + 1) });
           }



           return Buses;
       }
       public ICollection<Feeder> ListerTotaleFeederUsine()
       {
        
           ICollection<Feeder> Fedders = new List<Feeder>();
           try
           {
               ICollection<Feeder> F_Energie = new List<Feeder>();
               //textBox5.Text = DateTime.Now.Month.ToString();
                SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
               conn.Open();
               SqlDataReader reader;
               SqlCommand cmd = new SqlCommand(String.Format("SELECT sum(TF1) as TF1,sum(TF2) as TF2,sum(TF3) as TF3,sum(TF4) as TF4,sum(TF5) as TF5,sum(TF6) as TF6 FROM [dbo].[prod]  WHERE UF='Usine'"), conn);

               reader = cmd.ExecuteReader();
               while (reader.Read())
               {

                   for (int i = 0; i < 6; i++)
                   {
                       Feeder feeder = new Feeder();

                       feeder.Quantite = Convert.ToInt32(reader.GetValue(i).ToString());
                       feeder.FedderID = "TF" + (i + 1);
                       Fedders.Add(feeder);

                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
           return Fedders;
       }
    public  ICollection<Buse> ListerTotaleBusesUsine()
       {

           ICollection<Buse> Buses = new List<Buse>();
           try
           {
               ICollection<Feeder> F_Energie = new List<Feeder>();
               //textBox5.Text = DateTime.Now.Month.ToString();
                SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
               conn.Open();
               SqlDataReader reader;
               SqlCommand cmd = new SqlCommand(String.Format("  SELECT [TB1],[TB2],[TB3],[TB4],[TB5],[TB6],[TB7],[TB8],[TB9],[TB10],[TB11],[TB12],[TB13],[TB14],[TB15],[TB16],[TB17],[TB18],[TB19],[TB20],[TB21],[TB22],[TB23],[TB24],[TB25],[TB26],[TB27],[TB28],[TB29],[TB30],[TB31],[TB32],[TB33] FROM [dbo].[prod]  WHERE UF='Usine'"), conn);

               reader = cmd.ExecuteReader();
               while (reader.Read())
               {

                   for (int i = 0; i < 33; i++)
                   {
                       Buse Buse = new Buse();

                       Buse.Quantite = Convert.ToInt32(reader.GetValue(i).ToString());
                       Buse.BuseID = "TB" + (i + 1);
                       Buses.Add(Buse);

                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
           return Buses;
       }

       public Produit GetProduitByNom(string nom)
       {
           Produit P = new Produit();
            try
           {
                SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
           conn.Open();
           //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
           SqlDataReader reader;
           SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.prod  WHERE nom ='{0}';",nom), conn);

           reader = cmd.ExecuteReader();
           reader.Read();

           ICollection<Feeder> Feeders = new List<Feeder>();
           for (int i = 0; i < 6; i++)
           {
               var a = reader.GetValue(i+1).ToString();
               Feeders.Add(new Feeder { Quantite= Convert.ToInt32(a)});   
           }
           ICollection<Buse> Buses = new List<Buse>();
           for (int i = 0; i < 33; i++)
           {
               var a = reader.GetValue(i + 7).ToString();
               Buses.Add(new Buse { Quantite = Convert.ToInt32(a) });
           }

           P.Feeders = Feeders;
           P.Buses = Buses;
           conn.Close();
            }
            catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
            return P;
       }

       public void ModifierProduit(Produit P, string NomProduit)
       {

         


           try
           {
                SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
               conn.Open();


               SqlCommand cmd = new SqlCommand(string.Format("UPDATE [dbo].[prod] SET [TF1] = '" + P.Feeders.ElementAt(0).Quantite + "',[TF2] = '" + P.Feeders.ElementAt(1).Quantite + "',[TF3] ='" + P.Feeders.ElementAt(2).Quantite + "',[TF4] = '" + P.Feeders.ElementAt(3).Quantite + "',[TF5] = '" + P.Feeders.ElementAt(4).Quantite + "',[TF6] = '" + P.Feeders.ElementAt(5).Quantite +  "' WHERE (nom='"+NomProduit+"');"), conn);
               cmd.ExecuteNonQuery();


               conn.Close();
               MessageBox.Show("la modification  est faite avec succés");
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
       }
       public void ModifierProduitBuse(Produit P, string NomProduit)
       {
          

           var buses = "";

           for (int i = 0; i < 33; i++)
           {
               if (i == 32)
               {
                   buses = buses + "[TB" + (i + 1) + "] = '" + P.Buses.ElementAt(i).Quantite + "'";
               }
               else
               {
                   buses = buses + "[TB" + (i + 1) + "] = '" + P.Buses.ElementAt(i).Quantite + "',";
               }
               }
           try
           {
                SqlConnection conn = new SqlConnection(global::feeder.Properties.Settings.Default.connn);
               conn.Open();

               SqlCommand cmd = new SqlCommand(string.Format("UPDATE [dbo].[prod] SET "+buses+" WHERE (nom='" + NomProduit + "');"), conn);
               cmd.ExecuteNonQuery();


               conn.Close();
               MessageBox.Show("la modification  est faite avec succés");
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
       }
       
    }
}
