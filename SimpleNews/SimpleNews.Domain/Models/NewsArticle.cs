using System.Text.Json.Serialization;

namespace SimpleNews.Domain.Models
{
    public class NewsArticle
    {
        [JsonConstructor]
        public NewsArticle(string title, string description, string content, Uri uri, Uri imageUri, DateTime publishedAt, Source source)
        {
            Title = title;
            Description = description;
            Content = content;
            Url = uri;
            ImageUri = imageUri;
            PublishedAt = publishedAt;
            Source = source;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Content { get; private set; }
        public Uri Url { get; private set; }
        public Uri ImageUri { get; private set; }
        public DateTime PublishedAt { get; set; }
        public Source Source { get; private set; }

    }
}