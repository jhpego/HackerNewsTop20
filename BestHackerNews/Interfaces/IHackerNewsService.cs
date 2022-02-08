using BestHackerNews.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestHackerNews.Services
{
    public interface IHackerNewsService
    {

        public Task<HackerStory> FetchStory(int id);


        public Task<int[]> FetchBestStories();


        public Task<List<HackerStoryDto>> GetTop20Stories();
    }
}
