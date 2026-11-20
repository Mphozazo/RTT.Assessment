using System.ComponentModel.DataAnnotations;

namespace RTT.Assessment.Domain.Common;

public class BaseEntity
{
    [Key]public int Id { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
