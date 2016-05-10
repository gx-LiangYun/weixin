using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LY.WeiXin.BusinessModels;

namespace LY.WeiXin.IDAL
{
    public class SysConfigRepository : IGenericRepository<SysConfigItem>
    {

        public IEnumerable<SysConfigItem> GetEntities(Func<SysConfigItem, bool> func)
        {
            throw new NotImplementedException();
        }

        public SysConfigItem GetEntity(Func<SysConfigItem, bool> func)
        {
            throw new NotImplementedException();
        }

        public bool Add(SysConfigItem obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(SysConfigItem obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SysConfigItem obj)
        {
            throw new NotImplementedException();
        }
    }
}
