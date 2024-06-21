using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nayax_TestSet.TestRelatedClasses
{
    class _12monthsVs12monthsTest
    {
        static Task RunTask;

        public static Actions Actions_ = new Actions(TestProcedure.webDriver);

        public static double TotalSumAsDouble = 0.0;

        // clicks on Dashboard tab
        public static void OpenDashboardTab()
        {

            Console.WriteLine("\n<<<<<<<<<<<<<<< Open Dashboard Tab begins >>>>>>>>>>>>>>>>>>>");

            RunTask = Task.Run(() => 
            {
                try
                {
                    // Opens Dashboard tab
                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(
                    GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.TAB_DASHBOARD],
                    (int)(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

                }
                catch (Exception)
                {

                    Console.WriteLine("Failed to open Dashboard tab");
                    TestProcedure.webDriver.Quit();

                } // try

            });
            RunTask.Wait();

            // clicks it
            Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();

        } // OpenDashboardTab


        // gets a data from Last 12 months vs previous 12 months Sales chart
        public static double Last12MonthsVsPrevious12MonthTotal() {

            Console.WriteLine("\n<<<<<<<<<<<<<<< Last 12 Months Vs Previous 12 Month Total begins >>>>>>>>>>>>>>>>>>>");

            // two types of currency to search by
            string[] currencyType = { "//span[contains(text(), 'USD')]", "//span[contains(text(),'ILS')]" };

            //temp ///////////////////////////////////((IJavaScriptExecutor)TestProcedure.webDriver).ExecuteScript("arguments[0].click();", TestProcedure.webDriver.FindElement(By.XPath(currency_)));

            foreach (string currency_ in currencyType) {

                try
                {
                    // opens Dashboard tab
                    RunTask = Task.Run(() =>
                    {

                        OpenDashboardTab();

                    });
                    RunTask.Wait();

                    //// forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_)); 

                    // For some reason it is impossible to select more than one option from this dropdown.
                    // So the "if" block selects the option "USD" which is not shown by default.
                    // Then the "refresh" restores the default option "ILS" and data is filtered by it.
                    if (currency_ == currencyType[0]) {

                        // searches for a Currency toggle on the top-right
                        RunTask = Task.Run(() =>
                        {

                            GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(
                                GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.CURRENCY_THUMBNAIL],
                                GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_);

                        });
                        RunTask.Wait();

                        // moves and clicks on to the Currency toggle
                        Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();

                        // forced pause
                        System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * 100));

                        Console.WriteLine("\nCurrency Xpath is: " + currency_ + "\n");

                        RunTask = Task.Run(() =>
                        {
                            // searches for a Currency type in the dropdown
                            GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByXpath(currency_,
                                GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_);

                        });
                        RunTask.Wait();

                        Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Click().Perform();


                    }//if

                    // forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

                    Console.WriteLine("\nSearch for a column in chart.\n");

                    RunTask = Task.Run(() =>
                    {
                        // searches for a column in chart
                        GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(
                        GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.CHART_12VS12],
                        GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_);

                    });
                    RunTask.Wait();

                    // moves to the column
                    Actions_.MoveToElement(GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement).Perform();

                    // forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

                    // chart sub - element collection
                    List<IWebElement> elemsInsideChart = GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.FindElements(By.XPath(".//*")).ToList();

                    // to store a web element designating a month
                    List<IWebElement> MonthElementToFind = new List<IWebElement>();

                    // forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate));

                    string ElementText = "t";

                    foreach (IWebElement el_ in elemsInsideChart) {

                        if (TryClick(el_)) {

                            ElementText = el_.Text;

                            if (ElementText.Length > 0) {

                                ElementText = el_.Text;

                                Console.WriteLine("Chart's element: " + el_.ToString() + " : " + ElementText);

                            } else {

                                ElementText = "No Text";

                            }//if

                            if (ElementText == "May") {

                                MonthElementToFind.Add(el_);

                            }//if

                        }//if

                    }//foreach

                    Console.WriteLine("May Element length: " + MonthElementToFind.Count);

                    Console.WriteLine("Selected element: " + MonthElementToFind[0].Text);

                    // Tooltips collection ////
                    try
                    {
                        // forced pause
                        System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate) * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_);

                        List<IWebElement> TooltipsElements = TestProcedure.webDriver.FindElements(By.TagName("text")).ToList();

                        // forced pause
                        System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_));

                        Console.WriteLine("TooltipsElements number of items: " + TooltipsElements.Count);

                        RunTask = Task.Run(() =>
                        {
                            // Search for the "May" column in chart
                            SearchContextForToolTipElementInChart(TooltipsElements);

                        });
                        RunTask.Wait();

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Tooltip Problems");
                        throw;
                    }
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine("Failed to find \"Last 12 months vs previous 12 months Sales chart\". Finita!");
                    Debug.WriteLine(e.ToString());
                    TestProcedure.webDriver.Quit();
                    return 0;
                }

                //refreshes
                TestProcedure.webDriver.Navigate().Refresh();

                //// forced pause
                System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * (int)GloballyUsedClasses.BandwidthCheck.Coefficient_));

            }// foreach


            Console.WriteLine("\n\n<<<<< TotalSumAsDouble = " + TotalSumAsDouble + " >>>>>\n\n");

            return TotalSumAsDouble;

        } // Last12MonthsVsPrevious12MonthTotal


        //////try interactability
        public static bool TryClick(IWebElement element)
        {
            try
            {
                element.Click();

                return true;
            }
            catch (ElementNotInteractableException)
            {
                return false;
            }
        }// TryClick



        // Search for the "May" column in chart
        private static IWebElement SearchContextForToolTipElementInChart(List<IWebElement> TooltipsElements)
        {

            foreach (IWebElement ToolElement in TooltipsElements)
            {

                if (ToolElement.Text == "May")
                {
                    Console.WriteLine("Tooltip text: " + ToolElement.Text);

                    //// forced pause
                    System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

                    // moves to the 'May' word containing element in the chart
                    Actions_.MoveToElement(ToolElement).Click().Perform();

                    int count_ = 10;

                    try
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("<<<<<< Trying to click on the May column >>>>>>");

                            // trying to click on the May column
                            Actions_.MoveByOffset(count_, -40).Click().Perform();

                            //// forced pause
                            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

                            IWebElement ToolTipElement = TestProcedure.webDriver.FindElement(By.XPath(GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.TOOLTIP_12MONTH]));

                            //// forced pause
                            System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

                            if (ToolTipElement.Displayed)
                            {

                                Console.WriteLine("\n<<<<<< TOOL TIP TEXT: " + ToolTipElement.Text + " >>>>>>");

                                //// forced pause
                                System.Threading.Thread.Sleep(Convert.ToInt32(GloballyUsedClasses.BandwidthCheck.DownloadRate * GloballyUsedClasses.BandwidthCheck.Coefficient_));

                                RunTask = Task.Run(() =>
                                {

                                    // Extracts the total and converts it to double
                                    ExtractTotalValue(ToolTipElement.Text.ToString());

                                });
                                RunTask.Wait();

                                //break;

                                return ToolTipElement;

                            }
                            else
                            {

                                Console.WriteLine("\n<<<<<< Tool tip containing element is not displayed. >>>>>>");

                                Environment.Exit(-1);

                            }//if

                        }// for

                    }
                    catch (Exception)
                    {

                        count_ += 5;

                    } // try

                }
                else
                {

                    Console.WriteLine("Tooltip text \"May\" is not found");

                }//if 

            }// foreach

            return null;

        } // SearchContextForToolTipElementInChart



        public static double ExtractTotalValue(string TooltipText_) {

            Console.WriteLine("\n<<<<< ExtractTotalValue begins >>>>>\n");

            Console.WriteLine("\n<<<<< string TooltipText_ is: " + TooltipText_ + " >>>>>\n");

            try
            {

                var TextToChar = TooltipText_.ToList();

                Console.WriteLine("\n TooltipText_.IndexOf(\'   \'): " + TooltipText_.IndexOf(' '));

                // to collect only the chars related to the sum value
                List<string> theSum = new List<string>();

                for (int i = TextToChar.IndexOf(' ') + 2; i < TextToChar.Count; i++) {

                    theSum.Add(TextToChar[i].ToString());

                } // for

                // converts an array to single string
                string TotalSum = string.Concat(theSum).TrimStart().TrimEnd();

                // adds to final result
                TotalSumAsDouble += double.Parse(TotalSum);

                // clears the sum list
                theSum.Clear();

                Console.WriteLine("\n Total sum as double: " + TotalSumAsDouble);

                return TotalSumAsDouble;

            }
            catch (NoSuchElementException e)
            {

                Console.WriteLine("Failed to find ToolTip text. Sfortunatomente!");
                Debug.WriteLine(e.ToString());
                TestProcedure.webDriver.Quit();
                return 0;
            }

        } // ExtractTotalValue

    }
}
