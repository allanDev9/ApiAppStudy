using ApiAppStudy.DTOs;
using ApiAppStudy.Models;
using ApiAppStudy.Repositories.Interfaces;
using ApiAppStudy.Services.Interfaces;

namespace ApiAppStudy.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _repository;

    public ActivityService(IActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ActivityDto>> GetAllAsync()
    {
        var activities = await _repository.GetAllAsync();
        return activities.Select(MapToDto);
    }

    public async Task<ActivityDto?> GetByIdAsync(int id)
    {
        var activity = await _repository.GetByIdAsync(id);
        return activity is null ? null : MapToDto(activity);
    }

    public async Task<ActivityDto> CreateAsync(CreateActivityDto createDto)
    {
        var activity = new Activity
        {
            Name = createDto.Name,
            Description = createDto.Description
        };

        var created = await _repository.CreateAsync(activity);
        return MapToDto(created);
    }

    public async Task<ActivityDto?> UpdateAsync(int id, UpdateActivityDto updateDto)
    {
        var activity = new Activity
        {
            Id = id,
            Name = updateDto.Name,
            Description = updateDto.Description
        };

        var updated = await _repository.UpdateAsync(activity);
        return updated is null ? null : MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    private static ActivityDto MapToDto(Activity activity)
    {
        return new ActivityDto
        {
            Id = activity.Id,
            Name = activity.Name,
            Description = activity.Description,
            CreateDate = activity.CreateDate
        };
    }
}
