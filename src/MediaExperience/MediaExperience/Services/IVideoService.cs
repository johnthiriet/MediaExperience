using System.Threading.Tasks;
using MediaExperience.Models;

namespace MediaExperience.Services
{
    public interface IVideoService
    {
        Task<Video[]> GetVideosAsync();

        Task<Video> GetVideoAsync(int id);
    }
}