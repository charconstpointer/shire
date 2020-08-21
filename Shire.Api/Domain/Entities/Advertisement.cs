using System;

namespace Shire.Api.Domain.Entities
{
    public class Advertisement
    {
        public int Id { get; }
        public string Path { get; }
        public decimal PricePerView { get; }

        private Advertisement(string path, decimal price)
        {
            Path = path;
            PricePerView = price;
        }

        public Advertisement Create(string path, decimal price)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty", nameof(path));
            }
            if (price < 0)
            {
                throw new ApplicationException($"'{nameof(price)}' cannot be lower than 0");
            }
            return new Advertisement(path, price);
        }
    }
}