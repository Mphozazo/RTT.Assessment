using AutoMapper;
using RTT.Assessment.Application.Features.Contact.Queries;
using RTT.Assessment.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.MappingProfile
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<ContactDto, Contact>().ReverseMap();

            // commands mapping
        }
    }
}
