using System.Threading.Tasks;
using MediaExperience.Models;

namespace MediaExperience.Services
{
    public class VideoService : IVideoService
    {
        private static readonly string[] VideosUrl =
        {
            "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4",
            "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"
        };

        public static readonly string[] VideosTitle =
        {
            "Big Buck Bunny",
            "Big Buck Bunny"
        };

        public Task<Video[]> GetVideosAsync()
        {
            var videos = new Video[VideosUrl.Length];
            for (int i = 0; i < videos.Length; i++)
                videos[i] = new Video { Id = i, Url = VideosUrl[i], Title = VideosTitle[i] };

            return Task.FromResult(videos);
        }

        public Task<Video> GetVideoAsync(int id)
        {
            var video = new Video { Id = id, Url = VideosUrl[id], Title = VideosTitle[id] };
            return Task.FromResult(video);
        }
    }
}
