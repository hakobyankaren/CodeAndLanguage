using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAndLanguage.Domain.Entities;

namespace CodeAndLanguage.Infrastructure.Entities;

public class CourseTranslation
{
    public Guid Id { get; set; }

    public Guid CourseId { get; set; } // FK to Course
    public string Language { get; set; } // "en" or "hy"

    public string Title { get; set; }
    public string Content { get; set; }
    public string FullContent { get; set; }
    public string StartDate { get; set; }
    public string Duration { get; set; }
    public string Level { get; set; }
    public string Pricing { get; set; }
    public int EnrolledStudents { get; set; }
    public double Rating { get; set; }

    public ICollection<string> Tags { get; set; }
    public ICollection<string> Skills { get; set; }

    public ICollection<CourseProgram> CourseProgram { get; set; }
    public ICollection<Trainer> Trainers { get; set; }
    public ICollection<Testimonial> Testimonials { get; set; }
    public ICollection<string> RelatedCourses { get; set; }

    public Course Course { get; set; }
}
