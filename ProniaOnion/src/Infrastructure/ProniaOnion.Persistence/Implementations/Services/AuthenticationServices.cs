using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.AppUsers;
using ProniaOnion.Domain.Entities;
using System.Text;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class AuthenticationServices : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthenticationServices(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task RegisterAsync(RegisterDto userDto)
        {
            if (await _userManager.Users.AnyAsync(u => u.Name == userDto.Name || u.Email == userDto.Email))
                throw new Exception("this user or UserName already exists");

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
    }
}
