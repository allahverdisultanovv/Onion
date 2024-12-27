namespace ProniaOnion.Domain.Entities
{
    public class Category : BaseNameable
    {
        //Relational
        public ICollection<Product> Products { get; set; }
    }
}
