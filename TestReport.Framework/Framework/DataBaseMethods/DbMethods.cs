using Framework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataBaseMethods
{
    public class DbMethods
    {
        private TestReportEntities db = new TestReportEntities();

        public int getStatusIdByName(string statusName)
        {
            // get the status line from database where status name is equals to parameter
            var status = db.Status.Where(s => s.name.Equals(statusName)).FirstOrDefault();
            // return the ID of the status returned from DB
            return status.id;
        }

        public int getProjectsIdByName(string projectsName)
        {
            // get the project`s line from database where project`s name is equals to parameter
            var project = db.Projects.Where(p => p.name.Equals(projectsName)).FirstOrDefault();
            // return the ID of the status returned from DB
            return project.id;
        }

        public void SaveExecution(Execution exec)
        {
            // save a new line in the table Execution
            db.Executions.Add(exec);
        }
    }
}
