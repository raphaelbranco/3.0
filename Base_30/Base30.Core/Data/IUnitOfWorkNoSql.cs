﻿using MongoDB.Driver;

namespace Base30.Core.Data
{
    public interface IUnitOfWorkNoSql
    {
        bool Commit(ReplaceOneResult result);
    }
}
