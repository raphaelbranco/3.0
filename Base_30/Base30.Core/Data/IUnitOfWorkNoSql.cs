using MongoDB.Driver;

namespace Base30.Core.Data
{
    public interface IUnitOfWorkNoSql
    {
        Task<bool> Commit(ReplaceOneResult result);
    }
}
