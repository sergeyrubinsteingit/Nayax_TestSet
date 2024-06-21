using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Nayax_TestSet.TestRelatedClasses
{
    class MachinesScreen
    {
        static Task RunTask;

        public static IWebElement TestMachine;

        public static Actions Actions_ = new Actions(TestProcedure.webDriver);


        public static void SearchForActor()
        {

            // navigates to Machines page
            TestProcedure.webDriver.Url = GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.URL_MACHINES];

            // search for the actor field
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_FIELD], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // sending an actor name
            GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.SendKeys(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_QA]);

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

            // search for the actor search button
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_SEARCH_BUTTON], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // clicks on the actor search button
            GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.Click();

            // opens machine in hierarchy
            RunTask = Task.Run(() =>
            {

                SearchForTestMachine();

            });
            RunTask.Wait();

        } // SearchForActor


        public static void SearchForTestMachine()
        {
            // searches first for the test machine. If it isn't found, searches for an Unassigned area element, clicks it, then searches for the machine again and clicks it
            try {

                OpenItemInHierarchy(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.TEST_MASHINE]);

            } catch (NoSuchElementException) {

                try
                {



                }
                catch (NoSuchElementException)
                {



                } // try2

            } // try1


        } // TestMachine


        // opens item
        public static IWebElement OpenItemInHierarchy(IWebElement ItemToOpen_)
        {
            // search for the machine
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(, (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            TestMachine = GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement;

            Actions_.MoveToElement(TestMachine).Click().Perform();

            return TestMachine;
        }
    }
}
