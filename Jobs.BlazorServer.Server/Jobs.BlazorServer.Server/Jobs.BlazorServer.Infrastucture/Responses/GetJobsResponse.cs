using Jobs.BlazorServer.Infrastucture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs.BlazorServer.Infrastucture.Responses
{
    public class GetJobsResponse : BaseResponse
    {
        public List<JobsModel> Content { get; set; }
    }
}
