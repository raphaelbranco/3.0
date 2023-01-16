namespace Base30.Authentication.Application.Queries.AspNetUsers
{
    public interface IAspNetUsersQueries : IDisposable
    {
        AspNetUsersDto? LoadByIdNoSql(Guid id);
    }
}

