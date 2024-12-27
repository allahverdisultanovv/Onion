namespace ProniaOnion.Domain.Entities
{
    public class Color : BaseNameable
    {

        //Relational
        public ICollection<ProductColor> ProductColors { get; set; }

    }
}
