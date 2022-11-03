using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;

namespace FBConnector.Controller
{
    public class FBConnectorController : ApiController
    {
        public string Get()
        {
            string returnValue = "No file created yet";
            try
            {
                
                string textFile = AppDomain.CurrentDomain.BaseDirectory + "Response.txt";
                if (File.Exists(textFile))
                {
                    returnValue = File.ReadAllText(textFile);

                }
            }
            catch(Exception ex)
            {
                returnValue = ex.ToString();
            }
            return returnValue;

        }
    }
}
