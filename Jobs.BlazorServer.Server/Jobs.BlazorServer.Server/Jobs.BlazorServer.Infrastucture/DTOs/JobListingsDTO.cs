using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Jobs.BlazorServer.Infrastucture.DTOs
{
    public class JobListingsDTO
    {
        public bool success { get; set; }
        public int count { get; set; }
        public List<JobsDTO> data { get; set; }
    }
}
