using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL.Repository
{
    public interface IRepositoryGet<T>
    {
        IEnumerable<T> GetLists();
        T GetById(int id);
    }
}
