using Dapper;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Domain;

namespace RTT.Assessment.Persistence.DatabaseContext
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(IDbConnectionFactory factory) : base(factory)
        {
        }

        public async Task<IEnumerable<Address>> GetPersonAddressesDetailsAsync(int personId, CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM Addresses WHERE PersonId = @PersonId";
            var parameters = new { PersonId = personId };
            await using (var connection = await _factory.CreateOpenConnectionAsync(cancellationToken))
            {
                var addresses = await connection.QueryAsync<Address>(query, parameters);
                return addresses;
            }

        }
    }
}
