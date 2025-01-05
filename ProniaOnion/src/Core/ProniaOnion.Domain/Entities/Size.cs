namespace ProniaOnion.Domain.Entities
{
    public class Size : BaseNameable
    {
        public ICollection<ProductSize> ProductSizes { get; set; }
    }
}
