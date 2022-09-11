using netflix.Core.Models;
using netflix.Core.Repositories.Concrete;
using netflix.Repository.Abstract;
using netflix.Repository.Context;

namespace netflix.Repository.Concrete
{
    public class InterestRepository : GenericRepository<Interest>, IInterestRepository
    {
        public InterestRepository(netflixDbContext context) : base(context)
        {
        }
    }
}
