using Dapper;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Persistence.DatabaseContext
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {

        public ContactRepository(IDbConnectionFactory factory) : base(factory) { }

        public async Task<IEnumerable<Contact>> GetPersonContactDetailsAsync(int personId, CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM Contacts WHERE PersonId = @PersonId";
            var parameters = new { PersonId = personId };
            await using var conn = await _factory.CreateOpenConnectionAsync(cancellationToken);
            return await conn.QueryAsync<Contact>(
                new CommandDefinition(query, parameters, cancellationToken: cancellationToken));
        }
    }
}

