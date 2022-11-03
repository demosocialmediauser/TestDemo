using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using FBConnector.Model;
using System.IO;
using System.Text;
using System.Data.SqlTypes;

namespace FBConnector.Controller
{
    public class ShopifyController : ApiController
    {

        public string Get()
        {
            string returnValue = "No file created yet";
            string textFile = AppDomain.CurrentDomain.BaseDirectory + "ResponseShopify.txt";
            if (File.Exists(textFile))
            {
                returnValue = File.ReadAllText(textFile);

            }
            return returnValue;

        }



        #region Post Request

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] JsonDataModel data)
        {

            try
            {
                WritetoFile("Datafrom FB ", JsonConvert.SerializeObject(data));
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                WritetoFile("Error!!!! ", ex.ToString());
                return new HttpResponseMessage(HttpStatusCode.BadGateway);
            }
        }

        #endregion Post Request

        #region WriteFile
        public static void WritetoFile(string Message, string dataasstring)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "ResponseShopify.txt"; // path to file
            using (FileStream fs = File.Create(path))
            {

                byte[] info = new UTF8Encoding(true).GetBytes(Message + ": " + dataasstring);
                fs.Write(info, 0, info.Length);

                // writing data in bytes already
                byte[] data = new byte[] { 0x0 };
                fs.Write(data, 0, data.Length);
            }

        }
        #endregion Write File
    }
}
