using netflix.Core.Models;
using netflix.Core.Repositories.Concrete;
using netflix.Repository.Abstract;
using netflix.Repository.Context;

namespace netflix.Repository.Concrete
{
    public class ProgramInterestRepository : GenericRepository<ProgramInterest>, IProgramInterestRepository
    {
        public ProgramInterestRepository(netflixDbContext context) : base(context)
        {
        }
    }
}
