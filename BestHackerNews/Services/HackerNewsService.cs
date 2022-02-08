using BestHackerNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestHackerNews.Services
{
    public class HackerNewsService : IHackerNewsService
    {

        readonly string _apiHost = "https://hacker-news.firebaseio.com";
        readonly private IApiCache _apiCache;


        public HackerNewsService(IApiCache apiCache) {
            _apiCache = apiCache;
        }


        public Task<HackerStory> FetchStory(int id) {
            ApiClient apiClient = new ApiClient();
            var url = $"{_apiHost}/v0/item/{id}.json";
            HackerStory apiResponse = apiClient.GenericGet<HackerStory>(url);
            Console.WriteLine("retrieved story {0} with data: {1}", id, apiResponse);
            return Task.FromResult(apiResponse);
        }


        public Task<int[]> FetchBestStories() {
            ApiClient apiClient = new ApiClient();
            var url = $"{_apiHost}/v0/beststories.json";
            int[] apiResponse = apiClient.GenericGet<int[]>(url);
            Console.WriteLine("retrieved list of stories {0}", apiResponse);
            return Task.FromResult(apiResponse);
        }


        public Task<List<HackerStoryDto>> GetTop20Stories() {
            List<HackerStoryDto> output = new List<HackerStoryDto>();
            var bestStoriesIds = _apiCache.GetOrCreate<int[]>("bestStories", () => FetchBestStories()).Result;
            foreach (var currId in bestStoriesIds.Take(5))
            {
                var newStory = _apiCache.GetOrCreate($"story{currId}", () => FetchStory(currId)).Result;
                output.Add(newStory.ToHackerStoryDto());
            }
            return Task.FromResult(output);
        }


    }
}
