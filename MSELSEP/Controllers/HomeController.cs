using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MSELSEP.Models;
using MSELSEP.Controllers;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.IdentityModel.Protocols;
using System.Text;

namespace MSELSEP.Controllers
{
    public class JSONSer
    {
        public string deloitteemail { get; set; }
        public int deloittenumber { get; set; }
        public string deloitteteam { get; set; }

        public string coursename { get; set; }

        public string country { get; set; }

    }
    public class HomeController : Controller
    {
        private object txt;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CscReg()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Training()
        {
            return View();
        }


        static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            String[] stringarr = new String[] {"hdjfhskdfhkshdf"};

            // Request headers
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "jjkhkjh");

            //var uri = "https://formrecognizerrsc.cognitiveservices.azure.com/formrecognizer/v1.0-preview/custom/models/e50e6a2f-a6e9-4cf3-beef-ffe016ab7799" + queryString;

            //var response = await client.DeleteAsync(uri);
            //test 123
            //test4
            // Request headers
            
            for (int i = 0; i < 11; i++)
            {
                //test 12345

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "mmmnmnm");

                var uri = "https://csc-praxeum-prod-apimgt.azure-api.net/get/api/contests/" + stringarr[i] + queryString;

                try {
                    var response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                
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
                    Console.WriteLine(e);
                    //msg
                    throw e;
                }


            }

            
        }

        public IActionResult Workshops()
        {
           MakeRequest();
            
            return View();
        }
        public IActionResult Hackathons()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Course()
        {
            return View();
        }
        public IActionResult CustomizeTraining()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult ReqTrain()
        {
            return View(new ReqTrainingModel());
        }

        [HttpPost]
        public async Task <ActionResult> ReqTrain(ReqTrainingModel treq)
        {
            string _MSFTEmail = treq.MSFTEmail;

            string _CustomerTeams = treq.CustomerTeams;

            string _CustomerCounrty = treq.CustomerCounrty;

            int _NumberOfTrainne = treq.NumberOfTrainne;

            string _CustomerEmail = treq.CustomerEmail;

            string _CustomerCode = treq.CustomerCode;


            string _Course = treq.Course;


            
            JSONSer jser = new JSONSer
            {
                deloitteemail = _CustomerEmail,
                deloittenumber = _NumberOfTrainne,
                deloitteteam = _CustomerTeams,
                coursename = _Course,
                country = _CustomerCounrty
                
                
  
            };
            string json = JsonConvert.SerializeObject(jser, Formatting.Indented);
            Console.WriteLine(json);

            //test comment

            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync("https://prod-55.eastus.logic.azure.com:443/workflows/957082ccaa4c4c12b457ba59bf8d1deb/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=p_bjmnbe2qMlYtEMHKvdJ9zjgRYQOrSLQ6PgWujeEvA", content).Result;
            }

            //https://prod-55.eastus.logic.azure.com:443/workflows/957082ccaa4c4c12b457ba59bf8d1deb/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=p_bjmnbe2qMlYtEMHKvdJ9zjgRYQOrSLQ6PgWujeEvA
            return View();
        }

    
    }
}
