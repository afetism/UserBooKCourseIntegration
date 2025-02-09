using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Options;
using UserBooKCourseIntegration.Application.BusinessService;
using UserBooKCourseIntegration.Domain.Models.Concretes;

namespace UserBooKCourseIntegration.Infrastucture.BusinessService
{
    public class YouTubeService : IYouTubeService
    {
        private readonly string _apiKey;
        private readonly string _channelId;

        public YouTubeService(IOptions<YouTubeSettings> options)
        {
            _apiKey = options.Value.ApiKey;
            _channelId = options.Value.ChannelId;
        }

        public List<YouTubeVideo> GetVideoList()
        {
            var youtube = new Google.Apis.YouTube.v3.YouTubeService(new BaseClientService.Initializer() { ApiKey = _apiKey });
            var channelListRequest = youtube.Channels.List("contentDetails");
            channelListRequest.Id = _channelId;
            var channelListResponse = channelListRequest.Execute();

            var videoList = new List<YouTubeVideo>();
            foreach (var channel in channelListResponse.Items)
            {
                var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;
                var nextPageToken = "";

                while (nextPageToken is not null)
                {
                    var playlistItemsListRequest = youtube.PlaylistItems.List("snippet");
                    playlistItemsListRequest.PlaylistId = uploadsListId;
                    playlistItemsListRequest.MaxResults = 20;
                    playlistItemsListRequest.PageToken = nextPageToken;

                    var playlistItemsListResponse = playlistItemsListRequest.Execute();
                    foreach (var playlistItem in playlistItemsListResponse.Items)
                    {
                        videoList.Add(new YouTubeVideo
                        {
                            Title = playlistItem.Snippet.Title,
                            Description = playlistItem.Snippet.Description,
                            ImageUrl = playlistItem.Snippet.Thumbnails.High.Url,
                            VideoSource = "https://www.youtube.com/embed/" + playlistItem.Snippet.ResourceId.VideoId,
                            VideoId = playlistItem.Snippet.ResourceId.VideoId,
                            VideoOwnerChannelTitle = playlistItem.Snippet.VideoOwnerChannelTitle
                        });
                    }
                    nextPageToken = playlistItemsListResponse.NextPageToken;
                }
            }
            return videoList;
        }
    }
}
