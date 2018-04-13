using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    public interface IOrganizationUserRepository
    {
        // 验证登录
        bool ValidateLogOn(organizationuser user);
        // 增加
        organizationuser Add(organizationuser user);
    }
}
