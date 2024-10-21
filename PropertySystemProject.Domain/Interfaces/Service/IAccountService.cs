using PropertySystemProject.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PropertySystemProject.Domain.Responses.CustomReponses;

namespace PropertySystemProject.Domain.Interfaces.Service
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
    }
}
