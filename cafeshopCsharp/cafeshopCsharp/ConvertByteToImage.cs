using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace cafeshopCsharp
{
    class ConvertByteToImage
    {


        public void ConvertToImage(PictureBox picture,byte[] ImageByte) {
            try
            {

                using (MemoryStream ms = new MemoryStream(ImageByte))
                {

                    Image img = Image.FromStream(ms);
                    picture.Image = img;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading Image:" + ex.Message);
            }

        }
    }
}
