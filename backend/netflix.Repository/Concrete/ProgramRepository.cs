using netflix.Core.Models;
using netflix.Core.Repositories.Concrete;
using netflix.Repository.Abstract;
using netflix.Repository.Context;

namespace netflix.Repository.Concrete
{
    public class ProgramRepository : GenericRepository<Program>, IProgramRepository
    {
        public ProgramRepository(netflixDbContext context) : base(context)
        {
        }
    }
}
