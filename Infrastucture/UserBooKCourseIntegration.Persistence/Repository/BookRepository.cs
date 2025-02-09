using Microsoft.EntityFrameworkCore;
using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Persistence.Data;
using UserBooKCourseIntegration.Persistence.Repository.Generics;

namespace UserBooKCourseIntegration.Persistence.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
   // private readonly LibraryDbContext _libraryDbContext;
    public BookRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
       
    }

   
}
