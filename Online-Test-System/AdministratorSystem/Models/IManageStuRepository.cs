using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministratorSystem.Models;

namespace AdministratorSystem.Models
{
    public interface IManageStuRepository
    {
        // 验证学员的身份证信息
        bool ValidateStu(string idcard);
        // 新建一个学员
        ordinaryuser AddStu(ordinaryuser user);
        // 批量新建一群学员
        ordinaryuser[] AddStu(ordinaryuser[] users);
        // 导入excel新建学员
        IEnumerable<ordinaryuser> AddStuByExcel(IEnumerable<ordinaryuser> users);
        // 查找出所有的学员
        IEnumerable<ordinaryuser> Get();
        // 查找出某一学员
        bool TryGet(int id, out ordinaryuser user);
        // 删除学员
        bool DeleteStu(ordinaryuser user);
        // 更新学员
        bool UpdateStu(int id, ordinaryuser user);
        // 学员补考审核
        bool CanTestAgain(int id);
        // 锁定学员账号
        bool Lock(int id);
        // 解锁
        bool UnLock(int id);
        // 重置账号信息，主要是指密码，重置为默认的“888888”
        bool Reset(int id);
    }
}
