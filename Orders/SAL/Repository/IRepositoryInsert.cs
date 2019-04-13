using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL.Repository
{
    public interface IRepositoryInsert<T>
    {
        void Insert(T entidad);
    }
}
