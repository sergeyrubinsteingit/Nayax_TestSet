using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Telerik.JustMock;

namespace Nayax_TestSet.GloballyUsedClasses
{
    class WaitTillExpectedCondition
    {

        public static DefaultWait<IWebDriver> FluentWait = new DefaultWait<IWebDriver>(TestProcedure.webDriver);

        public static IWebElement ExpectedElement;


        // find element by css selector
        public static IWebElement ElementExistsByCssSelector(string ElementSelector, int WaitingSpan)
        {
            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate));

            FluentWait.Timeout = TimeSpan.FromSeconds(WaitingSpan);

            FluentWait.PollingInterval = TimeSpan.FromSeconds(5);

            FluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            FluentWait.IgnoreExceptionTypes(typeof(WebDriverException));

            // time counter, milliseconds
            var StopWatch = new Stopwatch();

            StopWatch.Start();

            ExpectedElement = FluentWait.Until(_ => TestProcedure.webDriver.FindElement(By.CssSelector(ElementSelector)));

            StopWatch.Stop();

            Console.WriteLine("Waiting for element by CSS selector: " + ElementSelector + ", time elapsed: " + StopWatch.ElapsedMilliseconds + " milliseconds.");

            // console info
            System.Console.WriteLine("ElementExistsByCssSelector > ExpectedElement: " + ElementSelector);

            return ExpectedElement;

        }//ElementExistsByCssSelector


        // find element by xpath
        public static IWebElement ElementExistsByXpath(string ElementXpath, int WaitingSpan)
        {
            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * 1));

            FluentWait.Timeout = TimeSpan.FromSeconds(WaitingSpan);

            FluentWait.PollingInterval = TimeSpan.FromSeconds(5);

            FluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            FluentWait.IgnoreExceptionTypes(typeof(OpenQA.Selenium.WebDriverException));

            // time counter, milliseconds
            var StopWatch = new Stopwatch();

            StopWatch.Start();

            ExpectedElement = FluentWait.Until(driver => TestProcedure.webDriver.FindElement(By.XPath(ElementXpath)));

            StopWatch.Stop();

            Console.WriteLine("Waiting for element by Xpath: " + ElementXpath + ", time elapsed: " + StopWatch.ElapsedMilliseconds + " milliseconds.");

            // console info
            System.Console.WriteLine("ElementExistsByXpath > ExpectedElement: " + ElementXpath);

            // element dimensions
            //System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * 1));
            //RunTask = Task.Run(() => {

            //    GetElementDimensions.ElementDimensions(ExpectedElement);

            //});
            //RunTask.Wait();

            return ExpectedElement;

        }//ElementExistsByXpath



        // find element by xpath
        public static IWebElement ElementDisplayedByXpath(string ElementXpath, int WaitingSpan)
        {
            // forced pause
            System.Threading.Thread.Sleep(Convert.ToInt32(BandwidthCheck.DownloadRate * 1));

            FluentWait.Timeout = TimeSpan.FromSeconds(WaitingSpan);

            FluentWait.PollingInterval = TimeSpan.FromSeconds(5);

            FluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            FluentWait.IgnoreExceptionTypes(typeof(OpenQA.Selenium.WebDriverException));

            // time counter, milliseconds
            var StopWatch = new Stopwatch();

            StopWatch.Start();

            ExpectedElement = FluentWait.Until(driver => TestProcedure.webDriver.FindElement(By.XPath(ElementXpath)));

            // forced pause
            Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * 100);

            if (ExpectedElement.Displayed) // && ExpectedElement.Enabled && ExpectedElement.GetAttribute("aria-disabled") == null
            {

                StopWatch.Stop();

                Console.WriteLine("Waiting for element by Xpath: " + ElementXpath + ", time elapsed: " + StopWatch.ElapsedMilliseconds + " milliseconds.");

                // console info
                Console.WriteLine("ElementExistsByXpath > ExpectedElement: " + ElementXpath);

                return ExpectedElement;

            }//if

            Console.WriteLine("ElementEnabledByXpath > Expected element is unreachable");

            Environment.Exit(-1);

            TestProcedure.webDriver.Quit();

            return null;

        }//ElementExistsByXpath


    }
}
