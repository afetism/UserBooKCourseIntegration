using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Application.Repository.Generics;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Persistence.Data;
using UserBooKCourseIntegration.Persistence.Repository.Generics;

namespace UserBooKCourseIntegration.Persistence.Repository;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }
}
