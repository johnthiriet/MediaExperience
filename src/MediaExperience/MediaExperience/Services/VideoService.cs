using System.Threading.Tasks;
using MediaExperience.Models;

namespace MediaExperience.Services
{
    public class VideoService : IVideoService
    {
        private static readonly string[] VideosUrl =
        {
            "https://msexp2017.blob.core.windows.net/videos/XamarinUniversity/Module%20%231%20-%20Welcome%20to%20Xamarin%20Platform-u1iYeFm254g.mp4",
            "https://msexp2017.blob.core.windows.net/videos/XamarinUniversity/Module%20%232%20-%20Introduction%20to%20Xamarin.Forms-aCbjk0O0mO0.mp4",
            "https://msexp2017.blob.core.windows.net/videos/XamarinUniversity/Module%20%233%20-%20Designing%20Xamarin.Forms%20UI-TlQd874vupM.mp4",
            "https://msexp2017.blob.core.windows.net/videos/XamarinUniversity/Module%20%234%20-%20Adding%20Azure%20Web%20Services-T3OxSKezX_I.mp4",
            "https://msexp2017.blob.core.windows.net/videos/XamarinUniversity/Module%205%20-%20UI%20Testing%20with%20Xamarin-gqEvlB-Karg.mp4"
        };

        public static readonly string[] VideosTitle =
        {
            "Welcome to Xamarin Platform",
            "Introduction to Xamarin.Forms",
            "Designing Xamarin.Forms",
            "Adding Azure Web Services",
            "UI Testing with Xamarin"
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
