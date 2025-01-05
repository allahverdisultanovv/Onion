namespace ProniaOnion.Domain.Entities
{
    public class Product : BaseNameable
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SKUCode { get; set; }
        //Relational
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }



    }
}
