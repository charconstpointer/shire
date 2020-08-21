namespace Shire.Api.Domain.Entities
{
    public interface IContent
    {
        int Id { get; }
        string Title { get; }
        string Description { get; }
    }
}