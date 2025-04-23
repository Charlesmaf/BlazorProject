using Jobs.Blazor.Server.Client.Service.Contracts;
using Jobs.Blazor.Server.Client.Service.Model;
using Jobs.Blazor.Server.Client.Service.Responses;
using System.Net;

namespace Jobs.Blazor.Server.Client.Data
{
    /// <summary>
    /// Service for managing job-related operations.
    /// </summary>
    public class JobService : IJobService
    {
        private const string URL = ApiUrls.BaseURL + "/api/Jobs";
        private readonly HttpClient _httpClient;
        private readonly ILogger<JobService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used for making API requests.</param>
        /// <param name="logger">The logger used for logging information and errors.</param>
        public JobService(HttpClient httpClient, ILogger<JobService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a list of jobs asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="GetJobsResponse"/> object containing the list of jobs and response metadata.
        /// </returns>
        public async Task<GetJobsResponse> GetJobsAsync()
        {
            try
            {
                // Fetch jobs from the API endpoint.
                var result = await _httpClient.GetFromJsonAsync<GetJobsResponse>(URL);

                if (result == null)
                {
                    _logger.LogWarning("GetJobsAsync returned null from {URL}", URL);
                    return new GetJobsResponse
                    {
                        Success = false,
                        Result = 0,
                        ResponseCode = (int)HttpStatusCode.InternalServerError,
                        ResponseMessage = "No data received from server.",
                        Content = new List<JobsModel>()
                    };
                }

                _logger.LogInformation("Successfully retrieved {Count} jobs", result.Content?.Count ?? 0);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while fetching jobs from {URL}", URL);
                return new GetJobsResponse
                {
                    Success = false,
                    Result = 0,
                    ResponseCode = (int)HttpStatusCode.InternalServerError,
                    ResponseMessage = "Error",
                    AdditionalInformation = e.Message,
                    Content = new List<JobsModel>()
                };
            }
        }
    }
}
