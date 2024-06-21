using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet.TestRelatedClasses
{
    class NotificationPopupTest
    {
        public static IWebElement PopUpNotification = null;

        public static Task RunTask;

        public static string PopupClassName = "";


        // retrieves either success or error notification
        [Obsolete]
        public static IWebElement NotificationTest()
        {
            System.Console.WriteLine("<<<<< Notification test >>>>>");

            try
            {

                // search for Success notification
                RunTask = Task.Run(() =>
                {

                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                        .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.NOTIF_SUCCESS], GloballyUsedClasses.BandwidthCheck.DownloadRate);

                });
                RunTask.Wait();

                // to retrieve dimensions
                RunTask = Task.Run(() => {

                    GloballyUsedClasses.GetElementDimensions.ElementDimensions(GloballyUsedClasses
                        .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.NOTIF_SUCCESS], false);

                });
                RunTask.Wait();

                // asserts element designates "success"
                RunTask = Task.Run(() =>
                {

                    GloballyUsedClasses.Asserts.AssertElementValidity(true, "Notification");

                });
                RunTask.Wait();

                PopupClassName = "notification success";

                RunTask = Task.Run(() =>
                {
                        // calls TakeShotAndAppendToHtml
                        TakeShotAndAppendToHtml(PopupClassName);
                });
                RunTask.Wait();

                return PopUpNotification;

            }
            catch (NoSuchElementException)
            {

                try
                {
                    // search for Error notification
                    RunTask = Task.Run(() =>
                    {

                        GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                            .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.NOTIF_ERROR], GloballyUsedClasses.BandwidthCheck.DownloadRate);

                    });
                    RunTask.Wait();

                    // to retrieve dimensions
                    RunTask = Task.Run(() => {

                        GloballyUsedClasses.GetElementDimensions.ElementDimensions(GloballyUsedClasses
                            .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.NOTIF_SUCCESS], false);

                    });
                    RunTask.Wait();

                    // asserts element designates "error"
                    RunTask = Task.Run(() =>
                    {

                        GloballyUsedClasses.Asserts.AssertElementValidity(false, "Notification");

                    });
                    RunTask.Wait();

                    PopupClassName = "notification error";

                    RunTask = Task.Run(() =>
                    {
                        // calls TakeShotAndAppendToHtml
                        TakeShotAndAppendToHtml(PopupClassName);

                    });
                    RunTask.Wait();

                    return PopUpNotification;

                }
                catch (NoSuchElementException)
                {

                    System.Console.WriteLine("No popup notification had been observed.");

                    return null;

                }

            }// NotificationTest

        }

        // Takes a shot and appends it to HTML
        [Obsolete]
        static void TakeShotAndAppendToHtml(string ElementClassName) {

            System.Console.WriteLine("Take Shot And Append To Html, > START.");

            //Repeat attempts if an element is stale
            bool staleElementState = true;

            int counter_ = 0;

            try {

                while (staleElementState)
                {
                    System.Console.WriteLine(" <<<<<<<<< WAIT FOR STALE ELEMENT BEGINS >>>>>>>>>> ");

                    // forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

                    // draws a border around the element
                    RunTask = Task.Run(() =>
                    {

                        GloballyUsedClasses.ScreenShotsTaker.DrawBorderAroundElementByCssSelector("ClassName", PopupClassName, "s", "[0]");

                    });
                    RunTask.Wait();


                    RunTask = Task.Run(() =>
                    {

                        GloballyUsedClasses.ScreenShotsTaker.TakeScreenShot("Notification_", GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement);

                    });
                    RunTask.Wait();


                    // forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 1.2));

                    // appends block to html
                    GloballyUsedClasses.HtmlGenerator.AppendBlockToHtml(GloballyUsedClasses.ScreenShotsTaker.RecordForHtmlReport, GloballyUsedClasses.TestRecords.FinalRecord_);

                    // clears the screenshots string from the previous data
                    GloballyUsedClasses.ScreenShotsTaker.RecordForHtmlReport = "";


                    //Breaks the While cycle	     
                    staleElementState = false;

                    System.Console.WriteLine(" <<<<<<<<< WAIT FOR STALE ELEMENT ENDS >>>>>>>>>> ");

                }//while

            } catch (StaleElementReferenceException) {

                //Continues the While cycle
                staleElementState = true;

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 1));

                counter_++;

                if (counter_ > 5)
                {

                    System.Console.WriteLine(" <<<<<<<<< Failed to find a tested element. Test is shut down. >>>>>>>>>> ");
                    TestProcedure.webDriver.Quit();

                };//if

            } // try

            System.Console.WriteLine("Take Shot And Append To Html, > END.");

        }// TakeShotAndAppendToHtml
    }
}
