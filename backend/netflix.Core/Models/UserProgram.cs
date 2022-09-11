using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Core.Models
{
    public class UserProgram : BaseEntity
    {
        public User User { get; set; }
        public Program Program { get; set; }
        public DateTime WatchDate { get; set; }
        public int WatchTime { get; set; }
        public int EpisodeNumber { get; set; }
        public int Point { get; set; }
    }
}
