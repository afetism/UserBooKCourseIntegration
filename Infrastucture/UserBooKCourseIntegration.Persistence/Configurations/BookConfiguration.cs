using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserBooKCourseIntegration.Domain.Models.Concretes;

namespace UserBooKCourseIntegration.Persistence.Configuration.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        


    }
}
