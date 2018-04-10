using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    public interface ITypeOfWorkRepository
    {
        // 增加
        typeofwork Add(typeofwork tw);
        // 删除
        bool Delete(string name);
        // 查找
        bool TryGet(string name,out typeofwork tw);
        typeofwork Get(string name);
        IEnumerable<typeofwork> Get();
    }
}
