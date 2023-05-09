using Microsoft.AspNetCore.Mvc;
using SimpleNews.Domain.Models;

namespace SimpleNews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTopHeadlines")]
        public Task<ActionResult<NewsArticle>> GetTopHeadlines()
        {
            _logger.LogInformation("recieved request to get top headlines.");
            ActionResult result = new BadRequestResult();

            throw new NotImplementedException();
            //return result;
        }
    }
}