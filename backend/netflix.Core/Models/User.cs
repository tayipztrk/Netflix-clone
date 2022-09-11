namespace netflix.Core.Models 
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }

        //public List<Interest> Interests { get; set; }
    }
}
