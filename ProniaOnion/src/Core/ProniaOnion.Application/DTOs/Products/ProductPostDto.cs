namespace ProniaOnion.Application.DTOs.Products
{
    public record ProductPostDto(
        string Name,
        decimal Price,
        string SKUCode,
        string Description,
        int CategoryId,
        ICollection<int> TagIds,
        ICollection<int> SizeIds,
        ICollection<int> ColorIds
        );


}
