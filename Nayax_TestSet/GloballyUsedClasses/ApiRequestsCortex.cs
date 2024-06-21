using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayax_TestSet.GloballyUsedClasses
{
    class ApiRequestsCortex
    {

        public static string SignIn_ = "{\"username\": \"sergeyr\",\"password\": \"" + GloballyUsedClasses.TestData.TestKeyValues[GloballyUsedClasses.TestData.KeyWords.PASS_QA] + "\"}";
        public static string SignInEndpoint_ = "https://qa2-cortex.nayax.com/users/v1/signin";

        public static string Ereceipt_ =
            "{"
                + "\"transactionId\": 2009605312,"
                + "\"siteId\": 1,"
                + "\"machineaAuTime\": \"2024-01-15T04:24:36.640Z\","
                + "\"email\": \"sergeyr@nayax.com\""
            + "}";

        public static string EreceiptWrong_ =
            "{"
                + "\"transactionId\": 000,"
                + "\"siteId\": 1,"
                + "\"machineaAuTime\": \"2024-01-15T04:24:36.640Z\","
                + "\"email\": \"sergeyr@nayax.com\""
            + "}";


        public static string EreceiptEndpoint_ = "https://qa2-cortex.nayax.com/payment/v1/payment/generate-receipt";

    }

}
 