using AutoMapper;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertySystemProject.Domain.DTOs;
using PropertySystemProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
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
            
            CreateMap<User, RegisterDTO>()
                .ForMember(dest => BCrypt.Net.BCrypt.HashPassword(dest.Password), opt => opt.MapFrom(src => src.Password))
                .ReverseMap();
        }
    }
}
