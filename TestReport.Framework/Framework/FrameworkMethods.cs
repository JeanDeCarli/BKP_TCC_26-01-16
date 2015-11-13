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
        private Stopwatch watch = new Stopwatch();

        public void CaptureTestsInformation()
        {
            var context =  TestContext.CurrentContext;
            var currentTestResult = new TestResult(context.Test.FullName, context.Result.Status.ToString(), this.stopTimer(), "teste de erro");
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
    }
}
