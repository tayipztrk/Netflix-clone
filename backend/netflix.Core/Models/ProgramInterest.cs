using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Core.Models
{
    public class ProgramInterest : BaseEntity
    {
        public Program Program { get; set; }
        public Interest Interest { get; set; }
    }
}
