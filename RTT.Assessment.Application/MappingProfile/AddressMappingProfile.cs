using AutoMapper;
using RTT.Assessment.Application.Features.Address.Queries;
using RTT.Assessment.Domain;

namespace RTT.Assessment.Application.MappingProfile
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<AddressDto, Address>().ReverseMap();

            // Commands Mapping
        }
    }
}
