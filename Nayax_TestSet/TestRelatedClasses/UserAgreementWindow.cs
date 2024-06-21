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
    class UserAgreementWindow
    {
        static Task RunTask;

        public static int TextAreaHeight;

        public static int TextAreaWidth;

        public static List<int> DimensionsOfElement = new List<int>();


        [Obsolete]
        public static IWebElement AgreementFormAvailability() {


            RunTask = Task.Run(() => {

                // gets a bandwidth rate
                GloballyUsedClasses.BandwidthCheck.RunBandwidthCheck();

            });
            RunTask.Wait();


            RunTask = Task.Run(() => {

                // checks connection state
                GloballyUsedClasses.InternetConnectionCheck.AvailablePort();

            });

            RunTask.Wait();

            // search for Agreement window
            RunTask = Task.Run(() => {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.AGREEMENT_WIN], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_ * 2));

            }); 
            RunTask.Wait();

            // asserts availability of the web element
            GloballyUsedClasses.Asserts.AssertElementExists(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement, "Agreement window");

            // draws a border around the element
            GloballyUsedClasses.ScreenShotsTaker.DrawBorderAroundElementByCssSelector("Id", GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.GetAttribute("id"), "","");

            // screen shot
            GloballyUsedClasses.ScreenShotsTaker.TakeScreenShot("Agreement_window_", GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement);

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 1.2));

            // appends block to html
            GloballyUsedClasses.HtmlGenerator.AppendBlockToHtml(GloballyUsedClasses.ScreenShotsTaker.RecordForHtmlReport, GloballyUsedClasses.TestRecords.FinalRecord_);

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 1));

            // search for Agreement window
            RunTask = Task.Run(() => {

                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByXpath(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.AGREEMENT_LIST], (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 1));

            // to retrieve dimensions
            RunTask = Task.Run(() => {

                GloballyUsedClasses.GetElementDimensions.ElementDimensions(GloballyUsedClasses
                    .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.AGREEMENT_LIST], true);

            });
            RunTask.Wait();

            //System.Console.WriteLine("\n\nAGREEMENT_TEXT:\n" + GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.Text 
            //    + "\n=======================================================================================\n\n");


            // validates presence/absence of (+) signs in the text
            RunTask = Task.Run(() => {

                GloballyUsedClasses.MatchToRegex.ValidateByRegex(GloballyUsedClasses.WaitTillExpectedCondition
                    .ExpectedElement.Text, "[$&+,:;=?@#|'<>.^*()%!-]", "User Agreement > text of agreement.");

            });
            RunTask.Wait();

            // asserts element validity
            RunTask = Task.Run(() => {

                GloballyUsedClasses.Asserts.AssertElementValidity(GloballyUsedClasses.MatchToRegex.EvaluationFlag__, "User Agreement text");

            });
            RunTask.Wait();

            // draws a border around the element
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.ScreenShotsTaker.DrawBorderAroundElementByCssSelector("Id", "agreement_list", "","");

            });
            RunTask.Wait();

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 1));

            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.ScreenShotsTaker.TakeScreenShot("Agreement_text_", GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement);

            });
            RunTask.Wait();

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 1.2));

            // appends block to html
            GloballyUsedClasses.HtmlGenerator.AppendBlockToHtml(GloballyUsedClasses.ScreenShotsTaker.RecordForHtmlReport, GloballyUsedClasses.TestRecords.FinalRecord_);

            // clears the screenshots string from the previous data
            GloballyUsedClasses.ScreenShotsTaker.RecordForHtmlReport = "";

            // to close the window
            RunTask = Task.Run(() =>
            {

                AcceptAndCloseAgreementWindow();

            });
            RunTask.Wait();

            return GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement;

        }//ValidateWindowAvailability


        public static List<int> GetDimensionsOfElement() {


            RunTask = Task.Run(() => {

                string vvv_ = GloballyUsedClasses.TestData
                    .TestKeyValues[GloballyUsedClasses.TestData.KeyWords.AGREEMENT_LIST];

                // find Agreement list container
                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByXpath(vvv_, 120);

            });
            RunTask.Wait();

            //gets Client Height
            int ClientHeight_ = Convert.ToInt32((string)((IJavaScriptExecutor)TestProcedure.webDriver)
                .ExecuteScript("return arguments[0].clientHeight;", GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).ToString());

            Console.WriteLine("\n\n<<<<< Client Height: " + ClientHeight_.ToString() + " >>>>>\n");

            //gets Offset Height
            int ScrollHeight_ = Convert.ToInt32((string)((IJavaScriptExecutor)TestProcedure.webDriver)
                .ExecuteScript("return arguments[0].scrollHeight;", GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).ToString());

            Console.WriteLine("\n\n<<<<< Scroll Height: " + ScrollHeight_.ToString() + " >>>>>\n");

            DimensionsOfElement.Add(ClientHeight_);
            DimensionsOfElement.Add(ScrollHeight_);

            return DimensionsOfElement;

        }//GetDimensionsOfElement


        // closes Agreement window
        private static void AcceptAndCloseAgreementWindow()
        {

            System.Console.WriteLine("<<<<< Accept And Close Agreement Window begins >>>>>");

            Actions Actions_ = new Actions(TestProcedure.webDriver);

            //string[] InteractiveElements = { "input#agreement_1", "a#continue_btn" };

            List<string> InteractiveElementsList = new List<string>();
            InteractiveElementsList.Add(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.AGREEMENT_BOX]);
            InteractiveElementsList.Add(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.AGREEMENT_BUTTON]);

            for (int i = 0; i < InteractiveElementsList.Count; i++) {

                // find checkbox
                RunTask = Task.Run(() =>
                {
                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(InteractiveElementsList[i], Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 100));

                });
                RunTask.Wait();

                Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();

            }//for

        }// AcceptAndCloseAgreementWindow

    }
}
