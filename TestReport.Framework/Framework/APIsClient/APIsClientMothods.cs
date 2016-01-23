using Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Framework.APIsClient
{
    public class APIsClientMothods
    {
        private static string URL = "http://localhost:4319/";
        private static string token = "bearer ";
        private static string user { get; set; }
        private static string pass { get; set; }

        public void setUser(string userParam)
        {
            user = userParam;
        }

        public void setPass(string passParam)
        {
            pass = passParam;
        }

        private string getToke()
        {
            try
            {
                if (token.Equals("bearer "))
                {
                    var request = (HttpWebRequest)WebRequest.Create(string.Concat(URL, "token"));

                    var postData = "grant_type=password";
                    postData += string.Format("&userName={0}", user);
                    postData += string.Format("&password={0}", pass);
                    var data = Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    string objText = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    var requestedToken = (JObject)JsonConvert.DeserializeObject(objText);
                    token = string.Concat(token, requestedToken["access_token"].Value<string>());
                }
                return token;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int  GetIdStatus(string st)
        {
            int statusId = -1;

            WebRequest request = WebRequest.Create(string.Concat(URL, string.Format("api/status/?name={0}", st)));
            
            request.Headers.Add(HttpRequestHeader.Authorization, getToke());

            using (var resp = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(resp.GetResponseStream()))
                {
                    string objText = reader.ReadToEnd();
                    var stat = JsonConvert.DeserializeObject<List<Status>>(objText);
                    statusId = stat[0].id;
                }
            }
            if (statusId != -1)
            {
                return statusId;
            }
            else
            {
                throw new Exception("Status not find");
            }
        }

        public int GetCurrentIdPhase(int idProject)
        {
            int phaseId = -1;

            WebRequest request = WebRequest.Create(string.Concat(URL, string.Format("api/phases/?idProject={0}", idProject)));
            request.Headers.Add(HttpRequestHeader.Authorization, getToke());

            using (var resp = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(resp.GetResponseStream()))
                {
                    string objText = reader.ReadToEnd();
                    var phase = JsonConvert.DeserializeObject<List<Phase>>(objText);
                    phaseId = phase[0].id;
                }
            }

            if (phaseId != -1)
            {
                return phaseId;
            }
            else
            {
                throw new Exception("Phase not find");
            }
        }

        public int GetIdProject(string pr)
        {
            int projectId = -1;

            WebRequest request = WebRequest.Create(string.Concat(URL, string.Format("api/projects/?name={0}", pr)));
            request.Headers.Add(HttpRequestHeader.Authorization, getToke());

            using (var resp = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(resp.GetResponseStream()))
                {
                    string objText = reader.ReadToEnd();
                    var proj = JsonConvert.DeserializeObject<List<Project>>(objText);
                    projectId = proj[0].id;
                }
            }

            if (projectId != -1)
            {
                return projectId;
            }
            else
            {
                throw new Exception("Project not find");
            }
        }

        public void PostExecution(Execution exec)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(URL, "api/executions"));
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, getToke());

            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(exec);

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
