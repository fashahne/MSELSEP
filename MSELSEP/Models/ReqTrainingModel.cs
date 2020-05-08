using MSELSEP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MSELSEP.Models
{
    public class ReqTrainingModel   {

        [Required(ErrorMessage = "Field is required")]
        public string CustomerTeams { get; set; }

            public string CustomerCounrty { get; set; }

        public string MSFTEmail { get; set; }

        public int NumberOfTrainne { get; set; }

            public string CustomerEmail { get; set; }

            public string CustomerCode { get; set; }

        public string Course { get; set; }



    }
    public class CheckModel
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public bool Checked
        {
            get;
            set;
        }
    }
}
