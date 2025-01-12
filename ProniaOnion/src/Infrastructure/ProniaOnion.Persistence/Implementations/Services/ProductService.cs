using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
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

        public async Task CreateAsync(ProductPostDto productDto)
        {
            if (!await _categoryRepository.AnyAsync(c => c.Id == productDto.CategoryId))
                throw new Exception("Category does not found");
            var colors = await _productRepository.GetManyToMany<Color>(productDto.ColorIds);
            var tags = await _productRepository.GetManyToMany<Tag>(productDto.TagIds);
            var sizes = await _productRepository.GetManyToMany<Size>(productDto.SizeIds);

            if (colors.Count() != productDto.ColorIds.Distinct().Count()) throw new Exception("Color is wrong");

            if (tags.Count() != productDto.TagIds.Distinct().Count()) throw new Exception("Tag is wrong");

            if (sizes.Count() != productDto.SizeIds.Distinct().Count()) throw new Exception("Size is wrong");



            await _productRepository.AddAsync(_mapper.Map<Product>(productDto));
            await _productRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ProductPutDto productDto)
        {
            Product product = await _productRepository.GetByIdAsync(id, "Category", "ProductColors.Color", "ProductSizes.Size", "ProductTags.Tag");


            if (productDto.CategoryId != product.CategoryId)
                if (!await _categoryRepository.AnyAsync(c => c.Id == productDto.CategoryId))
                    throw new Exception("Category does not exist");

            //another way
            //product.ProductColors=product.ProductColors.Where(pc=>productDto.ColorIds.Contains(pc.ColorId)).ToList();

            ICollection<int> createdItems = productDto.ColorIds.Where(cId => !product.ProductColors.Any(pc => pc.ColorId == cId)).ToList();

            var colorEntities = await _productRepository.GetManyToMany<Color>(createdItems);
            if (colorEntities.Count() != createdItems.Distinct().Count())
                throw new Exception("One or more Color Id is wrong");


            _productRepository.Update(_mapper.Map(productDto, product));
            await _productRepository.SaveChangesAsync();
        }
    }
}
