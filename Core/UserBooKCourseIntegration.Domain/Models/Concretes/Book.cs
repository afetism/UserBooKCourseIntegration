using System;
using System.Collections.Generic;
using UserBooKCourseIntegration.Domain.Models.Abstract;

namespace UserBooKCourseIntegration.Domain.Models.Concretes;

public partial class Book:BaseEntity
{
    public int AuthorId { get; set; }  
    public int GenreId { get; set; }  
    public int? Pages { get; set; }
    public string? Description { get; set; }
    public int ReadCount { get; set; } = 0;
    public string Name { get; set; }
    public string? Img { get; set; }

   
    public virtual Author Author { get; set; } = null!;
    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
