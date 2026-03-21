using ApiAppStudy.Features.Activities.Domain.Entities;
using ApiAppStudy.Features.Activities.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAppStudy.Features.Activities.Infrastructure
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activities");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(ActivitySpecifications.MaxNameLength);

            builder.Property(a => a.Description)
                .HasMaxLength(ActivitySpecifications.MaxDescriptionLength);

            builder.Property(a => a.CreatedAt)
                .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(a => a.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Filtro global para soft delete
            builder.HasQueryFilter(a => !a.IsDeleted);

            // Índices
            builder.HasIndex(a => a.Status);
            builder.HasIndex(a => a.IsDeleted);
        }
    }
}
