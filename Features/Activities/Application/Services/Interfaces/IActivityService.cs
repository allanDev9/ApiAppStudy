using ApiAppStudy.DTOs;

namespace ApiAppStudy.Services.Interfaces;

public interface IActivityService
{
    Task<IEnumerable<ActivityDto>> GetAllAsync();
    Task<ActivityDto?> GetByIdAsync(int id);
    Task<ActivityDto> CreateAsync(CreateActivityDto createDto);
    Task<ActivityDto?> UpdateAsync(int id, UpdateActivityDto updateDto);
    Task<bool> DeleteAsync(int id);
}
