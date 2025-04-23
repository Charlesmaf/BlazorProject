using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs.BlazorServer.Infrastucture.DTOs
{
    public class JobsDTO
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public List<string> requirements { get; set; }
        public string salary { get; set; }
        public string jobType { get; set; }
        public string contactEmail { get; set; }
        public DateTime createdAt { get; set; }
    }
}
