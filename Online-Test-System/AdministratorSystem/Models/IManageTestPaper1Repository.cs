using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    public interface IManageTestPaper1Repository
    {
        // 增加
        testpaper Add(testpaper tp);
        // 删除
        bool DeleteByID(int id);
        // 修改
        bool UpdateByID(int id, testpaper tp);
        // 查找
        bool TryGet(int id, out testpaper tp);
        testpaper Get(int id);
        IEnumerable<testpaper> GetAll(int organizationUserID);
        // 绑定工种
        bool Binding(int id, int[] types);
    }
}
