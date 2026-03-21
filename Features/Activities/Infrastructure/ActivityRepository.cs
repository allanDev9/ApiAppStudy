using ApiAppStudy.Features.Activities.Domain.Entities;
using ApiAppStudy.Features.Activities.Domain.Enums;
using ApiAppStudy.Features.Activities.Domain.Interfaces;
using ApiAppStudy.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ApiAppStudy.Features.Activities.Infrastructure
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _context;

        public ActivityRepository(AppDbContext context)
        {
            _context = context;
        }

        // Consultas

        public async Task<Activity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Activites
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Activity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Activites
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Activity>> GetActiveActivitiesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Activites
                .Where(a => a.Status == ActivityStatus.Active)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Activity>> GetByStatusAsync(ActivityStatus status, CancellationToken cancellationToken = default)
        {
            return await _context.Activites
                .Where(a => a.Status == status)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        // Comandos

        public async Task<Activity> AddAsync(Activity activity, CancellationToken cancellationToken = default)
        {
            await _context.Activites.AddAsync(activity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return activity;
        }

        public async Task UpdateAsync(Activity activity, CancellationToken cancellationToken = default)
        {
            _context.Activites.Update(activity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var activity = await GetByIdAsync(id, cancellationToken);
            if (activity is not null)
            {
                activity.SoftDelete();
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        // Otros

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Activites
                .AnyAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
