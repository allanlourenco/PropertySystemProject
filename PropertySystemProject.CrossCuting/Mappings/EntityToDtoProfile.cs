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
            // Mapeando PropertyDTO para Property
            CreateMap<PropertyRequestDTO, Property>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area))
                .ForMember(dest => dest.NumberRooms, opt => opt.MapFrom(src => src.NumberRooms))
                .ForMember(dest => dest.NumberBathrooms, opt => opt.MapFrom(src => src.NumberBathrooms))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.AddressId, opt => opt.Ignore())  
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    Number = src.Number,
                    City = src.City,
                    State = src.State,
                    CEP = src.CEP,
                    Complement = src.Complement
                }))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) 
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore()) 
                .ForMember(dest => dest.IsActive, opt => opt.Ignore()).ReverseMap(); 

            CreateMap<Property, PropertyResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) 
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area))
                .ForMember(dest => dest.NumberRooms, opt => opt.MapFrom(src => src.NumberRooms))
                .ForMember(dest => dest.NumberBathrooms, opt => opt.MapFrom(src => src.NumberBathrooms))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))  
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number)) 
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City)) 
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.Address.CEP))
                .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Address.Complement)).ReverseMap(); 


            CreateMap<PropertyRequestDTO, Address>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.CEP))
                .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Complement))
                .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap(); 
        }
    }
}
