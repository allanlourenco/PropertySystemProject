using PropertySystemProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.Interfaces.Service
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
