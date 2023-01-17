using Base30.Core.Data;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Base30.Authentication.Domain
{
    public interface IAspNetUsersRepository : IRepository<AspNetUsers>
    {
        Task Create(IdentityUser<Guid> aspnetusers);
        void SyncCreate(AspNetUsersNoSql aspnetusersNoSql);
        AspNetUsersNoSql? LoadByIdNoSql(Guid id);
        IdentityUser<Guid>? GetUserByEmail(string email);
        Task<SignInResult> Login(IdentityUser<Guid> user, string password);
        bool LogOut();
    }
}