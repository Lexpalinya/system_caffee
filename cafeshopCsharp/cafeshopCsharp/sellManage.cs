using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeshopCsharp
{
    public partial class sellManage : Form
    {
            string[] data = {"amazon","late","green tea","milk","milk tea", "cake" ,"back coffee"};
        public sellManage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void createGrid(string [] data)
        {

            clearPanel(mainPanel);
            int y = 150;
            int x = 30;


           
            foreach (var i in Enumerable.Range(0, data.Length))

            {

                sellManageCard card = new sellManageCard(data[i])
                {
                    Location = new Point(x, (i + 1) * (y + 10) - y + 10)
                };
                mainPanel.Controls.Add(card);

            }





            mainPanel.AutoScroll = true;
            mainPanel.VerticalScroll.Enabled=true;
            mainPanel.VerticalScroll.Visible = true;


        }


        private void clearPanel(Panel panel) {
            panel.Controls.Clear();
        
        }

        private void sellManage_Load(object sender, EventArgs e)
        {
            createGrid(data);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {

                string[] isshow = data.Where(items => items.Contains("tea")).ToArray<string>();
                createGrid(isshow);

            }
            else {

                createGrid(data);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }


  

}
