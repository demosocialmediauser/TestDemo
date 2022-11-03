using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBConnector.Model
{
    
    public class CustomerModel
    {
        public long id { get; set; }
        public string email { get; set; }
        public bool accepts_marketing { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int orders_count { get; set; }
        public string state { get; set; }
        public string total_spent { get; set; }
        public object last_order_id { get; set; }
        public string note { get; set; }
        public bool verified_email { get; set; }
        public object multipass_identifier { get; set; }
        public bool tax_exempt { get; set; }
        public string tags { get; set; }
        public object last_order_name { get; set; }
        public string currency { get; set; }
        public object phone { get; set; }
        public List<object> addresses { get; set; }
        public object accepts_marketing_updated_at { get; set; }
        public object marketing_opt_in_level { get; set; }
        public object sms_marketing_consent { get; set; }
        public string admin_graphql_api_id { get; set; }
    }
}