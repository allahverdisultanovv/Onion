using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.AppUsers;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(RegisterDto userDto);

        Task<TokenResponseDto> LoginAsync(LoginDto userDto);
    }
}
