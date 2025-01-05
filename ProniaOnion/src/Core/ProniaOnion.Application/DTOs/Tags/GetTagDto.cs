using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.DTOs.Tags
{
    public record GetTagDto(int Id, string Name, ICollection<ProductItemDto> Products) { }


}
