using Microsoft.Extensions.Logging;
using SimpleNews.Domain.Enums;
using SimpleNews.Domain.Interfaces;
using SimpleNews.Domain.Models;

namespace SimpleNews.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly ILogger<NewsService> _logger;
        public NewsService(ILogger<NewsService> logger)
        {
            _logger = logger;
        }

        public Task<List<NewsArticle>> GetTopHeadlines()
        {
            throw new NotImplementedException();
        }

        public Task<List<NewsArticle>> GetTopHeadlines(Country c)
        {
            throw new NotImplementedException();
        }
    }
}