using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class TestResult
    {
        public string testsName { get; set; }
        public string testsStatus { get; set; }
        public string testsTime { get; set; }
        public string testsError { get; set; }
        public DateTime testsDate { get; set; }

        public TestResult(string testsName, string testsStatus, string testsTime, string testsError)
        {
            this.testsName = testsName;
            this.testsStatus = testsStatus;
            this.testsTime = testsTime;
            this.testsError = testsError;
            this.testsDate = System.DateTime.Now;
        }
    }
}