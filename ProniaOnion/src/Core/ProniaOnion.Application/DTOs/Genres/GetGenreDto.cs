using ProniaOnion.Application.DTOs.Blogs;

namespace ProniaOnion.Application.DTOs.Genres
{
    public record GetGenreDto(int Id, string Name, ICollection<BlogItemDto> Blogs) { }
}