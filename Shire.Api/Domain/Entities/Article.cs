using System.Collections.Generic;

namespace Shire.Api.Domain.Entities
{
    public class Article : IContent
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        private readonly ICollection<object> _advertisements;

        private Article(string title, string description)
        {
            Title = title;
            Description = description;
            _advertisements = new List<object>();
        }

        public Article Create(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new System.ArgumentException($"'{nameof(title)}' cannot be null or empty", nameof(title));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new System.ArgumentException($"'{nameof(description)}' cannot be null or empty", nameof(description));
            }

            return new Article(title, description);
        }
    }
}