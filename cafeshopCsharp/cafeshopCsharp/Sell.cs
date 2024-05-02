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
    public partial class Sell : Form
    {
        public Sell()
        {
            InitializeComponent();
            string[] sizes = { "S", "M", "L" };
            createPanelSize(sizes);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        
        
        

        private void Sell_Load(object sender, EventArgs e)
        {
            
        }
        
           
            


        

        public void createPanelSize(string[] sizes)
        {


            int Y = 10;
            int X = 25;
            int columnWidth = 100;
            foreach (var index in Enumerable.Range(0, sizes.Length))
            {

                int column = index % 2;
                int rowthis = index / 2;
                Label labelSize = new Label
                {
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = sizes[index],
                    Size = new Size(94, 34),
                    BackColor = Color.White,
                    ForeColor = Color.Goldenrod,
                    
                  
                    Location = new Point(X + column * columnWidth, Y + rowthis * 40),
                    Font = new Font("Times new roman", 16, FontStyle.Bold),


                };
                labelSize.Click
+= (sender, e) =>
{
    lbsize.Text = labelSize.Text;

};


                // Size ------------------
                pnSize.Controls.Add(labelSize);


            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchMember sm = new searchMember();
            sm.Show();
        }
    }
}
