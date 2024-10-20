using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertySystemProject.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.CrossCuting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile() 
        {
            CreateMap<Domain.Entities.Property, PropertyDTO>().ReverseMap();
            CreateMap<Domain.Entities.Address, PropertyDTO>().ReverseMap();
        }
    }
}
