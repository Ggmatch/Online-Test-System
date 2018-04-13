using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    public interface IManageStu1Repository
    {
        // 新建一个学员
        ordinaryuser AddStu(ordinaryuser user);
        // 批量新建一群学员
        ordinaryuser[] AddStu(ordinaryuser[] users);
        // 查找出所有的学员
        IEnumerable<ordinaryuser> Get();
        // 查找出某一学员
        ordinaryuser Get(int id);
        bool TryGet(int id, out ordinaryuser user);
        // 删除学员
        bool DeleteStu(int id);
        // 更新学员
        bool UpdateStu(int id, ordinaryuser user);
        // 锁定学员账号
        bool Lock(int id);
        // 解锁
        bool UnLock(int id);
        // 重置账号信息，主要是指密码，重置为默认的“888888”
        bool Reset(int id);
    }
}
