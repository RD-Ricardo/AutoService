namespace AutoService.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
