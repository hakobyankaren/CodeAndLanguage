using CodeAndLanguage.Infrastructure.Entities;

namespace CodeAndLanguage.Domain.Entities;

public class CourseProgram
{
    public Guid Id { get; set; }
    public Guid CourseTranslationId { get; set; }

    public int Week { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public CourseTranslation CourseTranslation { get; set; }
}