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
    public partial class hello : Form
    {
        public hello()
        {
            InitializeComponent();
        }

        private void hello_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("meher");
        }
    }
}
