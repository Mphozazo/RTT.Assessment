using System.Text.Json.Serialization;

namespace RTT.Assessment.Application.Features.Contact.Shared
{
    public abstract class BaseContactCommand
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CellNumber { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public DateTime DateUpdated { get; set; }

    }
}
