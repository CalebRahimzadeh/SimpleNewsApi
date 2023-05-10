using Microsoft.Extensions.Logging;
using SimpleNews.Api.Models;
using SimpleNews.Domain.Enums;
using SimpleNews.Domain.Extensions;
using SimpleNews.Domain.Interfaces;
using SimpleNews.Domain.Models;
using SimpleNews.Domain.Models.Auth;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text.Json;

namespace SimpleNews.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _googleNewsClient;
        private readonly ApiKey _apiKey;
        private readonly ILogger<NewsService> _logger;

        public NewsService(IHttpClientFactory httpClientFactory, ApiKey apiKey, ILogger<NewsService> logger)
        {
            _googleNewsClient = httpClientFactory.CreateClient("GNewsClient");
            _apiKey = apiKey;
            _logger = logger;
        }

        public async Task<List<NewsArticle>> GetTopHeadlines()
        {
            var t = _apiKey.ToQueryString();
            string url = _googleNewsClient.BaseAddress + "/top-headlines?category=general" + _apiKey.ToQueryString();
            HttpResponseMessage response = await _googleNewsClient.GetAsync(url);

            _logger.LogInformation($"Responsed with status code:{response.StatusCode}");
            response.EnsureSuccessStatusCode();

            GoogleNewsResponse gNewsResponse = await JsonSerializer.DeserializeAsync<GoogleNewsResponse>(response.Content.ReadAsStream()) ?? throw new NullReferenceException();
            // Do more business logic and refactor if it has similarity with other methods.
            return gNewsResponse.Articles;
        }

        public async Task<List<NewsArticle>> SearchTopHeadlines(string searchTerm, Country country)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentNullException("Search Tearm cannot be null.");
           
            string countryQueryParam = $"/search?q={searchTerm}&country={country.ToString().ToLower()}";
            string url = _googleNewsClient.BaseAddress + countryQueryParam + _apiKey.ToQueryString();
            HttpResponseMessage response = await _googleNewsClient.GetAsync(url);

            _logger.LogInformation($"Responsed with status code:{response.StatusCode}");
            response.EnsureSuccessStatusCode();

            GoogleNewsResponse gNewsResponse = await JsonSerializer.DeserializeAsync<GoogleNewsResponse>(response.Content.ReadAsStream()) ?? throw new NullReferenceException();

            // Do more business logic and refactor if it has similarity with other methods.
            return gNewsResponse.Articles;
        }
    }
}