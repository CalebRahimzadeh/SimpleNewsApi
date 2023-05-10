using SimpleNews.Domain.Models;
using System.Text.Json.Serialization;

namespace SimpleNews.Api.Models
{
    public class GoogleNewsResponse
    {

        [JsonConstructor]
        public GoogleNewsResponse(int totalArticles, List<NewsArticle> articles)
        {
            TotalArticles = totalArticles;
            Articles = articles;
        }

        public int TotalArticles { get; set; }
        public List<NewsArticle> Articles { get; set; } = new List<NewsArticle>();
    }
}
