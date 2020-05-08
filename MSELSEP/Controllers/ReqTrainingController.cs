using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MSELSEP.Models;

namespace MSELSEP.Controllers
{
    public class ReqTrainingController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ReqTrainingModel treq)
        {
            

            string _CustomerSituation = treq.CustomerTeams;

            string _CustomerRequirements = treq.CustomerCounrty;

            int _NumberOfTrainne = treq.NumberOfTrainne;

            string _CustomerEmail = treq.CustomerEmail;

            string _CustomerCode = treq.CustomerCode;

            string _MSFTEmail = treq.MSFTEmail;


            return View();
        }
    }
}