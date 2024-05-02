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


        public Image ByteToImage(byte[] ImageByte) {

            using (MemoryStream ms = new MemoryStream(ImageByte))
            {
                Image img = Image.FromStream(ms);
                return img;
            }
        }

        public  byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}
