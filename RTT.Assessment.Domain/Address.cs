using RTT.Assessment.Domain.Common;
using RTT.Assessment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTT.Assessment.Domain;

[Table("Addresses")]
public class Address : BaseEntity
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }

    [ForeignKey("Person")]
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public enumAddressType AddressType { get; set; }

}
