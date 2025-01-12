using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductItemDto>> GetAllAsync(int page, int take)
        {
            return _mapper
                .Map<IEnumerable<ProductItemDto>>(await _productRepository
                    .GetAll(skip: (page - 1) * take, take: take)
                    .ToListAsync());
        }

        public async Task<GetProductDto> GetByIdAsync(int id)
        {
            GetProductDto product = _mapper.Map<GetProductDto>(await _productRepository.GetByIdAsync(id, "Category", "ProductColors.Color", "ProductSizes.Size", "ProductTags.Tag"));
            if (product == null) throw new Exception("Product not FOund");
            return product;
        }
    }
}
