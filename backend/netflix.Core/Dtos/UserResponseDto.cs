using netflix.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Core.Dtos
{
    public class UserResponseDto
    {
        public User User { get; set; }
        public List<Interest> Interests { get; set; }
    }
}
