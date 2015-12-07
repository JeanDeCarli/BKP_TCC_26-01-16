using Framework.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.APIsClient
{
    public class APIsClientMothods
    {
        RestClient client = new RestClient("http://localhost:4319/");

        public int GetIdStatus(string st)
        {
            var request = new RestRequest(string.Format("api/status/?name={0}", st), Method.GET);
            Status queryResult = client.Execute<Status>(request).Data;
            return queryResult.id;
        }

        public int GetCurrentIdPhase()
        {
            var request = new RestRequest("api/phases/?current=1", Method.GET);
            Phase queryResult = client.Execute<Phase>(request).Data;
            return queryResult.id;
        }

        public int GetIdProject(string pr)
        {
            pr = pr.Replace(" ", "+");
            var request = new RestRequest(string.Format("api/projects/?name={0}", pr), Method.GET);
            Project queryResult = client.Execute<Project>(request).Data;
            return queryResult.id;
        }

        public void PostExecution(Execution exec)
        {
            var request = new RestRequest("api/executions/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(exec);
            client.Execute(request);
        }
    }
}
