using Newtonsoft.Json;
using System.Collections.Generic;


namespace FBConnector.Model
{
   
       
       public class From
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class JsonDataModel
    {
        public string field { get; set; }
        public Value value { get; set; }
    }

    public class Value
    {
        public string item { get; set; }
        public string post_id { get; set; }
        public string verb { get; set; }
        public int published { get; set; }
        public int created_time { get; set; }
        public string message { get; set; }
        public From from { get; set; }
    }
    }
