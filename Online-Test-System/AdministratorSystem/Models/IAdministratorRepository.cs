using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    public interface IAdministratorRepository
    {
        // 验证登录
        bool ValidateLogOn(administrator admin);
    }
}
