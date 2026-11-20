using AutoMapper;
using RTT.Assessment.Application.Features.Contact.Commands.CreateContact;
using RTT.Assessment.Application.Features.Contact.Commands.UpdateContact;
using RTT.Assessment.Application.Features.Contact.Queries;
using RTT.Assessment.Application.Features.Person.Commands.CreatePerson;
using RTT.Assessment.Application.Features.Person.Commands.UpdatePerson;
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

            // Commands Mapping 
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<UpdateContactCommand, Contact>();
        }
    }
}
