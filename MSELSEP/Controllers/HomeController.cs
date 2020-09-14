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
            //thats a test
            // heres anotehr one
            for (int i = 0; i < 11; i++)
            {

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "A8d3f30506eb46d9ba1b184c8b4215b3");

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
