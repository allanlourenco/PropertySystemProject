using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using PropertySystemProject.Domain.DTOs;
using PropertySystemProject.Domain.Entities;
using PropertySystemProject.Domain.Interfaces.Repository;
using PropertySystemProject.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static PropertySystemProject.Domain.Responses.CustomReponses;

namespace PropertySystemProject.Service.Services
{
    public class AccountService(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper) : IAccountService
    {
        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var findUser = await GetUser(model.Email);
            if (findUser == null) return new LoginResponse(false, "Usuário não encontrado.");

            if (!BCrypt.Net.BCrypt.Verify(model.Password, findUser.Password))
                return new LoginResponse(false, "Email ou senha inválidos.");

            string jwtToken = GenerateToken(findUser);
            return new LoginResponse(true, "Login feito com sucesso.", jwtToken);
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var findUser = await GetUser(model.Email);
            if (findUser != null) return new RegistrationResponse(false, "Usuário já existe.");

            var user = mapper.Map<User>(model);
            //_context.Users.Add(new ApplicationUser()
            //{
            //    Name = model.Name,
            //    Email = model.Email,
            //    Role = model.Role,
            //    Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
            //});


            await unitOfWork.UserRepository.AddAsync(user);
            await unitOfWork.CommitAsync();
            return new RegistrationResponse(true, "Sucesso");
        }

        private async Task<User?> GetUser(string email)
            => await unitOfWork.UserRepository.GetUserByEmail(email);
    }
}
