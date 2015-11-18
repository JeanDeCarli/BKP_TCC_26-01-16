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
        private Stopwatch watch = new Stopwatch();

        public void CaptureTestsInformation()
        {
            // initialize objects
            var context =  TestContext.CurrentContext;
            var currentTestResult = new Execution();
            var db = new DbMethods();
            // get the runned test`s values
            string[] testsFullName = context.Test.FullName.Split('.');
            int idProject = db.getProjectsIdByName(testsFullName[0]);


            // set the information in the Execution Model
            currentTestResult.testName = testsFullName[2];
            
            this.SaveTestResult(currentTestResult);
            //System.Diagnostics.Debug.Write(currentTestResult.testsName + " " + currentTestResult.testsStatus + " " + currentTestResult.testsTime + " " + currentTestResult.testsDate);
        }

        public void startTimer()
        {
            this.watch.Start();
        }

        private string stopTimer()
        {
            var time = watch.ElapsedMilliseconds;
            return time.ToString();
        }

        private void SaveTestResult(Execution exec)
        {
            // salva no db.
        }
    }
}
