using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs.BlazorServer.Infrastucture.Models
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public int Result { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;
    }
}
