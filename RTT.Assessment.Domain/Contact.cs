using RTT.Assessment.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTT.Assessment.Domain
{
    [Table("")]
    public class Contact :BaseEntity
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public string? CellNumber { get; set; }
    }
}


