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
    public partial class sellManageCard : UserControl
    {
        public sellManageCard()
        {
            InitializeComponent();


           
        }
        public sellManageCard(string name) {
            InitializeComponent();
            string[] sizes = { "S", "M", "L" };
            createPanelSize(sizes);
            lblName.Text = name;


        }

        public void createPanelSize(string [] sizes) {

          
            int Y = 10;
            int X = 10;
            int columnWidth = 50;
            foreach (var index in Enumerable.Range(0, sizes.Length))
            {

                int column = index % 2;
                int rowthis = index / 2;
                Label labelSize = new Label
                {
                    Text = sizes[index],
                    AutoSize = true,
                    Location = new Point(X + column * columnWidth, Y + rowthis * 30),
                    Font = new Font("Phetsarath OT", 16, FontStyle.Bold),
                    ForeColor=Color.Gold
                };


                // Size ------------------
                panelSize.Controls.Add(labelSize);


            };

        }



        private void UserControl1_Load(object sender, EventArgs e)
        {
           
        }

       

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            
            }
        }

        

        private void btnUp_Click(object sender, EventArgs e)
        {
            int amount = 0;
            if (!string.IsNullOrEmpty(txtAmount.Text) && int.TryParse(txtAmount.Text, out int currentAmount))
            {

                amount = currentAmount;
            }
                amount++;
                txtAmount .Text= amount.ToString();
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            int amount = 0;
            if (!string.IsNullOrEmpty(txtAmount.Text) && int.TryParse(txtAmount.Text, out int currentAmount))
            {

                amount = currentAmount;
            }
            if (amount > 0)  amount--;

            txtAmount.Text = amount.ToString();
        }
    }
}
