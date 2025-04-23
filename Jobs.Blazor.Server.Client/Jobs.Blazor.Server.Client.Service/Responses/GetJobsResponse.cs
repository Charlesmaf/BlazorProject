using Jobs.Blazor.Server.Client.Service.DTOs;
using Jobs.Blazor.Server.Client.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs.Blazor.Server.Client.Service.Responses
{
    public class GetJobsResponse : BaseResponse
    {
        public List<JobsModel> Content { get; set; }
    }
}
