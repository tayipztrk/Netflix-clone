using netflix.Core.Models;
using netflix.Core.Repositories.Concrete;
using netflix.Repository.Abstract;
using netflix.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Repository.Concrete
{
    public class UserInterestRepository : GenericRepository<UserInterest>, IUserInterestRepository
    {
        public UserInterestRepository(netflixDbContext context) : base(context)
        {
        }
    }
}
