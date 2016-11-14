using feeder.DAL;
using feeder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
namespace feeder
{
    static class Program
    {
        private const string FILE_NAME = "Test.data";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
                 Application.SetCompatibleTextRenderingDefault(false);
                 Application.Run(new Authentification());
            
          /*  Etat e=new Etat();
            ICollection<Buse> Buses=new List<Buse>();
            for (int i = 0; i < 33; i++)
			{
			 Buses.Add(new Buse{Quantite=i+1});
			}
            var tmp = "";
            e.Buses=Buses;
                 for (int i = 0; i < 33; i++)
                 {
                     tmp = tmp +","+ e.Buses.ElementAt(i).Quantite+",";
                 }

                 MessageBox.Show("");
        
           */
           }
    }
}










