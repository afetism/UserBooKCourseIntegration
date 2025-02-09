using System;
using System.Collections.Generic;
using UserBooKCourseIntegration.Domain.Models.Abstract;

namespace UserBooKCourseIntegration.Domain.Models.Concretes;

public partial class Speciality : BaseEntity { 

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
