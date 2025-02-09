using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Persistence.Data;
using UserBooKCourseIntegration.Persistence.Repository.Generics;

namespace UserBooKCourseIntegration.Persistence.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }
}
