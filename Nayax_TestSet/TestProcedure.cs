using Microsoft.Win32;
using Nayax_TestSet.TestRelatedClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet
{
    class TestProcedure
    {
        public static IWebDriver webDriver;

        static Task RunTask;

        [Obsolete]
        static void Main(string[] args)
        {
            // available browsers
            Microsoft.Win32.RegistryKey RegistryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
            foreach (string browserName in RegistryKey.GetSubKeyNames()) { Console.WriteLine(browserName); }//
            
            // to prevent failure after 60 sec. wait
            //var options = new ChromeOptions();
            //options.AddArgument("no-sandbox");

            // gets a bandwidth rate
            GloballyUsedClasses.BandwidthCheck.RunBandwidthCheck();

            RunTask = Task.Run(() => {

                // checks connection state
                GloballyUsedClasses.InternetConnectionCheck.AvailablePort();

            });

            RunTask.Wait();


            ///////////////////////////////////////////////////////////////////////////


            // creates screenshots directory
            GloballyUsedClasses.ScreenShotsTaker.CreateShotsDirectory();

            // creates a log file
            GloballyUsedClasses.TestRecords.CreateTestLogFile();

            // writes opening tags to HTML report file
            GloballyUsedClasses.HtmlGenerator.CreateHtmlOpeningTags();

            // sets a webdriver for Chrome
            webDriver = new ChromeDriver();


            //////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT BEGINS //////////////////////
            //////////////////////////////////////////////////////////////////////////////


            ////sign in to api to get a token
            //_ = TestRelatedClasses.PostApiRequest.PostRequest("Get Token", GloballyUsedClasses.ApiRequestsCortex.SignIn_, GloballyUsedClasses.ApiRequestsCortex.SignInEndpoint_, false, true);

            //// forced pause
            //System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * 100);

            //// send E-receipt api request with a valid transaction id
            //_ = TestRelatedClasses.PostApiRequest.PostRequest("E-Receipt", GloballyUsedClasses.ApiRequestsCortex.Ereceipt_, GloballyUsedClasses.ApiRequestsCortex.EreceiptEndpoint_, true, false);


            //////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT ENDS__ //////////////////////
            //////////////////////////////////////////////////////////////////////////////
            ///

            // navigates to DCS login page
            webDriver.Url = GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.URL_QA];

            // maximizes a window
            webDriver.Manage().Window.Maximize();

            // deletes cookies
            webDriver.Manage().Cookies.DeleteAllCookies();

            // forsed pause to let cookies be deleted
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));


            //////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT BEGINS //////////////////////
            //////////////////////////////////////////////////////////////////////////////


            // sets user status to zero = new user
            RunTask = Task.Run(() =>
            {
                TestRelatedClasses.SetUserStatusToZero.UpdateUserStatusToZero();
            });
            RunTask.Wait();


            //////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT ENDS //////////////////////
            //////////////////////////////////////////////////////////////////////////////


            // fires LoginFlow method
            RunTask = Task.Run(() =>
            {
                GloballyUsedClasses.LoginToDcs.LoginFlow();
            });
            RunTask.Wait();

            // fires SMS or Moma method
            RunTask = Task.Run(() =>
            {
                GloballyUsedClasses.SmsOrMomaLogin.SmsInputField();
            });
            RunTask.Wait();

            // Verifies availability of the Cookie bar
            RunTask = Task.Run(() =>
            {
                _ = TestRelatedClasses.CookieBarIAvailability.FindCookieBar();
            });
            RunTask.Wait();


            //////////////////////////////////////////////////////////////////////////////
            ///////////////////// TEMPORARY COMMENTED SCRIPT BEGINS //////////////////////
            //////////////////////////////////////////////////////////////////////////////


            // Verifies availability of the User Agreement form
            RunTask = Task.Run(() =>
            {

                TestRelatedClasses.UserAgreementWindow.AgreementFormAvailability();

            });
            RunTask.Wait();

            // Verifies availability of the notification popup
            RunTask = Task.Run(() =>
            {

                TestRelatedClasses.NotificationPopupTest.NotificationTest();

            });
            RunTask.Wait();

            // Verifies UI version, switches to the old one if necessary
            RunTask = Task.Run(() =>
            {

                GloballyUsedClasses.SwitchToOldDcs.SwitchToOldDcsUi();

            });
            RunTask.Wait();

            // Navigates to Machines screen and searches for an actor
            RunTask = Task.Run(() =>
            {

                TestRelatedClasses.MachinesScreen_.SearchForActor();

            });
            RunTask.Wait();

            // Gets a data from 12vs12months chart
            RunTask = Task.Run(() =>
            {

                TestRelatedClasses._12monthsVs12monthsTest.Last12MonthsVsPrevious12MonthTotal();

            });
            RunTask.Wait();

            // Gets a data from Sales Summary report
            RunTask = Task.Run(() =>
            {

                TestRelatedClasses.SalesSummaryTest_.OpenSalesSummaryLog();

            });
            RunTask.Wait();

            // forced pause - temporary , just to see the result
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 10));




            //////////////////////////////////////////////////////////////////////////////
            ////////////////////// TEMPORARY COMMENTED SCRIPT ENDS //////////////////////
            ////////////////////////////////////////////////////////////////////////////



            // Closes the HTML report file
            RunTask = Task.Run(() =>
            {
                GloballyUsedClasses.HtmlGenerator.CreateHtmlClosingTags();
            });

            RunTask.Wait();

            // API sending flow
            string[] RequestBodies = { GloballyUsedClasses.ApiRequestsCortex.Ereceipt_, GloballyUsedClasses.ApiRequestsCortex.EreceiptWrong_ };

            string[] ApiMarkers = { "E-Receipt_Valid", "E-Receipt_Invalid" };

            for (int i = 0; i < RequestBodies.Length; i++)
            {

                // forced pause
                System.Threading.Thread.Sleep((int)(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * ((double)GloballyUsedClasses.BandwidthCheck.Coefficient_) * 2));

                //sign in to api to get a token
                _ = TestRelatedClasses.PostApiRequest.PostRequest("Get Token", GloballyUsedClasses.ApiRequestsCortex.SignIn_, GloballyUsedClasses.ApiRequestsCortex.SignInEndpoint_, false, true);

                // forced pause
                System.Threading.Thread.Sleep((int)(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * ((double)GloballyUsedClasses.BandwidthCheck.Coefficient_) * 2));

                // send E-receipt api request with an transaction id
                _ = TestRelatedClasses.PostApiRequest.PostRequest(ApiMarkers[i], RequestBodies[i], GloballyUsedClasses.ApiRequestsCortex.EreceiptEndpoint_, true, false);

            }//for

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_);


            // forced pause - temporary , just to see the result
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 10));

            // Displays test logs at the end of the tests
            RunTask = Task.Run(() =>
            {
                TestRelatedClasses.TestLogDisplay.DisplayTestLog();
            });
            RunTask.Wait();

        }

    }
}
