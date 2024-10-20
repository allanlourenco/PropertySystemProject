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

        public IPropertyRepository PropertyRepository { get; set; }
        public IAddressRepository AddressRepository { get; set; }
        public UnitOfWork(PropertyWebContext dbContext)
        {
            _dbContext = dbContext;

            PropertyRepository = new PropertyRepository(_dbContext);
            AddressRepository = new AddressRepository(_dbContext);
        }

        public async Task<bool> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
