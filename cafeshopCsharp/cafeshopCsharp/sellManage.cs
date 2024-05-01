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
        public sellManage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void createGrid()
        {

            clearPanel(mainPanel);
            int gridSizeX = 1430;
            int gridSizeY = 150;
            int margin = 5;
            string[] data = {"amazon","late","green tea","milk","milk tea", "cake" ,"back coffee"};

            int lableY = 15;
            int textY = 70;


            foreach (var i in Enumerable.Range(0,data.Length) )
            {

                Panel panel = new Panel
                {
                    Size = new Size(gridSizeX - 2 * margin, gridSizeY - 2 * margin),
                    Location = new Point(margin, i * (gridSizeY + margin) - gridSizeY + 10),
                    BorderStyle = BorderStyle.FixedSingle,


                };

                // Image-------------------------------------------- 
                PictureBox picture = new PictureBox {
                    Size = new Size(150, 130),
                    Location = new Point(margin, margin),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.White

                };


                Label labelPNametext = new Label {
                    Text = "ຊື່ສິນຄ້າ",
                    Location = new Point(300, lableY),
                    AutoSize = true,
                };
                
                //  Name -----------------------------------------------------------------------------
                Label labelPName = new Label
                {
                    Text =  data[i].ToString(),
                    Location = new Point(180, textY),
                    Size=new Size(300,40),
                    TextAlign= ContentAlignment.MiddleCenter,
                    Font = new Font("Phetsarath OT", 16, FontStyle.Bold),

                };



                Label labelTypetext = new Label {
                    Text = "ປະເພດສິນຄ້າ",
                    Location = new Point(580, lableY),
                    AutoSize = true,


                };

                // Type ---------------------------------------------------------------
                Label labelType = new Label
                {
                    Text = "hot",
                    Location = new Point(590, textY),
                    AutoSize = true,
                    Font = new Font("Phetsarath OT", 16, FontStyle.Bold),
                };


                Label labelsizetext = new Label
                {
                    Text = "ຂະໜາດ",
                    Location = new Point(800, lableY),
                    AutoSize = true,


                };

                // Sizes-------------------------------------------------------------------
                string[] sizes ={"S", "M", "L"};
                int Y = 50;
                int X = 800;
                int columnWidth = 50;
                foreach (var index in Enumerable.Range(0,sizes.Length)) {

                    int column = index % 2;
                    int rowthis = index / 2;
                    Label labelSize = new Label
                    {
                        Text = sizes[index],
                        AutoSize = true,
                        Location = new Point(X + column * columnWidth, Y + rowthis * 30),
                        Font = new Font("Phetsarath OT", 16, FontStyle.Bold),
                    };


                    // Size ------------------
                    panel.Controls.Add(labelSize);

                  
                } ;

                Label labelAuonttext = new Label
                {
                    Text = "ຈຳນວນ",
                    Location = new Point(1050, lableY),
                    AutoSize = true,
                   

                };

                Button downButton = new Button
                {
                    Size = new Size(40, 40),
                    Text = "-",
                    BackColor = Color.Red,
                    Location = new Point(1000, textY),
                };

                // Amount ------------------------------------------------------------------------------------
                TextBox textBoxAmount = new TextBox {
                    Size = new Size(60, 40),
                    
                    Text = "0",
                    ReadOnly = true,
                    TextAlign=HorizontalAlignment.Center,
                    Location=new Point(1050,textY),
                    Font = new Font("Phetsarath OT", 16, FontStyle.Bold),
                };


                Button upButton = new Button
                {

                    Size = new Size(40, 40),
                    Text = "+",
                    BackColor=Color.DarkGreen,
                    Location = new Point(1120, textY),
                    
                    
                    

                };

                downButton.Click += (sender, e) =>
                {
                    int amount = int.Parse(textBoxAmount.Text);
                    if (amount > 0) { 
                    amount--;
                    }
                    textBoxAmount.Text = amount.ToString();

                };
                upButton.Click += (sender, e) => {
                    int amount = int.Parse(textBoxAmount.Text);
                    amount++;
                    textBoxAmount.Text =amount.ToString();
                
                };



                // Button -----------------------------------------------------------------
                Button showButton = new Button {

                    Size = new Size(150, 40),
                    Text = "ເພີ່ມລົງ",
                    Location = new Point(1250, 40),
                    BackColor = Color.DarkGreen,
                    Font= new Font("Phetsarath OT", 14, FontStyle.Bold),

                };

                Button unshowButton = new Button
                {

                    Size = new Size(150, 40),
                    Text = "ນຳອອກ",
                    Location = new Point(1250, 90),
                    BackColor = Color.Red,
                    Font = new Font("Phetsarath OT", 14, FontStyle.Bold),

                };


                // ShowButton Even ---------------------------------------------------
                showButton.Click += (sender, e) => {

                    MessageBox.Show("show");
                
                };

                // UnshowButton Even ---------------------------------------------------------
                unshowButton.Click += (sender, e) => {

                    MessageBox.Show("unshow");
                };



                // Background Color Condition---------------------------------------------------------
                if (i % 2 == 0)
                {
                    panel.BackColor = Color.Red;

                }
                else {
                    panel.BackColor = Color.DarkGreen;
                }


                // Set Panel ------------------------------------------------------------------------

                // Image--------------
                panel.Controls.Add(picture);


                // Name---------------
                panel.Controls.Add(labelPNametext);
                panel.Controls.Add(labelPName);

                // Type --------------
                panel.Controls.Add(labelTypetext);
                panel.Controls.Add(labelType);
                // Size ----------------
                panel.Controls.Add(labelsizetext);

                //  Amount--------------
                panel.Controls.Add(labelAuonttext);
                panel.Controls.Add(textBoxAmount);
                panel.Controls.Add(downButton);
                panel.Controls.Add(upButton);

                // Button ----------------------
                panel.Controls.Add(showButton);
                panel.Controls.Add(unshowButton);




                mainPanel.Controls.Add(panel);
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
            createGrid();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }
    }


  

}
