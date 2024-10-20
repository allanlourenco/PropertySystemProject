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
            var property = mapper.Map<Property>(propertyDTO);
            property.AddressId = property.Address.Id;

            await unitOfWork.PropertyRepository.AddAsync(property);  
            await unitOfWork.CommitAsync();

            var response = mapper.Map<PropertyResponseDTO>(property);

            return response;
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

        public async Task<IEnumerable<PropertyResponseDTO>> GetAllPropertiesAsync()
        {
            var properties = await unitOfWork.PropertyRepository.GetAllAsync();
            return mapper.Map<IEnumerable<PropertyResponseDTO>>(properties);
        }

        public async Task<PropertyResponseDTO> GetPropertyByIdAsync(Guid id)
        {
            var property = await unitOfWork.PropertyRepository.GetByIdAsync(id);
            return mapper.Map<PropertyResponseDTO>(property);
        }

        public async Task<PropertyResponseDTO?> UpdatePropertyAsync(Guid id, PropertyRequestDTO propertyDTO)
        {
            try
            {
                var existingProperty = await unitOfWork.PropertyRepository.GetByIdAsync(id);

                if (existingProperty == null)
                {
                    return null;
                }

                var property = mapper.Map(propertyDTO, existingProperty);
                //var address = mapper.Map(propertyDTO, existingProperty.Address);

                await unitOfWork.PropertyRepository.UpdateAsync(property);
                //await unitOfWork.AddressRepository.UpdateAsync(address);
                await unitOfWork.CommitAsync();

                var response = mapper.Map<PropertyResponseDTO>(property);
                response.Id = property.Id;

                return response;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Aqui você pode recarregar a entidade e mostrar ao usuário
                var entry = ex.Entries.Single();
                var databaseValues = await entry.GetDatabaseValuesAsync();

                // Lógica para lidar com a situação, por exemplo, recarregar e comparar
                // Pode ser útil informar ao usuário que houve uma atualização concorrente
                throw new Exception("A atualização falhou porque a entidade foi modificada por outra operação.");
            }
            
        }
    }
}
