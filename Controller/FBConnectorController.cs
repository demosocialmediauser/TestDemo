using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FBConnector.Controller
{
    public class FBConnectorController : ApiController
    {
        public dynamic Get()
        {
            dynamic returnValue = null;
            string textFile = AppDomain.CurrentDomain.BaseDirectory + "Response.txt";
            if (File.Exists(textFile))
            {                   
                returnValue = File.ReadAllText(textFile);                
               
            }
            return returnValue;

        }
    }
}
