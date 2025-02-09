using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserBooKCourseIntegration.Domain.Models.Abstract;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserBooKCourseIntegration.Domain.Models.Concretes;

public partial class User:BaseEntity
{ 

    public string? Img { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? BirthDate { get; set; }


    [NotMapped]
    public DateTime? DateAsDateTime
    {
        get => BirthDate.HasValue
            ? BirthDate.Value.ToDateTime(TimeOnly.MinValue)
            : (DateTime?)null;
        set => BirthDate = value.HasValue
            ? DateOnly.FromDateTime(value.Value)
            : (DateOnly?)null;
    }


    [NotMapped]
    public string DateForInput
    {
        get => BirthDate.HasValue
            ? BirthDate.Value.ToString("yyyy/MM/dd")
            : string.Empty;
        set => BirthDate = !string.IsNullOrEmpty(value)
            ? DateOnly.Parse(value)
            : (DateOnly?)null;
    }
    public int? SpecialityId { get; set; }

    public virtual Speciality? Speciality { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
