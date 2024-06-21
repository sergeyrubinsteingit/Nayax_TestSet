using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet.TestRelatedClasses
{
    class MachinesScreen_
    {


        static Task RunTask;

        public static IWebElement TestMachine;

        public static Actions Actions_ = new Actions(TestProcedure.webDriver);

        public static bool IsItemInTheTree = false;


        public static void SearchForActor()
        {

            // navigates to Machines page
            TestProcedure.webDriver.Url = GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.URL_MACHINES];

            // performs a search for an actor
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.SearchForActor_.SearchForActorProcedure(

                    GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_FIELD],
                    GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_QA],
                    GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_NAME_ENTRY],
                    GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_SEARCH_BUTTON]

                ); // SearchForActorProcedure

            });
            RunTask.Wait();

            //// forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_));

            // opens machine in hierarchy
            RunTask = Task.Run(() =>
            {

                SearchForTestMachine();

            });
            RunTask.Wait();

            //// forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_));

        } // SearchForActor


        public static void SearchForTestMachine()
        {
            System.Console.WriteLine("\n<<< SearchForTestMachine begins>>>\n");

            List<string> ItemsInHierarchy = new List<string>();
            ItemsInHierarchy.Add(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.TEST_MASHINE]);
            ItemsInHierarchy.Add(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.UNASSIGNED_AREA]);

            int counter_ = 0;

            IWebElement ItemToClick_ = null;

            // searches first for the test machine. If it isn't found, searches for an Unassigned area element, clicks it, then searches for the machine again
            while (IsItemInTheTree == false)
            {
                for (int i = 0; i < ItemsInHierarchy.Count; i++)
                {
                    try
                    {

                        ItemToClick_ = new WebDriverWait(TestProcedure.webDriver, TimeSpan.FromMilliseconds(GloballyUsedClasses.BandwidthCheck.DownloadRate)).Until(driver_ => driver_.FindElement(By.XPath(ItemsInHierarchy[i])));

                        IsItemInTheTree = true;

                    }
                    catch (Exception)
                    {

                        IsItemInTheTree = false;

                    }

                    if (IsItemInTheTree == true)
                    {

                        Actions_.MoveToElement(ItemToClick_).Click().Perform();

                        // forced pause
                        System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

                        ItemToClick_ = new WebDriverWait(TestProcedure.webDriver, TimeSpan.FromSeconds(GloballyUsedClasses.BandwidthCheck.DownloadRate)).Until(driver_ => driver_.FindElement(By.XPath(ItemsInHierarchy[0])));

                        Actions_.MoveToElement(ItemToClick_).Click().Perform();

                        break;

                    } // if

                    counter_ += 1;

                    if (counter_ == 3)
                    {

                        System.Console.WriteLine("Element in hierarchy wasn't found. The test is shut down. Ciao!");

                        TestProcedure.webDriver.Quit();

                    }

                } // for

            } // while

            // clear list
            ItemsInHierarchy.Clear();

            System.Console.WriteLine("\n<<< SearchForTestMachine ends>>>\n");

        } // TestMachine

    }
}
