using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Nayax_TestSet.TestRelatedClasses
{
    class SearchForTestMachine
    {
        static Task RunTask;

        public static IWebElement TestMachine;

        public static void SearchForActor() {

            // navigates to Machines page
            TestProcedure.webDriver.Url = GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.URL_MACHINES];

            // search for the actor field
            RunTask = Task.Run(() => {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_FIELD], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // sending an actor name
            GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.SendKeys(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_QA]);

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

            // search for the actor search button
            RunTask = Task.Run(() => {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_SEARCH_BUTTON], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // clicks on the actor search button
            GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.Click();

            // opens machine in hierarchy
            RunTask = Task.Run(() => {

                OpenTestMachine();

            });
            RunTask.Wait();

        } // SearchForActor


        public static IWebElement OpenTestMachine() {



            return TestMachine;

        } // TestMachine

    }
}
