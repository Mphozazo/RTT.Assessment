using RTT.Assessment.Application.Features.Address.Queries;
using RTT.Assessment.Application.Features.Contact.Queries;
using RTT.Assessment.Application.Features.Person.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Reports
{
    public class PersonReportDto 
    {
        public int PersonId { get; set; }
        public PersonDto personDto { get; set; }
        public IEnumerable<AddressDto> addressDtos { get; set; }
        public IEnumerable<ContactDto> contactDtos { get; set; }
    }
}
