using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using UserBooKCourseIntegration.Application.BusinessService;
using UserBooKCourseIntegration.Application.Repository;
using UserBooKCourseIntegration.Infrastucture.BusinessService;
using Microsoft.Extensions.Configuration;
using UserBooKCourseIntegration.Domain.Models.Concretes;
namespace UserBooKCourseIntegration.Persistence.Extension;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<YouTubeSettings>(o=>configuration.GetSection("YouTubeSettings"));
        services.AddScoped<IYouTubeService, YouTubeService>();
    }

}
