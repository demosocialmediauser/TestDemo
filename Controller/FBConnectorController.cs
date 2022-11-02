using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FBConnector.Controller
{
    public class FBConnectorController : ApiController
    {
        public string Get()
        {
            return "FB Connector Running";
        }
    }
}
