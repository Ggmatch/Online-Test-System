using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class Stu1Controller : ApiController
    {
        IManageStu1Repository repository;

        public Stu1Controller(IManageStu1Repository repository)
        {
            this.repository = repository;
        }

        #region GET
        // GET api/<controller>
        public IQueryable<ordinaryuser> Get()
        {
            return repository.Get().AsQueryable(); ;
        }

        // GET api/<controller>/5
        public ordinaryuser Get(int id)
        {
            return repository.Get(id);
        }

        // 锁定学员
        [HttpGet]
        public bool LockStu(int id)
        {
            return repository.Lock(id);
        }

        // 解锁学员
        [HttpGet]
        public bool UnLockStu(int id)
        {
            return repository.UnLock(id);
        }

        // 重置密码
        [HttpGet]
        public bool Reset(int id)
        {
            return repository.Reset(id);
        }
        #endregion

        #region POST
        // 添加学员
        [HttpPost]
        public ordinaryuser AddStu([FromBody]ordinaryuser user)
        {
            return repository.AddStu(user);
        }

        // 批量添加学员
        [HttpPost]
        public ordinaryuser[] AddStu([FromBody]ordinaryuser[] users)
        {
            return repository.AddStu(users);
        }

        #endregion

        #region PUT
        // 更新学员
        [HttpPut]
        // PUT api/<controller>/5
        public bool UpdateStu(int id, [FromBody]ordinaryuser user)
        {
            return repository.UpdateStu(id, user);
        }
        #endregion

        #region DELETE
        // DELETE api/<controller>/5
        // 删除学员
        [HttpDelete]
        public bool DeleteStu(int id)
        {
            return repository.DeleteStu(id);
        }
        #endregion

        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }
    }
}