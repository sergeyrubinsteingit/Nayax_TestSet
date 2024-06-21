using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet.GloballyUsedClasses
{
    class SearchForActor_
    {

        static Task RunTask;

        public static Actions Actions_ = new Actions(TestProcedure.webDriver);


        public static void SearchForActorProcedure(string ActorField, string ActorName, string ActorNameEntry, string SearchButton)
        {

            try
            {
                // search for the actor field
                RunTask = Task.Run(() =>
                {

                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(ActorField, (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

                });
                RunTask.Wait();

                // sending an actor name
                GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.SendKeys(ActorName);

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

                // search for the actor name in the dropdown
                RunTask = Task.Run(() =>
                {

                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(ActorNameEntry, (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

                });
                RunTask.Wait();

                // clicks on the actor name in the dropdown
                Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();

                // search for the actor search button
                RunTask = Task.Run(() =>
                {

                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(SearchButton, (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

                });
                RunTask.Wait();

                // clicks on the actor search button
                Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();

            }
            catch (Exception)
            {

                System.Console.WriteLine("Actor wasn't found. The test is shut down. Ciao!");
                TestProcedure.webDriver.Quit();
                throw;

            }

        } //SearchForActorProcedure

    }
}
