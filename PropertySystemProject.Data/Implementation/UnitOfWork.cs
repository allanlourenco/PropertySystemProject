using PropertySystemProject.Data.Context;
using PropertySystemProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropertyWebContext _dbContext;

        //public IGrupoClienteRepository GrupoClienteRepository { get; set; }
        //public UnitOfWork(TitanWebContext dbContext)
        //{
        //    _dbContext = dbContext;

        //    GrupoClienteRepository = new GrupoClienteRepository(_dbContext, mapper);
       
        //}

        public async Task<bool> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
