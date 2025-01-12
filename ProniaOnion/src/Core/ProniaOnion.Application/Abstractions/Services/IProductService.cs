using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAllAsync(int page, int take);

        Task<GetProductDto> GetByIdAsync(int id);



    }
}
