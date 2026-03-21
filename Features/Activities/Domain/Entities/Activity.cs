using ApiAppStudy.Features.Activities.Domain.Enums;

namespace ApiAppStudy.Features.Activities.Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ActivityStatus Status { get; set; } = ActivityStatus.Active;
        public bool IsDeleted { get; set; } = false;

        // Métodos de dominio
        public void Activate()
        {
            Status = ActivityStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            Status = ActivityStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Complete()
        {
            Status = ActivityStatus.Completed;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SoftDelete()
        {
            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
