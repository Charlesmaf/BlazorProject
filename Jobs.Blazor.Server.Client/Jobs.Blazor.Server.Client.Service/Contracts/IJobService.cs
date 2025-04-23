using Jobs.Blazor.Server.Client.Service.Responses;

namespace Jobs.Blazor.Server.Client.Service.Contracts
{
    public interface IJobService
    {
        Task<GetJobsResponse> GetJobsAsync();
    }
}
