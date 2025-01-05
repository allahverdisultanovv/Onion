using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.DTOs.Sizes
{
    public record GetSizeDto(int Id, string Name, ICollection<ProductItemDto> Products) { }


}
