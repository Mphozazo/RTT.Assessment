using AutoMapper;
using RTT.Assessment.Application.Features.Person.Commands.CreatePerson;
using RTT.Assessment.Application.Features.Person.Commands.UpdatePerson;
using RTT.Assessment.Application.Features.Person.Queries;
using RTT.Assessment.Domain;

namespace RTT.Assessment.Application.MappingProfile;

public class PersonMappingProfile : Profile
{
    public PersonMappingProfile()
    {
        CreateMap<Person, PersonDto>().ReverseMap();

        // Commands Mapping 
        CreateMap<CreatePersonCommand, Person>();
        CreateMap<UpdatePersonCommand, Person>();
    }
}
