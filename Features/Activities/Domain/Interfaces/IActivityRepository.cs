using ApiAppStudy.Features.Activities.Domain.Entities;
using ApiAppStudy.Features.Activities.Domain.Enums;

namespace ApiAppStudy.Features.Activities.Domain.Interfaces
{
    public interface IActivityRepository
    {
        // Consultas
        Task<Activity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Activity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Activity>> GetActiveActivitiesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Activity>> GetByStatusAsync(ActivityStatus status, CancellationToken cancellationToken = default);

        // Comandos
        Task<Activity> AddAsync(Activity activity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Activity activity, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);

        // Otros
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
