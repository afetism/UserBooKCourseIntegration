using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Persistence.Data;
using UserBooKCourseIntegration.Persistence.Repository.Generics;

namespace UserBooKCourseIntegration.Persistence.Repository;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }
}
