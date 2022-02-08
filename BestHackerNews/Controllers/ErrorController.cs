using BestHackerNews.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestHackerNews.Controllers
{
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;


        public ErrorController(ILogger<ErrorController> logger) {
            _logger = logger;
        }

        [Route("error")]
        public ApiError Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = 500;

            // Custom Error
            if (exception is PrimaryException) {
                code = 800;        
            };
            _logger.LogError(exception.Message);
            _logger.LogError(exception.StackTrace.ToString());
            
            Response.StatusCode = code;
            return new ApiError(exception);
        }



        [Route("bad")]
        public HackerStory Bad()
        {
            throw new Exception("some exception");
            return new HackerStory();
        }


        [Route("custom")]
        public HackerStory Custom()
        {
            throw new PrimaryException("some exception");
            return new HackerStory();
        }


    }
}
