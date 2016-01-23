
using Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatedTests
{
    public class Tests
    {
        private FrameworkMethods fm = new FrameworkMethods("test1@test.com", "Password1!");

        #region SetUP and TearDown
        [SetUp]
        public void setup()
        {
            fm.startTimer();
        }

        [TearDown]
        public void TearDown()
        {
            fm.CaptureTestsInformation();
        }
        #endregion

        #region Non-Tests

        public void Execute()
        {
            Random rnd = new Random();

            int rnum = rnd.Next(1, 4);

            switch (rnum)
            {
                case 1:
                    {
                        Assert.Ignore();
                        break;
                    }
                case 2:
                    {
                        Assert.Fail();
                        break;
                    }
                case 3:
                    {
                        Assert.Pass();
                        break;
                    }
                default:
                    break;
            }
        }

        #endregion

        #region Test Methods

        [Test]
        public void Test1()
        {
            this.Execute();
        }

        [Test]
        public void Test2()
        {
            this.Execute();
        }

        [Test]
        public void Test3()
        {
            this.Execute();
        }

        [Test]
        public void Test4()
        {
            this.Execute();
        }

        [Test]
        public void Test5()
        {
            this.Execute();
        }

        [Test]
        public void Test6()
        {
            this.Execute();
        }

        [Test]
        public void Test7()
        {
            this.Execute();
        }

        [Test]
        public void Test8()
        {
            this.Execute();
        }

        [Test]
        public void Test9()
        {
            this.Execute();
        }

        [Test]
        public void Test10()
        {
            this.Execute();
        }

        [Test]
        public void Test11()
        {
            this.Execute();
        }

        [Test]
        public void Test12()
        {
            this.Execute();
        }

        [Test]
        public void Test13()
        {
            this.Execute();
        }

        [Test]
        public void Test14()
        {
            this.Execute();
        }

        [Test]
        public void Test15()
        {
            this.Execute();
        }

        [Test]
        public void Test16()
        {
            this.Execute();
        }

        [Test]
        public void Test17()
        {
            this.Execute();
        }

        [Test]
        public void Test18()
        {
            this.Execute();
        }

        [Test]
        public void Test19()
        {
            this.Execute();
        }

        [Test]
        public void Test20()
        {
            this.Execute();
        }

        [Test]
        public void Test21()
        {
            this.Execute();
        }

        [Test]
        public void Test22()
        {
            this.Execute();
        }

        [Test]
        public void Test23()
        {
            this.Execute();
        }

        [Test]
        public void Test24()
        {
            this.Execute();
        }

        [Test]
        public void Test25()
        {
            this.Execute();
        }

        [Test]
        public void Test26()
        {
            this.Execute();
        }

        [Test]
        public void Test27()
        {
            this.Execute();
        }

        [Test]
        public void Test28()
        {
            this.Execute();
        }

        [Test]
        public void Test29()
        {
            this.Execute();
        }

        [Test]
        public void Test30()
        {
            this.Execute();
        }

        [Test]
        public void Test31()
        {
            this.Execute();
        }

        [Test]
        public void Test32()
        {
            this.Execute();
        }

        [Test]
        public void Test33()
        {
            this.Execute();
        }

        [Test]
        public void Test34()
        {
            this.Execute();
        }

        [Test]
        public void Test35()
        {
            this.Execute();
        }

        [Test]
        public void Test36()
        {
            this.Execute();
        }

        [Test]
        public void Test37()
        {
            this.Execute();
        }

        [Test]
        public void Test38()
        {
            this.Execute();
        }

        [Test]
        public void Test39()
        {
            this.Execute();
        }

        [Test]
        public void Test40()
        {
            this.Execute();
        }

        [Test]
        public void Test41()
        {
            this.Execute();
        }

        [Test]
        public void Test42()
        {
            this.Execute();
        }

        [Test]
        public void Test43()
        {
            this.Execute();
        }

        [Test]
        public void Test44()
        {
            this.Execute();
        }

        [Test]
        public void Test45()
        {
            this.Execute();
        }

        [Test]
        public void Test46()
        {
            this.Execute();
        }

        [Test]
        public void Test47()
        {
            this.Execute();
        }

        [Test]
        public void Test48()
        {
            this.Execute();
        }

        [Test]
        public void Test49()
        {
            this.Execute();
        }

        [Test]
        public void Test50()
        {
            this.Execute();
        }

        [Test]
        public void Test51()
        {
            this.Execute();
        }

        [Test]
        public void Test52()
        {
            this.Execute();
        }

        [Test]
        public void Test53()
        {
            this.Execute();
        }

        [Test]
        public void Test54()
        {
            this.Execute();
        }

        [Test]
        public void Test55()
        {
            this.Execute();
        }

        [Test]
        public void Test56()
        {
            this.Execute();
        }

        [Test]
        public void Test57()
        {
            this.Execute();
        }

        [Test]
        public void Test58()
        {
            this.Execute();
        }

        [Test]
        public void Test59()
        {
            this.Execute();
        }

        [Test]
        public void Test60()
        {
            this.Execute();
        }

        [Test]
        public void Test61()
        {
            this.Execute();
        }

        [Test]
        public void Test62()
        {
            this.Execute();
        }

        [Test]
        public void Test63()
        {
            this.Execute();
        }

        [Test]
        public void Test64()
        {
            this.Execute();
        }

        [Test]
        public void Test65()
        {
            this.Execute();
        }

        [Test]
        public void Test66()
        {
            this.Execute();
        }

        [Test]
        public void Test67()
        {
            this.Execute();
        }

        [Test]
        public void Test68()
        {
            this.Execute();
        }

        [Test]
        public void Test69()
        {
            this.Execute();
        }

        [Test]
        public void Test70()
        {
            this.Execute();
        }

        [Test]
        public void Test71()
        {
            this.Execute();
        }

        [Test]
        public void Test72()
        {
            this.Execute();
        }

        [Test]
        public void Test73()
        {
            this.Execute();
        }

        [Test]
        public void Test74()
        {
            this.Execute();
        }

        [Test]
        public void Test75()
        {
            this.Execute();
        }

        [Test]
        public void Test76()
        {
            this.Execute();
        }

        [Test]
        public void Test77()
        {
            this.Execute();
        }

        [Test]
        public void Test78()
        {
            this.Execute();
        }

        [Test]
        public void Test79()
        {
            this.Execute();
        }

        [Test]
        public void Test80()
        {
            this.Execute();
        }

        [Test]
        public void Test81()
        {
            this.Execute();
        }

        [Test]
        public void Test82()
        {
            this.Execute();
        }

        [Test]
        public void Test83()
        {
            this.Execute();
        }

        [Test]
        public void Test84()
        {
            this.Execute();
        }

        [Test]
        public void Test85()
        {
            this.Execute();
        }

        [Test]
        public void Test86()
        {
            this.Execute();
        }

        [Test]
        public void Test87()
        {
            this.Execute();
        }

        [Test]
        public void Test88()
        {
            this.Execute();
        }

        [Test]
        public void Test89()
        {
            this.Execute();
        }

        [Test]
        public void Test90()
        {
            this.Execute();
        }

        [Test]
        public void Test91()
        {
            this.Execute();
        }

        [Test]
        public void Test92()
        {
            this.Execute();
        }

        [Test]
        public void Test93()
        {
            this.Execute();
        }

        [Test]
        public void Test94()
        {
            this.Execute();
        }

        [Test]
        public void Test95()
        {
            this.Execute();
        }

        [Test]
        public void Test96()
        {
            this.Execute();
        }

        [Test]
        public void Test97()
        {
            this.Execute();
        }

        [Test]
        public void Test98()
        {
            this.Execute();
        }

        [Test]
        public void Test99()
        {
            this.Execute();
        }

        [Test]
        public void Test100()
        {
            this.Execute();
        }

        #endregion
    }
}
