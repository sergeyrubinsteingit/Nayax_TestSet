using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nayax_TestSet.TestRelatedClasses
{
    class SalesSummaryTest_
    {

        static Task RunTask;

        public static Actions Actions_ = new Actions(TestProcedure.webDriver);

        public static double SalesSummaryTotalValue = 0;

        public static bool PassedOrFailed;


        [Obsolete]
        public static void OpenSalesSummaryLog()
        {

            // navigates to Sales Summary screen
            TestProcedure.webDriver.Url = GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.URL_SALES_SUMMARY];

            // performs a search for an actor
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.SearchForActor_.SearchForActorProcedure(

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


            // search for the dropdown entries
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.TIME_LIST], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // makes a list of dropdown entries
            List<IWebElement> TimeDropdownElements = GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.FindElements(By.XPath(".//*")).ToList();
            // temp
            foreach (IWebElement Dropelement in TimeDropdownElements) {

                if (Dropelement.Text.Length > 0) {

                    System.Console.WriteLine("Dropdown element: " + Dropelement.Text);

                }//if

            }//foreach

            Actions_.MoveToElement(TimeDropdownElements[TimeDropdownElements.Count - 1]).Click().Perform();

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

            // search for the Start Date field
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.DATE_RANGE_START_FIELD], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // sending Start Date
            Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().SendKeys(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.DATE_RANGE_START_TIME]).Build().Perform();

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * 10);

            // search for the End Date field
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.DATE_RANGE_END_FIELD], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // sending End Date
            Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().SendKeys(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.DATE_RANGE_END_TIME]).Build().Perform();


            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * 10);

            // search for the View Report button
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.VIEW_REPORT_BUTTON], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // clicks the button
            Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();


            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * 10);

            // search and click on the Sales By Machine tab
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.SALES_BY_MACHINE_TAB], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate));

            });
            RunTask.Wait();

            // clicks the tab
            Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * 50);

            // fires Sales Summary total function
            RunTask = Task.Run(() =>
            {

                SalesSummaryTotal(_12monthsVs12monthsTest.TotalSumAsDouble);

            });
            RunTask.Wait();

            RunTask = Task.Run(() => {

                //search for the test result displaying DOM element
                GloballyUsedClasses.WaitTillExpectedCondition
                    .ElementExistsByCssSelector(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.TEST_RESULT_DISPLAY], 
                    GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)(GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // fires Screenshot taker
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.ScreenShotsTaker.TakeScreenShot("12vs12Months_SalesSummary ", TestProcedure.webDriver.FindElement(By.TagName("body")));

            });
            RunTask.Wait();

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

            // appends block to html
            GloballyUsedClasses.HtmlGenerator.AppendBlockToHtml(GloballyUsedClasses.ScreenShotsTaker.RecordForHtmlReport, GloballyUsedClasses.TestRecords.FinalRecord_);

            // clears the screenshots string from the previous data
            GloballyUsedClasses.ScreenShotsTaker.RecordForHtmlReport = "";


        } // OpenSalesSummaryLog


        public static double SalesSummaryTotal(double Total12vs12_) {

            System.Console.WriteLine("<<<<< SalesSummaryTotal begins >>>>>");

            try
            {
                RunTask = Task.Run(() =>
                {

                    //search for test machine's name in the log
                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByXpath(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.TEST_MACHINE_NAME],
                        GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)(GloballyUsedClasses.BandwidthCheck.Coefficient_));

                });
                RunTask.Wait();
            }
            catch (Exception)
            {
                try
                {
                    RunTask = Task.Run(() =>
                    {

                        //search for test machine's name in the log
                        GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByXpath("//*[@id=\"sales_by_operator_tab\"]/div/div[4]/div/table/tbody/tr",
                        GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)(GloballyUsedClasses.BandwidthCheck.Coefficient_));

                    });
                    RunTask.Wait();
                }
                catch (Exception)
                {
                    Environment.Exit(-1);
                    throw;
                }
            }// try

            // Lists all the elements contained in the log's row
            List<IWebElement> MachineDataRowContents = GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.FindElements(By.XPath("//td")).ToList();

            // regex to be used for filtering out the non-digit containing elements
            var regex_ = new Regex(@"^-?[0-9][0-9,\.]+$");

            // removes all the elements save for those containing numerics
            for (int i = 0; i < MachineDataRowContents.Count; i++)
            {
                if ( !regex_.IsMatch( MachineDataRowContents[i].Text) )
                {
                    MachineDataRowContents.RemoveAt(i);

                    i--;

                }//if

            }// for

            // to check the list
            foreach (IWebElement ItemInRow in MachineDataRowContents)
            {

                Console.WriteLine("ItemInRow: " + ItemInRow.Text);

            }// foreach

            SalesSummaryTotalValue = Convert.ToDouble(MachineDataRowContents[MachineDataRowContents.Count - 1].Text);
  
            string Message_;

            if (Total12vs12_ == SalesSummaryTotalValue)
            {

                Console.WriteLine("12vs12 PASSED");

                Message_ = "<h3 style=\'color:#FFFFFF;text-shadow: 1px 1px 1px #000000;\'>Test 12 Months vs 12 Months passed.</h3>" +
                    "Value in the chart: " + Total12vs12_.ToString() + ", value in Sales Summary log: " + SalesSummaryTotalValue.ToString();

                PassedOrFailed = true;

            }
            else {

                Console.WriteLine("12vs12 FAILED");

                Message_ = "<h2 style=\'color:#FFFFFF;text-shadow: 1px 1px 1px #000000;\'>Test 12 Months vs 12 Months failed.</h2> " +
                    "<span style=\'color:#000000;font-weight:regular;\'>Value in the chart: " + Total12vs12_.ToString() + ", value in Sales Summary log: " + SalesSummaryTotalValue.ToString() + "</span>";

                PassedOrFailed = false;

            }//if

            // inserts into DOM an element containing test result
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.InsertDomElementIntoHtmlCode.CreateDomElement(
                    Message_,
                    TestProcedure.webDriver.FindElement(By.TagName("body")),
                    PassedOrFailed
                    );

            });
            RunTask.Wait();

            // asserts test result
            RunTask = Task.Run(() => {

                GloballyUsedClasses.Asserts.AssertElementValidity(PassedOrFailed, "Chart 12 Months vs 12 Months");

            });
            RunTask.Wait();

            return SalesSummaryTotalValue;

        } // SalesSummaryTotal

    }
}
