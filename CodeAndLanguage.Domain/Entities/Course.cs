using CodeAndLanguage.Infrastructure.Entities;

namespace CodeAndLanguage.Domain.Entities;

public class Course
{
    public string Id { get; set; }

    public CourseTranslation En { get; set; }
    public CourseTranslation Hy { get; set; }
}
