using RTT.Assessment.Domain;

namespace RTT.Assessment.Application.Contracts.Persistence
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        public Task<IEnumerable<Contact>> GetPersonContactDetailsAsync(int personId, CancellationToken cancellationToken);
    }
}
