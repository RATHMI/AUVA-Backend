using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_API
{
    static class ImageExtensions
    {
        // extension method
        // source: https://stackoverflow.com/a/23731642/6427465
        public static byte[] toByteArray(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
