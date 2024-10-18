using PropertySystemProject.Domain.DTOs;

namespace PropertySystemProject.Domain.Interfaces.Service
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyDTO>> GetAllPropertiesAsync();
        Task<PropertyDTO> GetPropertyByIdAsync(Guid id);
        Task AddPropertyAsync(PropertyDTO property);
        Task UpdatePropertyAsync(PropertyDTO property);
        Task DeletePropertyAsync(Guid id);

    }
}
