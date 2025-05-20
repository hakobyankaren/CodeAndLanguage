using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CodeAndLanguage.Infrastructure.Context;

namespace CodeAndLanguage.Infrastructure;

public class CodeAndLanguageDbContextFactory : IDesignTimeDbContextFactory<CodeAndLanguageDbContext>
{
    public CodeAndLanguageDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CodeAndLanguageDbContext>();

        optionsBuilder.UseSqlServer("Server=DESKTOP-DIMG5S0;Database=CodeAndLanguageDb;Trusted_Connection=True;TrustServerCertificate=True;");

        return new CodeAndLanguageDbContext(optionsBuilder.Options);
    }
}
