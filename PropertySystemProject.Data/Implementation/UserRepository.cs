using Microsoft.EntityFrameworkCore;
using PropertySystemProject.Data.Context;
using PropertySystemProject.Data.Repository;
using PropertySystemProject.Domain.Entities;
using PropertySystemProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Data.Implementation
{
    public class UserRepository(PropertyWebContext context) : BaseRepository<User>(context), IUserRepository
    {
        public Task<User?> GetUserByEmail(string email)
        {
            return context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
