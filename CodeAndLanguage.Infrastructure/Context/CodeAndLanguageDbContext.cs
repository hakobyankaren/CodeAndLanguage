using CodeAndLanguage.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeAndLanguage.Infrastructure.Context;

public class CodeAndLanguageDbContext : IdentityDbContext
{
    public CodeAndLanguageDbContext(DbContextOptions<CodeAndLanguageDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }

    // Optional: override for seeding or custom logic
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(CodeAndLanguageDbContext).Assembly);

        // Add configuration here if needed
    }
}
