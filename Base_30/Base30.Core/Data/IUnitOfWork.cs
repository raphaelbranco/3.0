﻿
namespace Base30.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
