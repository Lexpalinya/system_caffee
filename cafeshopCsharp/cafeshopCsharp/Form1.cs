using cafeshopCsharp.connection_DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace cafeshopCsharp
{
    public partial class Form1 : Form
    {
        private connectionDB conn=new connectionDB();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.getConnectionDB();
        }
    }
}
