using Jobs.BlazorServer.Infrastucture.Contracts;
using Jobs.BlazorServer.Infrastucture.DTOs;
using Jobs.BlazorServer.Infrastucture.Models;
using Jobs.BlazorServer.Infrastucture.Responses;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Jobs.BlazorServer.Library.Service
{
    /// <summary>
    /// Service class for handling job-related operations.
    /// </summary>
    public class JobService : IJobService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<JobService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory for creating HTTP clients.</param>
        /// <param name="logger">The logger instance for logging information and errors.</param>
        public JobService(IHttpClientFactory httpClientFactory, ILogger<JobService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Asynchronously retrieves a list of jobs from the external API.
        /// </summary>
        /// <returns>A <see cref="GetJobsResponse"/> containing the list of jobs and response metadata.</returns>
        public async Task<GetJobsResponse> GetJobsAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("JobsService");
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/v1/jobs");

                var response = await client.SendAsync(requestMessage);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<JobListingsDTO>(jsonResponse);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("GetJobsAsync[Service]: Successfully processed request.");
                    return result != null
                        ? new GetJobsResponse
                        {
                            Content = result.data.Select(x => new JobsModel
                            {
                                Id = x._id,
                                Title = x.title,
                                Company = x.company,
                                Location = x.location,
                                Description = x.description,
                                Requirements = x.requirements,
                                Salary = x.salary,
                                JobType = x.jobType,
                                ContactEmail = x.contactEmail,
                                CreatedAt = x.createdAt,
                            }).ToList(),
                            Result = result.count,
                            ResponseCode = (int)HttpStatusCode.OK,
                            Success = result.success,
                            ResponseMessage = "Success",
                            AdditionalInformation = "Successfully returned jobs."
                        }
                        : new GetJobsResponse
                        {
                            Content = new List<JobsModel>(),
                            Result = 0,
                            ResponseCode = (int)HttpStatusCode.NoContent,
                            Success = result.success,
                            ResponseMessage = "Success",
                            AdditionalInformation = "Request was successfully processed. No records found!"
                        };
                }
                else
                {
                    _logger.LogError($"GetJobsAsync[Service]: Request failed with status code {response.StatusCode}, reason: {response.ReasonPhrase}");
                    return new GetJobsResponse
                    {
                        Content = new List<JobsModel>(),
                        ResponseCode = (int)HttpStatusCode.BadRequest,
                        Success = result.success,
                        ResponseMessage = "Failed",
                        AdditionalInformation = $"Failed to process request, {response.Content} --> {response.ReasonPhrase}"
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetJobsAsync[Service]: Unexpected error: {ex.Message}");
                return new GetJobsResponse
                {
                    ResponseCode = (int)HttpStatusCode.InternalServerError,
                    ResponseMessage = "Failed",
                    AdditionalInformation = $"An unexpected error occurred: {ex.Message}"
                };
            }
        }
    }
}
