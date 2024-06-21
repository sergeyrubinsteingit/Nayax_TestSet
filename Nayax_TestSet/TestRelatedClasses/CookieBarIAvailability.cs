using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace Nayax_TestSet.TestRelatedClasses
{
    class CookieBarIAvailability
    {
        static Task RunTask;
        static IWebElement CookieBarElement;

        [Obsolete]
        public static IWebElement FindCookieBar() {

        System.Console.WriteLine("<<< Find cookie bar begins >>>");


            RunTask = Task.Run(() => {

                // gets a bandwidth rate
                GloballyUsedClasses.BandwidthCheck.RunBandwidthCheck();

            });
            RunTask.Wait();


            RunTask = Task.Run(() => {

            // search for Cookies bar
            CookieBarElement = GloballyUsedClasses.WaitTillExpectedCondition
            .ElementExistsByCssSelector(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.COOKIE_BAR], GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // asserts availability of the web element
            GloballyUsedClasses.Asserts.AssertElementExists(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement, "Cookie bar");

            // draws a border around the element
            GloballyUsedClasses.ScreenShotsTaker.DrawBorderAroundElementByCssSelector("Id", "onetrust-button-group-parent", "","");

            // takes a screenshot
            GloballyUsedClasses.ScreenShotsTaker.TakeScreenShot("Cookie_bar_", TestProcedure.webDriver.FindElement(By.TagName("body")));

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 1.2));

            // appends block to html
            GloballyUsedClasses.HtmlGenerator.AppendBlockToHtml(GloballyUsedClasses.ScreenShotsTaker.RecordForHtmlReport, GloballyUsedClasses.TestRecords.FinalRecord_);

            // clears the screenshots string from the previous data
            GloballyUsedClasses.ScreenShotsTaker.RecordForHtmlReport = "";

            RunTask = Task.Run(() => {

                // search for Cookies Accept button
                CookieBarElement = GloballyUsedClasses.WaitTillExpectedCondition
                .ElementExistsByCssSelector(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.COOKIE_CONFIRM_BUTTON], GloballyUsedClasses.BandwidthCheck.DownloadRate);

            });
            RunTask.Wait();

            // clicks the button "Accept"
            GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.Click();

            return CookieBarElement;
        }//FindCookieBar

    }
}
