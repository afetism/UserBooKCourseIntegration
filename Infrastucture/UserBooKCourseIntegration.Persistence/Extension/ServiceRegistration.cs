using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Persistence.Data;
using UserBooKCourseIntegration.Persistence.Repository;

namespace UserBooKCourseIntegration.Persistence.Extension;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<LibraryDbContext>();
        services.AddScoped<IBookRepository,BookRepository>();
        services.AddScoped<ICourseRepository,CourseRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<ISpecialityRepository,SpecialityRepository>();
        services.AddScoped<IGenreRepository,GenreRepository>();
        services.AddScoped<IAuthorRepository,AuthorRepository>();  
       

    }

}
