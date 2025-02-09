using UserBooKCourseIntegration.Domain.Models.Concretes;

namespace UserBooKCourseIntegration.Application.BusinessService;

public interface IYouTubeService
{
    List<YouTubeVideo> GetVideoList();

}
