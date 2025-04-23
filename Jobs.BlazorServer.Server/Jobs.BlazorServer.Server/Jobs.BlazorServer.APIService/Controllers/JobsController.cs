using Jobs.BlazorServer.Infrastucture.Contracts;
using Jobs.BlazorServer.Infrastucture.DTOs;
using Jobs.BlazorServer.Infrastucture.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.BlazorServer.APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<GetJobsResponse>> GetJobs()
        {
            var content = await _jobService.GetJobsAsync();
            return Ok(content);
        }
    }
}
