namespace RTT.Assessment.Application.Features.Person.Queries;

public class PersonDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Age { get; set; }
    public DateOnly DOB { get; set; }
}
