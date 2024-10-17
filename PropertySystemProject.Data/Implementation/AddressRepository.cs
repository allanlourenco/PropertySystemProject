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
    public class AddressRepository(PropertyWebContext context) : BaseRepository<Address>(context), IAddressRepository
    {
    }
}
