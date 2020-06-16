using System;

namespace MSELSEP.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        // new bracnh
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}