using ProniaOnion.Application.DTOs;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.Abstractions
{
    public interface ITokenHandler
    {
        TokenResponseDto CreateToken(AppUser user, int minutes);
    }
}
