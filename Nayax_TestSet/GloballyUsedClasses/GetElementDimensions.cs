using DocumentFormat.OpenXml.Spreadsheet;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet.GloballyUsedClasses
{
    class GetElementDimensions
    {
        static Task RunTask;

        public static Dictionary<string, double> ElementDimensionsList = new Dictionary<string, double>();

        public static long ScrollHeight_ = 0;

        public static long OffsetHeight_ = 0;


        // gets width and height of an element
        public static Dictionary<string,double> ElementDimensions(string ElementToMeasure, bool XpathOrSelector) {

            Console.Write("\n<<<<< Element Dimensions begins >>>>>\n");
            Console.Write("\n<<<<< ElementToMeasure < ID: "+ ElementToMeasure + " >>>>>\n");

            // finds an element
            RunTask = Task.Run(() => {

                if (XpathOrSelector == true)
                {

                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByXpath(ElementToMeasure, GloballyUsedClasses.BandwidthCheck.DownloadRate * 1);

                }
                else {

                    GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(ElementToMeasure, GloballyUsedClasses.BandwidthCheck.DownloadRate * 1);

                }// if
            });
            RunTask.Wait();

            //gets Client Height //Convert.ToInt32((string)
            OffsetHeight_ = (long)((IJavaScriptExecutor)TestProcedure.webDriver)
                .ExecuteScript("return arguments[0].offsetHeight;", WaitTillExpectedCondition.ExpectedElement);

            Console.WriteLine("\n\n<<<<< Offset Height: " + OffsetHeight_.ToString() + " >>>>>\n");

            //gets Offset Height
            ScrollHeight_ = (long)((IJavaScriptExecutor)TestProcedure.webDriver)
                .ExecuteScript("return arguments[0].scrollHeight;", GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement);

            Console.WriteLine("\n\n<<<<< Scroll Height: " + ScrollHeight_.ToString() + " >>>>>\n");

            // clears the dictionary
            ElementDimensionsList.Clear();

            // adds to dictionary
            ElementDimensionsList.Add("OffsetHeight", OffsetHeight_);
            ElementDimensionsList.Add("ScrollHeight", ScrollHeight_);

            foreach (KeyValuePair<string, double> pair in ElementDimensionsList)
            {
                Console.Write("\nElement Dimensions LIst ...::: " + pair.Key + " : " + pair.Value.ToString());
            }

            return ElementDimensionsList;

        }//ElementDimensions

    }
}
