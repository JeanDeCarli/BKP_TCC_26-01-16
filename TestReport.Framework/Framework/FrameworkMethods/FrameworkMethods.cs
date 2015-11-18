using Framework.Models;
using NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DataBaseMethods;

namespace Framework
{
    public class FrameworkMethods
    {
        private Stopwatch stopWatch = new Stopwatch();

        public void CaptureTestsInformation()
        {
            // initialize objects
            var context =  TestContext.CurrentContext;
            var currentTestResult = new Execution();
            var db = new DbMethods();

            // get the runned test`s values
            string[] testsFullName = context.Test.FullName.Split('.');

            string testName = testsFullName[2];
            int idStatus = db.getStatusIdByName(context.Result.Status.ToString());

            //int idPhase = 

            TimeSpan executionTime = this.stopTimer();
            DateTime executionDate = System.DateTime.Now;
            int idProject = db.getProjectsIdByName(testsFullName[0]);
            
            // set the information in the Execution Model
            currentTestResult.testName = testName;
            currentTestResult.idStatus = idStatus;

            //currentTestResult.idPhase = ...

            currentTestResult.executionTime = executionTime;
            currentTestResult.executionDate = executionDate;
            currentTestResult.idProject = idProject;

            // call the method to save the Execution Object
            db.SaveExecution(currentTestResult);
            //System.Diagnostics.Debug.Write(currentTestResult.testsName + " " + currentTestResult.testsStatus + " " + currentTestResult.testsTime + " " + currentTestResult.testsDate);
        }

        public void startTimer()
        {
            stopWatch.Start();
        }

        private TimeSpan stopTimer()
        {
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
    }
}
