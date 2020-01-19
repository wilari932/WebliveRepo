using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public interface IUnitofWork : IDisposable
    {
       Task<int> CommitAsync();

    }
}
