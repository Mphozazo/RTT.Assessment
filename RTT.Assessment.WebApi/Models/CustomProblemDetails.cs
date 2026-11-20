using Microsoft.AspNetCore.Mvc;

namespace RTT.Assessment.WebApi.Models
{
    public class CustomProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>(); 
    }
}
