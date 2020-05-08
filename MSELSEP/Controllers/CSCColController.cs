﻿using System;
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
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            String[] stringarr = new String[] {"e50e6a2f-a6e9-4cf3-beef-ffe016ab7799",
                                                "3030ef43-ecf9-4bc5-80ce-072215436ace",
                                                "52cdf002-e4e4-4f33-9e01-08fc54e1ecb1",
                                                "6757fd87-638d-40b2-ad12-c8f32044d0fe",
                                                "f2a8d869-3031-410c-934f-e22038a7e01a",
                                                "67216b22-1fb1-4fc4-a915-df98ea7b0c4e",
                                                "70cf00c8-2b2e-4617-b2d2-82afbcb09db2",
                                                "7626563c-e456-472a-b13d-3941c4b92eec",
                                                "7d4aea68-acc6-449e-850c-96b75de36cb3",
                                                "99396956-90dd-417d-ab82-e98fecb6662a",
                                                "0895bf8f-d279-424e-b387-eb628f952efb",
                                                "e54f5c1f-a37e-49a5-be44-68134e7d9655",
                                                "26e6b4e2-f895-4cc2-902a-9b899ee67c5f"};

            // Request headers
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "8c2837fb95184605b0541265d7e92bb4");

            //var uri = "https://formrecognizerrsc.cognitiveservices.azure.com/formrecognizer/v1.0-preview/custom/models/e50e6a2f-a6e9-4cf3-beef-ffe016ab7799" + queryString;

            //var response = await client.DeleteAsync(uri);

            // Request headers

            for (int i = 0; i < 11; i++)
            {

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "A8d3f30506eb46d9ba1b184c8b4215b3");

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