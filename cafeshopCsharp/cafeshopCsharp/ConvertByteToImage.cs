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


        public Image ByteToImage(byte[] ImageByte)
        {
            if (ImageByte == null || ImageByte.Length == 0)
            {
                // Handle null or empty byte array
                return null;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream(ImageByte))
                {
                    // Reset memory stream position
                    ms.Position = 0;

                    Image img = Image.FromStream(ms);
                    return img;
                }
            }
            catch (Exception ex)
            {
                // Handle image conversion error
                Console.WriteLine("Error converting byte array to image: " + ex.Message);
                return null;
            }
        }

        public byte[] ImageToByteArray(Image image)
        {
            if (image == null)
            {
                // Handle null or empty byte array
                return null;
            }
            try {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                // Handle image conversion error
                Console.WriteLine("Error converting image to byte array: " + ex.Message);
                return null;
            }

        }
    }
}
