using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet.TestRelatedClasses
{
    class DashboardWidgetDialog
    {
        static Task RunTask;

        public static Actions Actions_ = new Actions(TestProcedure.webDriver);

        public static List<IWebElement> WidgetList = new List<IWebElement>();

        public static List<IWebElement> ListOfDashboardWidgets() {

            // navigates to Machines screen
            TestProcedure.webDriver.Url = GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.URL_MACHINES];

            RunTask = Task.Run(() => {

                // search for Dashboard widgets button
                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses
                .TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.BTN_DASHBOARD_ACTIONS], 
                (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // clicks the Dashboard widgets button
            Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();

            return WidgetList;

        } // ListOfDashboardWidgets

    }
}
