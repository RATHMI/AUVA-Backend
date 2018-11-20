using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AUVA.Service.Controllers
{
    [RoutePrefix("qr")]
    public class QRController : ApiController
    {
        [HttpGet, Route("generate/{data}/{size}")]
        public HttpResponseMessage Generate(string data, int size)
        {
            HttpResponseMessage result;
            var stream = new MemoryStream();

            // Convert FireEvents into a CSV file.
            byte[] file = QR_API.QR_Generator.GenerateQRCode(data, size);

            // Write file into the stream.
            stream.Write(file, 0, file.Length);

            // Set position of stream to 0 to avoid problems with the index.
            stream.Position = 0;

            result = new HttpResponseMessage(HttpStatusCode.OK);

            result.Content = new ByteArrayContent(stream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            return result;
        }
    }
}
