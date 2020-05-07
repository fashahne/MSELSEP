using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSELSEP.Models
{
    public class CSCInfo
    {
        public string ContestId { get; set; }
        public string Status { get; set; }

        public string Name { get; set; }

        public string Teams { get; set; }
        public int NumberOfLearners { get; set; }

        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
