namespace Jobs.BlazorServer.Infrastucture.Models
{
    public class JobsModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<string> Requirements { get; set; }
        public string Salary { get; set; }
        public string JobType { get; set; }
        public string ContactEmail { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
