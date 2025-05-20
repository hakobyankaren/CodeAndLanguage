using CodeAndLanguage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAndLanguage.Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            // Own En
            builder.OwnsOne(c => c.En, en =>
            {
                en.OwnsMany(e => e.Trainers);
                en.OwnsMany(e => e.CourseProgram);
                en.OwnsMany(e => e.Testimonials);
            });

            // Own Hy
            builder.OwnsOne(c => c.Hy, hy =>
            {
                hy.OwnsMany(e => e.Trainers);
                hy.OwnsMany(e => e.CourseProgram);
                hy.OwnsMany(e => e.Testimonials);
            });
        }
    }
}
