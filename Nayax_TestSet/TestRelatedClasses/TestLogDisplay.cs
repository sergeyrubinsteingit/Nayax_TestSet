using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.IO;
using System.Collections;

namespace Nayax_TestSet.TestRelatedClasses
{
    class TestLogDisplay
    {

        //static string PathToTxtHtmlFile = @"C:\Users\sergeyr\sergey_workspace\Nayax_TestSet\Nayax_TestSet\TestReports\TestLogDisplay.html";

        public static void DisplayTestLog() {

            string PathToDirectory = @"C:\Users\sergeyr\sergey_workspace\Nayax_TestSet\Nayax_TestSet\TestReports\";

            // lists all html files in the directory
            string[] AllHtmlFiles = Directory.GetFiles(PathToDirectory, "*.html");

            foreach (var HtmlFile in AllHtmlFiles) {

                System.Console.WriteLine("HtmlFile:  " + HtmlFile);

                // opens a new tab
                TestProcedure.webDriver.SwitchTo().NewWindow(WindowType.Tab);

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 100));

                // opens HTML
                TestProcedure.webDriver.Navigate().GoToUrl(HtmlFile);

                // forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 100));

            } //foreach

        }// DisplayTestLog

    }
}
