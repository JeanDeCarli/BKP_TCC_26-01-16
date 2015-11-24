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

            int idPhase = 1;      //get the idPhase by the XML  setted by the addin

            string executionTime = this.stopTimer();
            DateTime executionDate = System.DateTime.Now;
            int idProject = 1;    //get the idProject by the XML  setted by the addin

            // set the information in the Execution Model
            currentTestResult.testName = testName;
            currentTestResult.idStatus = idStatus;

            currentTestResult.idPhase = idPhase;

            currentTestResult.executionTime = executionTime;
            currentTestResult.executionDate = executionDate;
            currentTestResult.idProject = idProject;

            // call the method to save the Execution Object
            db.SaveExecution(currentTestResult);
        }

        public void startTimer()
        {
            stopWatch.Start();
        }

        private string stopTimer()
        {
            stopWatch.Stop();

            string days = stopWatch.Elapsed.Days.ToString();
            string hours = stopWatch.Elapsed.Hours.ToString();
            string minutes = stopWatch.Elapsed.Minutes.ToString();
            string seconds = stopWatch.Elapsed.Seconds.ToString();
            string milliseconds = stopWatch.Elapsed.Milliseconds.ToString();

            string fullTime = days + ":" + hours + ":" + minutes + ":" + seconds + ":" + milliseconds;

            return fullTime;
        }
    }
}
