using AutoMapper;
using ProniaOnion.Application.DTOs.Blogs;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, BlogItemDto>();
            CreateMap<Blog, GetBlogDto>().ReverseMap();
            CreateMap<BlogPostDto, Blog>();
            CreateMap<BlogPutDto, Blog>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
