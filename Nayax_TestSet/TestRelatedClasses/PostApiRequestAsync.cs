using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Nayax_TestSet.TestRelatedClasses
{
    class PostApiRequestAsync
    {
        public static string Token_ = "No token";

        public class JsonContent
        {

            public string token { get; set; }

        }//

        [AllowAnonymous]
        //[HttpPost, Route("send")]
        public static async Task<string> PostRequest(string ApiType_, string RequestBody_, string EndPoint_, bool IsAuthorization_, bool IsSignIn_)
        {
            System.Console.WriteLine("<<<<<<<<<< " + ApiType_.ToUpper() + " API begins >>>>>>>>>");

            Task<HttpResponseMessage> Response_;

            string RequestUrl = EndPoint_;

            //string RequestBody = "{\"username\": \"sergeyr\",\"password\": \"rubi69nayaxqa-44*\"}";

            using (var HttpClient_ = new HttpClient())
            {

                HttpClient_.BaseAddress = new Uri(RequestUrl);

                HttpClient_.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                if (IsAuthorization_ == true)
                {

                    System.Console.WriteLine("Token for authorization:  " + Token_);

                    HttpClient_.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token_);

                } // if

                try
                {
                    await (Response_ = HttpClient_.PostAsync(RequestUrl, new StringContent(RequestBody_, Encoding.UTF8, "application/json")));

                    var ResultString_ = Response_.Result;

                    var ResponseBody = await Response_.Result.Content.ReadAsStringAsync();

                    var Result_ = ResponseBody.Trim("\"".ToCharArray());

                    JsonContent JsonContent_ = JsonConvert.DeserializeObject<JsonContent>(Result_);

                    //System.Console.WriteLine("TOKEN:  " + JsonContent_.token);

                    var ResponseToPrint_ = string.Join("\n", ResultString_);

                    var ResponseBodyToPrint_ = string.Join("\n", Response_.Result.Content.ReadAsStringAsync());


                    // printing response body line by line
                    for (int i = 0; i < Result_.Length; i++)
                    {

                        if (Result_[i].ToString().Equals("{") || Result_[i].ToString().Equals(","))
                        {

                            Result_ = Result_.Replace(Result_[i].ToString(), Result_[i].ToString() + "\n");

                        } 
                        else if (Result_[i].ToString().Equals("}"))
                        {

                            Result_ = Result_.Replace(Result_[i].ToString(), "\n" + Result_[i].ToString());

                        } // if

                    } //for

                    Token_ = JsonContent_.token;

                    // creates html report
                    if (IsSignIn_ == false)
                    {

                        GloballyUsedClasses.HtmlGenerator.CreateApiHtmlReport(ResponseToPrint_, ResponseBodyToPrint_, ResultString_.StatusCode.ToString(), ApiType_);

                    } // if


                    System.Console.WriteLine(ApiType_.ToUpper() + ": ResponseToPrint_ :  " + ResponseToPrint_);

                    System.Console.WriteLine(ApiType_.ToUpper() + ": ResponseBodyToPrint_ :  " + ResponseBodyToPrint_);

                    System.Console.WriteLine(ApiType_.ToUpper() + ": Result_ :  " + Result_);

                    System.Console.WriteLine(ApiType_.ToUpper() + ": Status Code:  " + ResultString_.StatusCode);

                    return Token_;

                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Sign in response exception:  " + e);
                    return null;
                }//catch
            }// using
        }// PostRequest
    }
}
