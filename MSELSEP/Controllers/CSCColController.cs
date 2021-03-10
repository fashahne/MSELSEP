using System;
using System.Net.Http;
using System.Web;
using MSELSEP.Models;
using Newtonsoft.Json;

namespace MSELSEP.Controllers
{
    public class CSCColController: HomeController
    {
        static async void MakeRequest()
        {
            //perform good
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            String[] stringarr = new String[] {"jksdfhsjhfks"};

            // Request headers
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "");

            //var uri = "https://formrecognizerrsc.cognitiveservices.azure.com/formrecognizer/v1.0-preview/custom/models/e50e6a2f-a6e9-4cf3-beef-ffe016ab7799" + queryString;

            //var response = await client.DeleteAsync(uri);

            // Request headers

            for (int i = 0; i < 11; i++)
            {

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "");

                var uri = "https://csc-praxeum-prod-apimgt.azure-api.net/get/api/contests/" + stringarr[i] + queryString;

                var response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                try
                {
                    CSCInfoModel info = JsonConvert.DeserializeObject<CSCInfoModel>(responseBody);

                    Console.WriteLine(info.ContestId);
                    Console.WriteLine(info.Teams);
                    Console.WriteLine(info.Status);
                    Console.WriteLine(info.NumberOfLearners);
                    Console.WriteLine(info.Name);
                    Console.WriteLine(info.Country);
                    Console.WriteLine("-----------------------");

                    //return JsonConvert.DeserializeObject<object>(responseBody);
                }
                catch (Exception e)
                {
                    //msg
                    throw e;
                }


            }


        }
    }
}
