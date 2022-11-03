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
    public class FBListenerController : ApiController
    {
        
            #region Fields

            private const string _verificationToken = "abc";

            #endregion

            #region Get Request

            [HttpGet]
            public HttpResponseMessage Get()
            {
                try
                {
                    var mode = HttpContext.Current.Request.QueryString["hub.mode"].ToString();
                    var challenge = HttpContext.Current.Request.QueryString["hub.challenge"].ToString();
                    var verifyToken = HttpContext.Current.Request.QueryString["hub.verify_token"].ToString();

                    //MongoDBManager.Insert("Verification", $"Mode->{mode}, Challenge->{challenge}, Verification Token->{verifyToken}");

                    if (verifyToken == _verificationToken)
                        return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(challenge) };
                    else
                        return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Invalid verification token") };
                }
                catch (Exception ex)
                {
                    //MongoDBManager.Insert($"Error", $"Get->{ex.Message}, StackTrace->{ex.StackTrace}");
                    return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(ex.Message) };
                }
            }

            #endregion Get Request

            #region Post Request

            [HttpPost]
            public async Task<HttpResponseMessage> Post([FromBody] JsonDataModel data)
            {
                //MongoDBManager.Insert("LeadGen", $"Data -> {JsonConvert.SerializeObject(data)}");
                try
                {
                    
                    var entry = data.Entry.FirstOrDefault();
                    var change = entry?.Changes.FirstOrDefault();
                    if (change == null) return new HttpResponseMessage(HttpStatusCode.BadRequest);

                    //Generate user access token here https://developers.facebook.com/tools/accesstoken/
                    const string token = "<Your Token>";

                    var leadUrl = $"https://graph.facebook.com/v14.0/{change.Value.LeadGenId}?access_token={token}";
                    var formUrl = $"https://graph.facebook.com/v14.0/{change.Value.FormId}?access_token={token}";

                    //MongoDBManager.Insert("LeadGen", $"LeadGenId -> {change.Value.LeadGenId}, FormId -> {change.Value.FormId}");

                    if (!string.IsNullOrEmpty(token))
                    {
                        using (var httpClientLead = new HttpClient())
                        {
                            var response = await httpClientLead.GetStringAsync(formUrl);
                        if (!string.IsNullOrEmpty(response))
                            WritetoFile("response ", response);
                        else
                            WritetoFile("response ", "No Response from FB");
                            //if (!string.IsNullOrEmpty(response))
                            //{
                            //    var jsonObjLead = JsonConvert.DeserializeObject<FBConnector.Model.LeadFormData>(response);
                            //    //jsonObjLead.Name contains the lead ad name

                            //    //If response is valid get the field data
                            //    using (var httpClientFields = new HttpClient())
                            //    {
                            //        var responseFields = await httpClientFields.GetStringAsync(leadUrl);
                            //        if (!string.IsNullOrEmpty(responseFields))
                            //        {
                            //            var jsonObjFields = JsonConvert.DeserializeObject<FBConnector.Model.LeadData>(responseFields);
                            //            //jsonObjFields.FieldData contains the field value
                            //        }
                            //    }
                            //}
                        }
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                
                WritetoFile("Error!!!! ",ex.ToString());
                    return new HttpResponseMessage(HttpStatusCode.BadGateway);
                }
            }

        #endregion Post Request

        #region WriteFile
        public static void WritetoFile(string Message,string dataasstring)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Response.txt"; // path to file
            using (FileStream fs = File.Create(path))
            {                
                
                byte[] info = new UTF8Encoding(true).GetBytes(Message+ ": " +dataasstring);
                fs.Write(info, 0, info.Length);

                // writing data in bytes already
                byte[] data = new byte[] { 0x0 };
                fs.Write(data, 0, data.Length);
            }

        }
        #endregion Write File
    }
}

