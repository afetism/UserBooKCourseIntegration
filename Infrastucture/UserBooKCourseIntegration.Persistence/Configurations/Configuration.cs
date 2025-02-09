using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace UserBooKCourseIntegration.Persistence.Configurations;

static class Configuration
{

    static public string ConnectionString
    {
        get
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/UserBooKCourseIntegration.Presentation"))
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration.GetConnectionString("DefaultConnection");
        }
    }

}
