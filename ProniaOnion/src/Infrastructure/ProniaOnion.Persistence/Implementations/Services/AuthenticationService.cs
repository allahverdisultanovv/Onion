using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.AppUsers;
using ProniaOnion.Domain.Entities;
using System.Text;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenHandler _handler;

        public AuthenticationService(UserManager<AppUser> userManager, IMapper mapper, ITokenHandler handler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _handler = handler;
        }
        public async Task RegisterAsync(RegisterDto userDto)
        {
            if (await _userManager.Users.AnyAsync(u => u.Name == userDto.Name || u.Email == userDto.Email))
                throw new Exception("this email or UserName already exists");

            var result = await _userManager.CreateAsync(_mapper.Map<AppUser>(userDto));
            if (!result.Succeeded)
            {
                StringBuilder str = new StringBuilder();
                foreach (var item in result.Errors)
                {
                    str.AppendLine(item.Description);
                }
                throw new Exception(str.ToString());
            }
        }

        public async Task<TokenResponseDto> LoginAsync(LoginDto userDto)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.Name == userDto.UserNameorEmail || u.Email == userDto.UserNameorEmail);
            if (user == null)
                throw new Exception("username ,email or password is incorrect");
            bool result = await _userManager.CheckPasswordAsync(user, userDto.Password);
            if (!result)
            {
                await _userManager.AccessFailedAsync(user);
                throw new Exception("username ,email or password is incorrect");
            }
            return _handler.CreateToken(user, 15);

        }
    }
}
