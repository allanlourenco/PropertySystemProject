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
    public class AccountService(IUnitOfWork unitOfWork, IMapper mapper, IJwtTokenService jwtTokenService) : IAccountService
    {
        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var findUser = await GetUser(model.Email);
            if (findUser == null) return new LoginResponse(false, "Usuário não encontrado.");

            if (!BCrypt.Net.BCrypt.Verify(model.Password, findUser.Password))
                return new LoginResponse(false, "Email ou senha inválidos.");

            string jwtToken = jwtTokenService.GenerateToken(findUser);
            return new LoginResponse(true, "Login feito com sucesso.", jwtToken);
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var findUser = await GetUser(model.Email);
            if (findUser != null) return new RegistrationResponse(false, "Usuário já existe.");

            var user = mapper.Map<User>(model);

            await unitOfWork.UserRepository.AddAsync(user);
            await unitOfWork.CommitAsync();
            return new RegistrationResponse(true, "Sucesso");
        }

        private async Task<User?> GetUser(string email)
            => await unitOfWork.UserRepository.GetUserByEmail(email);
    }
}
