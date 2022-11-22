using Newtonsoft.Json;
using System.Collections.Generic;


namespace FBConnector.Model
{
   
       
        public class Change
    {
        public Value value { get; set; }
        public string field { get; set; }
    }

    public class Entry
    {
        public string id { get; set; }
        public int time { get; set; }
        public List<Change> changes { get; set; }
    }

    public class From
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class JsonDataModel
    {
        public List<Entry> entry { get; set; }
        public string @object { get; set; }
    }

    public class Value
    {
        public From from { get; set; }
        public string post_id { get; set; }
        public int created_time { get; set; }
        public string item { get; set; }
        public string parent_id { get; set; }
        public string reaction_type { get; set; }
        public string verb { get; set; }
    }
    }
