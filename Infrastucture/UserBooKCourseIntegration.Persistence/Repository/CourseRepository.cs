using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Persistence.Data;
using UserBooKCourseIntegration.Persistence.Repository.Generics;

namespace UserBooKCourseIntegration.Persistence.Repository;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }
}
