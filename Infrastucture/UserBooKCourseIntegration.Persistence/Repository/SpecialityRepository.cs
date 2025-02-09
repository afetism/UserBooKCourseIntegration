using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Application.Repository.Generics;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Persistence.Data;
using UserBooKCourseIntegration.Persistence.Repository.Generics;

namespace UserBooKCourseIntegration.Persistence.Repository;

public class SpecialityRepository : GenericRepository<Speciality>, ISpecialityRepository
{
    public SpecialityRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }
}
