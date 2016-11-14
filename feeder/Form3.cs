using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace feeder
{
    public partial class Form1 : Form
    {
        public  int [] T1 = new int[6];
        public int[] T2 = new int[6];
        public int[] T3 = new int[6];
        public int[] T4 = new int[6];
        public String[] T5 = new String [6];  
  
        public int a;
        public int b;
        public int c;
        public int d;
        public int f;
        public int g;
        public int a1;
        public int b1;
        public int c1;
        public int d1;
        public int f1;
        public int g1;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();
                //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.prod  WHERE nom ='{0}';",comboBox3.Text), conn);
               

                reader = cmd.ExecuteReader();
                reader.Read();
                for (int i = 0; i < 6 ; i++)
                {
                    T1[i] = Convert.ToInt32(reader.GetValue(i + 1).ToString());
                }
                a = Convert.ToInt32(reader.GetValue(1).ToString());
                b = Convert.ToInt32(reader.GetValue(2).ToString());
                c = Convert.ToInt32(reader.GetValue(3).ToString());
                d = Convert.ToInt32(reader.GetValue(4).ToString());
                f = Convert.ToInt32(reader.GetValue(5).ToString());
                g = Convert.ToInt32(reader.GetValue(6).ToString());
              
                conn.Close();
           


               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            button2.PerformClick();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Insertion CS";
            // TODO: This line of code loads data into the 'tdBsecDataSet.prod' table. You can move, or remove it, as needed.
           // this.prodTableAdapter.Fill(this.tdBsecDataSet.prod);
        

              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
            conn.Open();
            //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.prod  WHERE nom ='{0}';", comboBox4.Text), conn);
            
            reader = cmd.ExecuteReader();
            reader.Read();
          
            textBox6.Text = (Convert.ToInt32(reader.GetValue(1).ToString()) - T1[0]).ToString();
            textBox5.Text = (Convert.ToInt32(reader.GetValue(2).ToString()) - T1[1]).ToString();
            textBox4.Text = (Convert.ToInt32(reader.GetValue(3).ToString()) - T1[2]).ToString();
            textBox9.Text = (Convert.ToInt32(reader.GetValue(4).ToString()) - T1[3]).ToString();
            textBox8.Text = (Convert.ToInt32(reader.GetValue(5).ToString()) - T1[4]).ToString();
            textBox7.Text = (Convert.ToInt32(reader.GetValue(6).ToString()) - T1[5]).ToString();
            conn.Close();
           
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(string.Format("UPDATE dbo.etat  SET   TF1 ='" + T2[0] + "', TF2='" + T2[1] + "', TF3='" + T2[2] + "', TF4='" + T2[3] + "', TF5='" + T2[4] + "', TF6='" + T2[5] + "' WHERE UF ='{0}' and jour ='{1}' and equipe = '{2}';", comboBox5.Text, comboBox1.Text, Convert.ToInt32(comboBox2.Text)), conn);
                cmd.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("update état est fait avec succés");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
       
      
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                T5[0] = "2x8";
                T5[1] = "12x16";
                T5[2] = "24x32";
                T5[3] = "44x56";
                T5[4] = "72";
                T5[5] = "88";
                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();
                //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.reel  WHERE UF ='{0}';", comboBox5.Text), conn);

                reader = cmd.ExecuteReader();
                reader.Read();

                for (int i = 0; i < 6; i++)
                {
                    T3[i] = Convert.ToInt32(reader.GetValue(i + 1).ToString());
                    T4[i] = T2[i] - T3[i];
                    if (T2[i] > T3[i])
                    {
                        MessageBox.Show("Dépassement configuration maximal Feeders " + T5[i] + " par " + T4[i] + " feeders");
                    }
                }
        
            }
            

           

                              


          
         catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox3.Text);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {


            //textBox5.Text = DateTime.Now.Month.ToString();
            if (checkBox1.Checked == false)
            {
                try
                {

                    if ((comboBox1.Text == "Lundi") && (comboBox2.Text == "1"))
                    {

                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open(); 
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Dimanche", "3"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);


                        conn.Close();
                    }
                    if ((comboBox1.Text == "Lundi") && (comboBox2.Text == "2"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Lundi", "1"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);


                        conn.Close();
                    }
                    if ((comboBox1.Text == "Lundi") && (comboBox2.Text == "3"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Lundi", "2"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    // mardi
                    if ((comboBox1.Text == "Mardi") && (comboBox2.Text == "1"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Lundi", "3"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Mardi") && (comboBox2.Text == "2"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Mardi", "1"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Mardi") && (comboBox2.Text == "3"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Mardi", "2"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    // mercredi
                    if ((comboBox1.Text == "Mercredi") && (comboBox2.Text == "1"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Mardi", "3"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Mercredi") && (comboBox2.Text == "2"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Mercredi", "1"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Mercredi") && (comboBox2.Text == "3"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Mercredi", "2"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    // Jeudi
                    if ((comboBox1.Text == "Jeudi") && (comboBox2.Text == "1"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Mercredi", "3"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Jeudi") && (comboBox2.Text == "2"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Jeudi", "1"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Jeudi") && (comboBox2.Text == "3"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Jeudi", "2"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Vendredi") && (comboBox2.Text == "1"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Jeudi", "3"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);


                        conn.Close();
                    }
                    if ((comboBox1.Text == "Vendredi") && (comboBox2.Text == "2"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Vendredi", "1"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Vendredi") && (comboBox2.Text == "3"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Vendredi", "2"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    // Samediiiiiiiiiii
                    if ((comboBox1.Text == "Samedi") && (comboBox2.Text == "1"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Vendredi", "3"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Samedi") && (comboBox2.Text == "2"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Samedi", "1"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Samedi") && (comboBox2.Text == "3"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Samedi", "2"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    // Dimanche
                    if ((comboBox1.Text == "Dimanche") && (comboBox2.Text == "1"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Samedi", "3"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Dimanche") && (comboBox2.Text == "2"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Dimanche", "1"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                    if ((comboBox1.Text == "Dimanche") && (comboBox2.Text == "3"))
                    {
                        SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                        conn.Open();
                        //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                        SqlDataReader reader;
                        SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Dimanche", "2"), conn);


                        reader = cmd.ExecuteReader();
                        reader.Read();
                        T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                        T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                        T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                        T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                        T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                        T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                button4.PerformClick();
            }
            else
            {
                try
                {



                    SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                    conn.Open();
                    //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                    SqlDataReader reader;
                    SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, comboBox1.Text, Convert.ToInt32(comboBox2.Text)), conn);


                    reader = cmd.ExecuteReader();
                    reader.Read();
                    T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) + Convert.ToInt32(textBox6.Text);
                    T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) + Convert.ToInt32(textBox5.Text);
                    T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) + Convert.ToInt32(textBox4.Text);
                    T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) + Convert.ToInt32(textBox9.Text);
                    T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) + Convert.ToInt32(textBox8.Text);
                    T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) + Convert.ToInt32(textBox7.Text);



                    conn.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                button4.PerformClick();
            }
            
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //textBox5.Text = DateTime.Now.Month.ToString();
                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT nom from dbo.prod  WHERE UF ='{0}';", comboBox5.Text), conn);


                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetValue(0).ToString());
                    comboBox4.Items.Add(reader.GetValue(0).ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

            if ((comboBox1.Text == "Lundi") )
            {

                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();
                //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Dimanche", "3"), conn);


                reader = cmd.ExecuteReader();
                reader.Read();
                T2[0] = Convert.ToInt32(reader.GetValue(3).ToString()) ;
                T2[1] = Convert.ToInt32(reader.GetValue(4).ToString()) ;
                T2[2] = Convert.ToInt32(reader.GetValue(5).ToString()) ;
                T2[3] = Convert.ToInt32(reader.GetValue(6).ToString()) ;
                T2[4] = Convert.ToInt32(reader.GetValue(7).ToString()) ;
                T2[5] = Convert.ToInt32(reader.GetValue(8).ToString()) ;


                conn.Close();
            }
            if ((comboBox1.Text == "Mardi"))
        
            {

                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();
                //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Lundi", "3"), conn);


                reader = cmd.ExecuteReader();
                reader.Read();
                T2[0] = Convert.ToInt32(reader.GetValue(3).ToString());
                T2[1] = Convert.ToInt32(reader.GetValue(4).ToString());
                T2[2] = Convert.ToInt32(reader.GetValue(5).ToString());
                T2[3] = Convert.ToInt32(reader.GetValue(6).ToString());
                T2[4] = Convert.ToInt32(reader.GetValue(7).ToString());
                T2[5] = Convert.ToInt32(reader.GetValue(8).ToString());


                conn.Close();
            }

            if ((comboBox1.Text == "Mercredi"))
            {

                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();
                //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Mardi", "3"), conn);


                reader = cmd.ExecuteReader();
                reader.Read();
                T2[0] = Convert.ToInt32(reader.GetValue(3).ToString());
                T2[1] = Convert.ToInt32(reader.GetValue(4).ToString());
                T2[2] = Convert.ToInt32(reader.GetValue(5).ToString());
                T2[3] = Convert.ToInt32(reader.GetValue(6).ToString());
                T2[4] = Convert.ToInt32(reader.GetValue(7).ToString());
                T2[5] = Convert.ToInt32(reader.GetValue(8).ToString());


                conn.Close();
            }
            if ((comboBox1.Text == "Jeudi"))
            {

                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();
                //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Mercredi", "3"), conn);


                reader = cmd.ExecuteReader();
                reader.Read();
                T2[0] = Convert.ToInt32(reader.GetValue(3).ToString());
                T2[1] = Convert.ToInt32(reader.GetValue(4).ToString());
                T2[2] = Convert.ToInt32(reader.GetValue(5).ToString());
                T2[3] = Convert.ToInt32(reader.GetValue(6).ToString());
                T2[4] = Convert.ToInt32(reader.GetValue(7).ToString());
                T2[5] = Convert.ToInt32(reader.GetValue(8).ToString());


                conn.Close();
            }
            if ((comboBox1.Text == "Vendredi"))
            {

                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();
                //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Jeudi", "3"), conn);


                reader = cmd.ExecuteReader();
                reader.Read();
                T2[0] = Convert.ToInt32(reader.GetValue(3).ToString());
                T2[1] = Convert.ToInt32(reader.GetValue(4).ToString());
                T2[2] = Convert.ToInt32(reader.GetValue(5).ToString());
                T2[3] = Convert.ToInt32(reader.GetValue(6).ToString());
                T2[4] = Convert.ToInt32(reader.GetValue(7).ToString());
                T2[5] = Convert.ToInt32(reader.GetValue(8).ToString());


                conn.Close();
            }
            if ((comboBox1.Text == "Samedi"))
            {

                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();
                //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Vendredi", "3"), conn);


                reader = cmd.ExecuteReader();
                reader.Read();
                T2[0] = Convert.ToInt32(reader.GetValue(3).ToString());
                T2[1] = Convert.ToInt32(reader.GetValue(4).ToString());
                T2[2] = Convert.ToInt32(reader.GetValue(5).ToString());
                T2[3] = Convert.ToInt32(reader.GetValue(6).ToString());
                T2[4] = Convert.ToInt32(reader.GetValue(7).ToString());
                T2[5] = Convert.ToInt32(reader.GetValue(8).ToString());


                conn.Close();
            }
            if ((comboBox1.Text == "Dimanche"))
            {

                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();
                //SqlCommand cmd7 = new SqlCommand(String.Format("INSERT INTO  dbo.technicien (t_matricule,t_nom,t_prenom,t_secteur,t_equipe,t_equipement) values ('{0}', '{1}','{2}', '{3}', '{4}', '{5}')", textEdit3.Text, textEdit1.Text, textEdit2.Text, comboBoxEdit1.Text, comboBoxEdit2.Text, comboBoxEdit3.Text), conn);
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(String.Format("SELECT * from dbo.etat  WHERE UF ='{0}' and jour ='{1}' and equipe ='{2}' ;", comboBox5.Text, "Samedi", "3"), conn);


                reader = cmd.ExecuteReader();
                reader.Read();
                T2[0] = Convert.ToInt32(reader.GetValue(3).ToString());
                T2[1] = Convert.ToInt32(reader.GetValue(4).ToString());
                T2[2] = Convert.ToInt32(reader.GetValue(5).ToString());
                T2[3] = Convert.ToInt32(reader.GetValue(6).ToString());
                T2[4] = Convert.ToInt32(reader.GetValue(7).ToString());
                T2[5] = Convert.ToInt32(reader.GetValue(8).ToString());


                conn.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(global:: feeder.Properties.Settings.Default.TdBsecConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(string.Format("UPDATE dbo.etat  SET   TF1 ='" + T2[0] + "', TF2='" + T2[1] + "', TF3='" + T2[2] + "', TF4='" + T2[3] + "', TF5='" + T2[4] + "', TF6='" + T2[5] + "' WHERE UF ='{0}' and jour ='{1}';", comboBox5.Text, comboBox1.Text), conn);
                cmd.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("update état est fait avec succés");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }
    }
}
