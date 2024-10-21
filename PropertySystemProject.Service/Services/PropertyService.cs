using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public async Task<PropertyResponseDTO> AddPropertyAsync(PropertyRequestDTO propertyDTO)
        {
            if (propertyDTO == null)
                throw new ArgumentNullException(nameof(propertyDTO), "O imóvel está nulo. Não é possível seguir com a transação.");

            var property = mapper.Map<Property>(propertyDTO);

            if (property.Address == null)
                throw new ArgumentNullException(nameof(property.Address), "Endereço está nulo. Não é possível seguir com a transação.");

            property.Address.GenerateNewGuid();
            property.AddressId = property.Address.Id;

            await unitOfWork.PropertyRepository.AddAsync(property);  
            await unitOfWork.CommitAsync().ConfigureAwait(false);

            var response = mapper.Map<PropertyResponseDTO>(property);

            return response;
        }

        public async Task DeletePropertyAsync(Guid id)
        {
            var property = await unitOfWork.PropertyRepository.GetByIdAsync(id, p => p.Address);
            if (property != null)
            {
                await unitOfWork.PropertyRepository.DeleteAsync(property);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<PropertyResponseDTO>> GetAllPropertiesAsync()
        {
            var properties = await unitOfWork.PropertyRepository.GetAllAsync(p => p.Address);
            return mapper.Map<IEnumerable<PropertyResponseDTO>>(properties);
        }

        public async Task<PropertyResponseDTO> GetPropertyByIdAsync(Guid id)
        {
            var property = await unitOfWork.PropertyRepository.GetByIdAsync(id, p => p.Address);
            return mapper.Map<PropertyResponseDTO>(property);
        }

        public async Task<PropertyResponseDTO?> UpdatePropertyAsync(Guid id, PropertyRequestDTO propertyDTO)
        {
            
            var existingProperty = await unitOfWork.PropertyRepository.GetByIdAsync(id, p => p.Address);

            if (existingProperty == null)
            {
                return null;
            }

            var property = (Property)mapper.Map(propertyDTO, existingProperty);

            await unitOfWork.PropertyRepository.UpdateAsync(property);
            await unitOfWork.CommitAsync();

            var response = mapper.Map<PropertyResponseDTO>(property);
            response.Id = property.Id;

            return response;
            
        }
    }
}
