﻿namespace ProniaOnion.Domain.Entities
{
    public class ProductSize
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public Product Product { get; set; }
    }
}
