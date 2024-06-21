using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Nayax_TestSet.TestRelatedClasses
{
    class PostApiRequest
    {
        public static string Token_ = "No token";

        // needed to extract a token from response
        public class JsonContent
        {
            public string token { get; set; }

        }//

        [AllowAnonymous]
        //[HttpPost, Route("send")]
        public static async Task<string> PostRequest(string ApiType_, string RequestBody_, string EndPoint_, bool IsAuthorization_, bool IsSignIn_)
        {
            System.Console.WriteLine("<<<<<<<<<< " + ApiType_.ToUpper() + " API BEGINS >>>>>>>>>");

            Task<HttpResponseMessage> Response_;

            string RequestUrl = EndPoint_;

            using (var HttpClient_ = new HttpClient())
            {
                // endpoint
                HttpClient_.BaseAddress = new Uri(RequestUrl);

                // content type
                HttpClient_.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // adds a token to headers for authorization
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

                    ResponseBody = ResponseBody.Trim("\"".ToCharArray()).ToString();

                    JsonContent JsonContent_ = JsonConvert.DeserializeObject<JsonContent>(ResponseBody);

                    var ResponseHeaders_ = string.Join("\n", ResultString_);

                    string PrettifiedBody_ = " PrettifiedBody_ no changes";

                    char[] keyCharacters = { '{', ',', '}' };

                    // prints response body line by line
                    PrettifiedBody_ = ResponseBody;

                    for (int a = 0; a < keyCharacters.Length; a++) {
                                       
                       for (int i = 0; i < ResponseBody.Length; i++) {

                            if (Convert.ToChar(ResponseBody[i]).Equals(keyCharacters[a]))
                            {
                                if (!keyCharacters[a].Equals('}')) {

                                    PrettifiedBody_ = PrettifiedBody_.Replace(ResponseBody[i].ToString(), keyCharacters[a].ToString() + "\n");

                                } 
                                else 
                                {

                                    PrettifiedBody_ = PrettifiedBody_.Replace(ResponseBody[i].ToString(), "\n" + keyCharacters[a].ToString());

                                } //if
                                
                            } // if

                        } //for

                    } //for

                    // gets a bearer's token from response
                    Token_ = JsonContent_.token;

                    // creates html report
                    if (IsSignIn_ == false)
                    {

                        GloballyUsedClasses.HtmlGenerator.CreateApiHtmlReport(ResponseHeaders_, PrettifiedBody_, ResultString_.StatusCode.ToString(), ApiType_);

                    } // if

                    System.Console.WriteLine(ApiType_.ToUpper() + ": PrettifiedBody_ :  " + PrettifiedBody_);

                    System.Console.WriteLine(ApiType_.ToUpper() + ": Status Code:  " + ResultString_.StatusCode);


                    System.Console.WriteLine("<<<<<<<<<< " + ApiType_.ToUpper() + " API ENDS >>>>>>>>>");

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
