using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Core.Models
{
    public class UserInterest : BaseEntity
    {
        public User User { get; set; }
        public Interest Interest { get; set; }
    }
}
