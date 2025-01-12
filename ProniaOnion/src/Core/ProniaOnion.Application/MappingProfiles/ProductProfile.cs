using AutoMapper;
using ProniaOnion.Application.DTOs.Colors;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Application.DTOs.Sizes;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductItemDto>().ReverseMap();


            //CreateMap<Product, GetProductDto>()
            //    .ConvertUsing(p => new GetProductDto(
            //        p.Id,
            //        p.Name,
            //        p.Price,
            //        p.Description,
            //        p.SKUCode,
            //        new CategoryItemDto(p.CategoryId, p.Category.Name),
            //        p.ProductColors.Select(pc => new ColorItemDto(pc.ColorId, pc.Color.Name))
            //        p.ProductTags.Select(pc => new TagItemDto(pc.TagId, pc.Tag.Name))
            //        p.ProductSizes.Select(pc => new SizeItemDto(pc.SizeId, pc.Size.Name))
            //        ));
            CreateMap<Product, GetProductDto>()
                .ForCtorParam(
                nameof(GetProductDto.Colors),
                opt => opt.MapFrom(
                        p => p.ProductColors.Select(pc => new ColorItemDto(pc.ColorId, pc.Color.Name))
                ))
                .ForCtorParam(
                nameof(GetProductDto.Sizes),
                opt => opt.MapFrom(
                        p => p.ProductSizes.Select(pc => new SizeItemDto(pc.SizeId, pc.Size.Name))
                 ))
                .ForCtorParam(
                nameof(GetProductDto.Tags),
                opt => opt.MapFrom(
                        p => p.ProductTags.Select(pc => new ColorItemDto(pc.TagId, pc.Tag.Name))
                ));


            CreateMap<ProductPostDto, Product>().ForMember(
                p => p.ProductTags,
                opt => opt.MapFrom(pDto => pDto.TagIds.Select(ti => new ProductTag { TagId = ti, }))
                )
                .ForMember(
                p => p.ProductColors,
                opt => opt.MapFrom(pDto => pDto.ColorIds.Select(ci => new ProductColor { ColorId = ci, }))
                )
                .ForMember(
                p => p.ProductSizes,
                opt => opt.MapFrom(pDto => pDto.SizeIds.Select(si => new ProductSize { SizeId = si, }))
                );

            CreateMap<ProductPutDto, Product>()
                .ForMember(p => p.Id,
                    opt => opt.Ignore()
                )
               .ForMember(
                p => p.ProductTags,
                opt => opt.MapFrom(pDto => pDto.TagIds.Select(ti => new ProductTag { TagId = ti, }))
                )
                .ForMember(
                p => p.ProductColors,
                opt => opt.MapFrom(pDto => pDto.ColorIds.Select(ci => new ProductColor { ColorId = ci, }))
                )
                .ForMember(
                p => p.ProductSizes,
                opt => opt.MapFrom(pDto => pDto.SizeIds.Select(si => new ProductSize { SizeId = si, }))
                );
        }
    }
}
