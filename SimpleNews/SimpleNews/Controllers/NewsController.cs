using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleNews.Application.Services;
using SimpleNews.Domain.Enums;
using SimpleNews.Domain.Interfaces;
using SimpleNews.Domain.Models;

namespace SimpleNews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        public readonly INewsService _newsService;
        private readonly ILogger<NewsController> _logger;

        public NewsController(INewsService newsService, ILogger<NewsController> logger)
        {
            _newsService = newsService;
            _logger = logger;
        }

        [HttpGet(Name = "GetTopHeadlines")]
        public async Task<ActionResult<NewsArticle>> GetTopHeadlines()
        {
            _logger.LogInformation("recieved request to get top headlines.");
            ActionResult result = new BadRequestResult();
            // TODO: Abstract out to middleware to catch exceptions globally.
            try
            {
                result = new OkObjectResult(await _newsService.GetTopHeadlines());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
            }
            return result;
        }

        [HttpGet("{country}/{searchTerm}")]
        public async Task<ActionResult<NewsArticle>> SearchHeadlinesByCountry(string country, string searchTerm)
        {
            _logger.LogInformation("recieved request to get top headlines.");
            ActionResult result = new BadRequestResult();
            // TODO: Abstract out to middleware to catch exceptions globally.
            try
            {
                result = new OkObjectResult(await _newsService.SearchTopHeadlines(searchTerm, Enum.Parse<Country>(country)));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
            }

            return result;
        }
    }
}