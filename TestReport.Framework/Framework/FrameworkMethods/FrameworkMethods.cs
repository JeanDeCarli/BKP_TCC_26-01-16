using Framework.APIsClient;
using Framework.Models;
using NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class FrameworkMethods
    {
        private Stopwatch stopWatch = new Stopwatch();

        public void CaptureTestsInformation()
        {
            try
            {
                // initialize objects
                var context = TestContext.CurrentContext;
                var currentTestResult = new Execution();
                var api = new APIsClientMothods();

                // get the runned test`s values
                string[] testsFullName = context.Test.FullName.Split('.');

                currentTestResult.testName = testsFullName[2];
                currentTestResult.idStatus = api.GetIdStatus(context.Result.Status.ToString());
                currentTestResult.idPhase = api.GetCurrentIdPhase();

                currentTestResult.executionTime = this.stopTimer();
                currentTestResult.executionDate = System.DateTime.Now;
                currentTestResult.idProject = api.GetIdProject(testsFullName[0]);

                // call the method to save the Execution Object
                api.PostExecution(currentTestResult);
            }
            catch (Exception)
            {
                throw;
            }
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
