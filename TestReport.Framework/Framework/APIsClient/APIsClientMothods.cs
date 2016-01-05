using Framework.Models;
using Newtonsoft.Json;
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
        private static string URL = "http://localhost:4319/api/";

        public int  GetIdStatus(string st)
        {
            int statusId = -1;

            WebRequest request = WebRequest.Create(string.Concat(URL, string.Format("status/?name={0}", st)));

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

        public int GetCurrentIdPhase()
        {
            int phaseId = -1;

            WebRequest request = WebRequest.Create(string.Concat(URL, "phases/?current=1"));

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

            WebRequest request = WebRequest.Create(string.Concat(URL, string.Format("projects/?name={0}", pr)));

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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(URL, "executions"));
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
