using System;
using System.Collections.Generic;
using UserBooKCourseIntegration.Domain.Models.Abstract;

namespace UserBooKCourseIntegration.Domain.Models.Concretes;

public partial class Course:BaseEntity
{
    public string VideoId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Mentor { get; set; }

    public int? Duration { get; set; }

    public decimal? Price { get; set; }

    public string? RequiredSkill { get; set; }
}
