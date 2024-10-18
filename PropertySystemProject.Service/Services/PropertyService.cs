using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertySystemProject.Domain.DTOs;
using PropertySystemProject.Domain.Entities;
using PropertySystemProject.Domain.Interfaces.Repository;
using PropertySystemProject.Domain.Interfaces.Service;
using Property = PropertySystemProject.Domain.Entities.Property;

namespace PropertySystemProject.Service.Services
{
    public class PropertyService(IUnitOfWork unitOfWork, IMapper mapper): IPropertyService
    {
        public async Task AddPropertyAsync(PropertyDTO propertyDTO)
        {
            var property = mapper.Map<Property>(propertyDTO);
            var address = mapper.Map<Address>(propertyDTO);

            await unitOfWork.PropertyRepository.AddAsync(property);
            await unitOfWork.AddressRepository.AddAsync(address);
            await unitOfWork.CommitAsync();
        }

        public async Task DeletePropertyAsync(Guid id)
        {
            var property = await unitOfWork.PropertyRepository.GetByIdAsync(id);
            if (property != null)
            {
                await unitOfWork.PropertyRepository.DeleteAsync(property);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<PropertyDTO>> GetAllPropertiesAsync()
        {
            var properties = await unitOfWork.PropertyRepository.GetAllAsync();
            return mapper.Map<IEnumerable<PropertyDTO>>(properties);
        }

        public async Task<PropertyDTO> GetPropertyByIdAsync(Guid id)
        {
            var property = await unitOfWork.PropertyRepository.GetByIdAsync(id);
            return mapper.Map<PropertyDTO>(property);
        }

        public async Task UpdatePropertyAsync(PropertyDTO propertyDTO)
        {
            var property = mapper.Map<Property>(propertyDTO);
            var address = mapper.Map<Address>(propertyDTO);

            await unitOfWork.PropertyRepository.UpdateAsync(property);
            await unitOfWork.AddressRepository.UpdateAsync(address);
            await unitOfWork.CommitAsync();
        }
    }
}
