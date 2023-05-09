namespace SimpleNews.Domain.Models
{
    /// <summary>
    /// Represents the source of an article.
    /// </summary>
    public class Source
    {
        public Source(string name, Uri uri)
        {
            this.Name = name;
            this.Url = uri;
        }
        public string Name { get; private set; }
        public Uri Url { get; private set; }
        
    }
}
