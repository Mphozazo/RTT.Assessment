using RTT.Assessment.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Contracts.Persistence
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<bool> PersonExistsAsync(int id, CancellationToken token);
       

    }
}
