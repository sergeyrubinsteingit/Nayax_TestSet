using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet.TestRelatedClasses
{
    class SalesSummaryTest
    {

        static Task RunTask;

        public static Actions Actions_ = new Actions(TestProcedure.webDriver);


        public static void OpenSalesSummaryLog() {
        
            // navigates to Sales Summary screen
            TestProcedure.webDriver.Url = GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.URL_SALES_SUMMARY];

            // performs a search for an actor
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.SearchForActor.SearchForActorProcedure(

                    GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_FIELD_REPORTS],
                    GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_QA],
                    GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.ACTOR_NAME_ENTRY],
                    GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.VIEW_REPORT_BUTTON]

                ); // SearchForActorProcedure

            });
            RunTask.Wait();


            // search in the Time Period field
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.TIME_PERIOD_FIELD], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // clicks in the Time Period field
            Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();

            // scroll down to "DateRange" entry in the dropdown


        } // OpenSalesSummaryLog

    }
}
