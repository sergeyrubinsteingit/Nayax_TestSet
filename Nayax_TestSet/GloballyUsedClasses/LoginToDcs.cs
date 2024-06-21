using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nayax_TestSet.TestRelatedClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Nayax_TestSet.GloballyUsedClasses
{
    public class LoginToDcs
    {


        public static void LoginFlow()
        {
            Task RunTask;

            // TEMPORARY COMMENTED

            //RunTask = Task.Run(() => {

            //    // Sends SQL query to set user status to zero
            //    TestRelatedClasses.SetUserStatusToZero.UpdateUserStatusToZero();

            //});
            //RunTask.Wait();


            RunTask = Task.Run(() => {

                // gets a bandwidth rate
                GloballyUsedClasses.BandwidthCheck.RunBandwidthCheck();

            });
            RunTask.Wait();


            string[] CredentialsId = {

                GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.USER_MAIL_INPUT],
                GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.USER_PASS_INPUT],
                GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.SIGNIN_BUTTON],

            };

            string[] CredentialsValue = {

                GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.USER_MAIL],
                GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.PASS_QA]

            };


            int i;

            for (i = 0; i < CredentialsId.Length; i++)
            {

                RunTask = Task.Run(() =>
                {
                    // find element
                    _ = GloballyUsedClasses.WaitTillExpectedCondition.ElementExistsByCssSelector(CredentialsId[i], 120);

                });

                RunTask.Wait();

                if (i < CredentialsId.Length - 1) {

                    // insert into text fields
                    GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.SendKeys(CredentialsValue[i]);

                } else {

                    // click sign in button
                    GloballyUsedClasses.WaitTillExpectedCondition.ExpectedElement.Click();

                }

            }//for

        }
    }
}
