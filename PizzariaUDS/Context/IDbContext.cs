using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace PizzariaUDS.Context
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
    }
}
