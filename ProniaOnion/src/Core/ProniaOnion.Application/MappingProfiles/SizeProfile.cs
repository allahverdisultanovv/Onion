using AutoMapper;
using ProniaOnion.Application.DTOs.Sizes;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<Size, SizeItemDto>();
            CreateMap<Size, GetSizeDto>().ReverseMap();
            CreateMap<SizePostDto, Size>();
            CreateMap<SizePutDto, Size>();
        }
    }
}
