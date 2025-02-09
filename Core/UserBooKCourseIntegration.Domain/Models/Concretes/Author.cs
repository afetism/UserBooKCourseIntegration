using System;
using System.Collections.Generic;
using UserBooKCourseIntegration.Domain.Models.Abstract;

namespace UserBooKCourseIntegration.Domain.Models.Concretes;

public partial class Author:BaseEntity
{
  
    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
