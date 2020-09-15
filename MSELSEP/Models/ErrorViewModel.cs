using System;

namespace MSELSEP.Models
{
    public class ErrorViewModel
    {
        //comment
        public string RequestId { get; set; }
        // new bracnh
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}