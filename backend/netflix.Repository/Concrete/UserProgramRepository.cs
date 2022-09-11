using netflix.Core.Models;
using netflix.Core.Repositories.Concrete;
using netflix.Repository.Abstract;
using netflix.Repository.Context;

namespace netflix.Repository.Concrete
{
    public class UserProgramRepository : GenericRepository<UserProgram>, IUserProgramRepository
    {
        public UserProgramRepository(netflixDbContext context) : base(context)
        {
        }
    }
}
