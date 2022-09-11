namespace netflix.Core.Models
{
    public class Program : BaseEntity
    {
        public string? Name { get; set; }
        public int? EpisodeCount { get; set; }
        public double? Duration { get; set; }
        public int? Type { get; set; }
    }
}
