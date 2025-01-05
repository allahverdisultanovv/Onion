namespace ProniaOnion.Domain.Entities
{
    public class Tag : BaseNameable
    {
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
