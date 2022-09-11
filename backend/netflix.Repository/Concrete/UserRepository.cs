using netflix.Core.Models;
using netflix.Core.Repositories.Concrete;
using netflix.Repository.Abstract;
using netflix.Repository.Context;

namespace netflix.Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(netflixDbContext context) : base(context)
        {
        }
    }
}
