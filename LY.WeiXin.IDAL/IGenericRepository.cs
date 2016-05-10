using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.WeiXin.IDAL
{
    public interface IGenericRepository<T> where T:class,new()
    {
        IEnumerable<T> GetEntities(Func<T, bool> func);
        T GetEntity(Func<T, bool> func);

        bool Add(T obj);
        bool Update(T obj);
        bool Delete(T obj);

    }
}
