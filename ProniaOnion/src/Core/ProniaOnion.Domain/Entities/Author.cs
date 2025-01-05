namespace ProniaOnion.Domain.Entities
{
    public class Author : BaseNameable
    {
        public string Surname { get; set; }
        public string PP { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
