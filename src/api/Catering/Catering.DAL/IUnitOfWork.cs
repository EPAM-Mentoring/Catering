using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.DAL
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
    }
}
