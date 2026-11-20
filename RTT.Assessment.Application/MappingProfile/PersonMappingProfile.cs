using AutoMapper;
using RTT.Assessment.Application.Features.Person.Queries;

namespace RTT.Assessment.Application.MappingProfile;

public class PersonMappingProfile : Profile
{
    public PersonMappingProfile()
    {
        CreateMap<PersonDto, PersonDto>().ReverseMap();
    }
}
