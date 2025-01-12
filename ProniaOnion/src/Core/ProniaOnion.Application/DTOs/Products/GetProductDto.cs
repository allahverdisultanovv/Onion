using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Application.DTOs.Sizes;
using ProniaOnion.Application.DTOs.Tags;

namespace ProniaOnion.Application.DTOs.Products
{
    public record GetProductDto(int Id,
        string Name,
        decimal Price,
        string Description,
        string SKUCode,
        CategoryItemDto Category,
        IEnumerable<ColorItemDto> Colors,
        IEnumerable<TagItemDto> Tags,
        IEnumerable<SizeItemDto> Sizes)
    { }


}
