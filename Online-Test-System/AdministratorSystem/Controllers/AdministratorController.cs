using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    /*
     * AdministratorController：负责管理员账户信息
     */
    public class AdministratorController : ApiController
    {
        IAdministratorRepository repository;

        public AdministratorController(IAdministratorRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public int CanLogOn(string userName,string password)
        {
            if(repository.ValidateLogOn(userName,password)) //账号信息验证通过
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}