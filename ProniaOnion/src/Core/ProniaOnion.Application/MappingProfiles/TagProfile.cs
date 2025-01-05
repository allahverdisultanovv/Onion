using AutoMapper;
using ProniaOnion.Application.DTOs.Tags;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagItemDto>();
            CreateMap<Tag, GetTagDto>().ReverseMap();
            CreateMap<TagPostDto, Tag>();
            CreateMap<TagPutDto, Tag>();
        }
    }

}
