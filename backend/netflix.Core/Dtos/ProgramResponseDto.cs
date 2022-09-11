using netflix.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Core.Dtos
{
    public class ProgramResponseDto
    {
        public string? Name { get; set; }
        public int? EpisodeCount { get; set; }
        public double? Duration { get; set; }
        public int? Type { get; set; }

        public List<string>? Interests { get; set; }
    }
}
