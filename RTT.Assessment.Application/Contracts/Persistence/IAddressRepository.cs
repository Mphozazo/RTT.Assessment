using RTT.Assessment.Domain;

namespace RTT.Assessment.Application.Contracts.Persistence
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        public Task<IEnumerable<Address>> GetPersonAddressesDetailsAsync(int personId, CancellationToken cancellationToken);
    }
}
