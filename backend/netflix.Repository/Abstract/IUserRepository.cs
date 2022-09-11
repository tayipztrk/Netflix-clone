using netflix.Core.Models;
using netflix.Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Repository.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
