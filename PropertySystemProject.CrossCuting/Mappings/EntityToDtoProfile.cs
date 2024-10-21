using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertySystemProject.Domain.DTOs;
using PropertySystemProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Property = PropertySystemProject.Domain.Entities.Property;

namespace PropertySystemProject.CrossCuting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile() 
        {
            CreateMap<Property, PropertyRequestDTO>().ReverseMap(); 
           
            CreateMap<Address, AddressRequestDTO>().ReverseMap();
            CreateMap<Property, PropertyResponseDTO>().ReverseMap();
            
        }
    }
}
