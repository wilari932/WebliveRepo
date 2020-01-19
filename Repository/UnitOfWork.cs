using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<int> CommitAsync()
        {
          var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async void Dispose()
        {
           await _dbContext.DisposeAsync();
        }
    }
}
