using Jobs.BlazorServer.Infrastucture.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs.BlazorServer.Infrastucture.Contracts
{
    public interface IJobService
    {
        Task<GetJobsResponse> GetJobsAsync();
    }
}
