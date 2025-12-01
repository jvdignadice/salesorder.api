namespace Application.Features.Interfaces
{
    public interface ICsvImporterService
    {
        Task ImportAsync<TEntity>(Stream csvStream, int batchSize = 500)
            where TEntity : class, new();
    }
}
