using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet.GloballyUsedClasses
{
    class SwitchToOldDcs
    {

        static Task RunTask;

        public static Actions Actions_ = new Actions(TestProcedure.webDriver);

        public static object SwitchToOldDcsUi() {

            System.Console.WriteLine("<<<<<<<<< SwitchToOldDcsUi begins >>>>>>>>>");

            RunTask = Task.Run(() => {

                //search for the filter container
                GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.FILTER_CONTAINER],
                    GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)(GloballyUsedClasses.BandwidthCheck.Coefficient_));

            });
            RunTask.Wait();

            // gets background color of the container
            string ContainerBackgroundColor = GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.GetCssValue("background-color");

            System.Console.WriteLine("Container's color:" + ContainerBackgroundColor);

            // if the color is of the new ui, switches to the old version
            if (ContainerBackgroundColor.Equals("rgba(67, 67, 67, 1)")) {

                RunTask = Task.Run(() => {

                    //search for the theme icon
                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.MENU_THEME_ICON],
                        GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)(GloballyUsedClasses.BandwidthCheck.Coefficient_));

                });
                RunTask.Wait();

                // clicks the icon
                Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();

                RunTask = Task.Run(() => {

                    //search for the filter container again
                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.FILTER_CONTAINER],
                        GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)(GloballyUsedClasses.BandwidthCheck.Coefficient_));

                });
                RunTask.Wait();

                // gets background color of the container
                ContainerBackgroundColor = GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.GetCssValue("background-color");

                // verifies if the color had been changed
                if (!ContainerBackgroundColor.Equals("rgba(67, 67, 67, 1)"))
                {

                    return true;

                }
                else {

                    System.Console.WriteLine("Failed to switch version. The test is shut down");
                    TestProcedure.webDriver.Quit();
                    System.Environment.Exit(0);

                } //if


            } //if

            return false;

        } // SwitchToOldDcsUi

    }
}
