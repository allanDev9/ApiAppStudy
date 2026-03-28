using ApiAppStudy.Data;
using ApiAppStudy.Models;
using ApiAppStudy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiAppStudy.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly AppDbContext _context;

    public ActivityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        return await _context.Activities.ToListAsync();
    }

    public async Task<Activity?> GetByIdAsync(int id)
    {
        return await _context.Activities.FindAsync(id);
    }

    public async Task<Activity> CreateAsync(Activity activity)
    {
        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();
        return activity;
    }

    public async Task<Activity?> UpdateAsync(Activity activity)
    {
        var existing = await _context.Activities.FindAsync(activity.Id);
        if (existing is null) return null;

        existing.Name = activity.Name;
        existing.Description = activity.Description;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var activity = await _context.Activities.FindAsync(id);
        if (activity is null) return false;

        _context.Activities.Remove(activity);
        await _context.SaveChangesAsync();
        return true;
    }
}
