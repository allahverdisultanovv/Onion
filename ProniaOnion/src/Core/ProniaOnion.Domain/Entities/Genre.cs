namespace ProniaOnion.Domain.Entities
{
    public class Genre : BaseNameable
    {
        public ICollection<Blog> Blogs { get; set; }
    }
}
