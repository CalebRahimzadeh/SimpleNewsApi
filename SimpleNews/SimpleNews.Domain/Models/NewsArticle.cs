using System.Text.Json.Serialization;

namespace SimpleNews.Domain.Models
{
    public class NewsArticle
    {
        [JsonConstructor]
        public NewsArticle(string title, string description, string content, string uri, string imageUri, DateTime publishedAt, Source source)
        {
            Title = title;
            Description = description;
            Content = content;
            Url = uri;
            Image = imageUri;
            PublishedAt = publishedAt;
            Source = source;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Content { get; private set; }
        public string Url { get; private set; }
        public string Image { get; private set; }
        public DateTime PublishedAt { get; set; }
        public Source Source { get; private set; }

    }
}