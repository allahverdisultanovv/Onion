using AutoMapper;
using ProniaOnion.Application.DTOs.Authors;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorItemDto>();
            CreateMap<Author, GetAuthorDto>().ReverseMap();
            CreateMap<AuthorPostDto, Author>();
            CreateMap<AuthorPutDto, Author>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
