using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet.GloballyUsedClasses
{
    class GoogleMessagesOTC
    {

        static Task RunTask;

        public static string OTCode = "";

        public static void NavigateToGoogleMessageApp() { 
        
            TestProcedure.webDriver.Url = "https://messages.google.com/web/conversations/224";

            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_);

            RunTask = Task.Run(() => {

                OneTimeCode();

            });
            RunTask.Wait();

        }//NavigateToGoogleMessageApp


        public static string OneTimeCode() {

            List<IWebElement> OtcSmsList = TestProcedure.webDriver.FindElements(By.XPath("//div[contains(@class,'ng-star-inserted')][.='Your Nayax verification code is:']")).ToList();

            foreach (IWebElement OtcSms in OtcSmsList)
            {

                System.Console.WriteLine("Otc Sms: " + OtcSms.Text);

            }//for

            TestProcedure.webDriver.Quit();

            return OTCode;

        }//OneTimeCode

    }
}
