using SimpleNews.Domain.Enums;
using SimpleNews.Domain.Models;

namespace SimpleNews.Domain.Interfaces
{
    public interface INewsService
    {
        public Task<List<NewsArticle>> GetTopHeadlines();
        public Task<List<NewsArticle>> SearchTopHeadlines(string searchTerm, Country country);
    }
}
