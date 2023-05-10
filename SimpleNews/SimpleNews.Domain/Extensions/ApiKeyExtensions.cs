using SimpleNews.Domain.Models.Auth;

namespace SimpleNews.Domain.Extensions
{
    public static class ApiKeyExtensions
    {
        public static string ToQueryString(this ApiKey apiKey)
        {
            return $"&apikey={apiKey.Key}";
        }
    }
}
