using PropertySystemProject.Domain.DTOs;

namespace PropertySystemProject.Domain.Interfaces.Service
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyResponseDTO>> GetAllPropertiesAsync();
        Task<PropertyResponseDTO> GetPropertyByIdAsync(Guid id);
        Task<PropertyResponseDTO> AddPropertyAsync(PropertyRequestDTO property);
        Task<PropertyResponseDTO> UpdatePropertyAsync(Guid id, PropertyRequestDTO property);
        Task DeletePropertyAsync(Guid id);

    }
}
