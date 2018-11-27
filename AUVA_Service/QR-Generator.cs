using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QR_API
{
    public static class QR_Generator
    {
        public static string URL = "http://api.qrserver.com/v1/create-qr-code/";

        /// <summary>
        /// generates square QR code from given data as byte-array (png-file) with default
        /// size of 200 pixels
        /// </summary>
        /// <param name="data">The data that the QR code should contain</param>
        /// <param name="size">Side length of the square image (default 200 pixels)</param>
        /// <returns></returns>
        public static byte[] GenerateQRCode(string data, int size = 200)
        {
            using (WebClient client = new WebClient())
            {
                Stream stream = client.OpenRead(new Uri(URL+"?size="+size+"x"+size+"&data="+data));
                Image qr = Bitmap.FromStream(stream);
                return qr.toByteArray();
            }
        }
    }
}
