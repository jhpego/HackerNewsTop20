using BestHackerNews.Models;
using BestHackerNews.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BestHackerNews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {

        private readonly IHackerNewsService _hackerNewsService;


        public NewsController(
            IHackerNewsService hackerNewsService
            )
        {
            _hackerNewsService = hackerNewsService;
        }


        [Route("/best20")]
        public IEnumerable<HackerStoryDto> Get()
        {
            List<HackerStoryDto> output = _hackerNewsService.GetTop20Stories().Result;
            return output;
        }



    }
}
