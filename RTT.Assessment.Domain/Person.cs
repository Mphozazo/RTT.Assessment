using RTT.Assessment.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTT.Assessment.Domain;

[Table("Persons")]
public class Person : BaseEntity
{
   public string? Name { get; set; }
   public string? Surname { get; set; }
   public int Age { get; set; }
   public DateOnly DOB { get; set; }
}
