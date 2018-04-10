using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class ManagementOfStuController : ApiController
    {
        IManageStuRepository repository;

        public ManagementOfStuController(IManageStuRepository repository)
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
            ordinaryuser user;
            if (!repository.TryGet(id, out user))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return user;
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

        // 测试使用
        [HttpGet]
        public HttpResponseMessage Test()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("Pass the test!", Encoding.UTF8, "application/json");
            return response;
        }

        // 处理来自学员注册时候发送过来的身份证信息
        [HttpGet]
        public bool ValidateStu(string idcard)
        {
            return repository.ValidateStu(idcard);
        }
        #endregion

        #region POST
        // 添加学员
        [HttpPost]
        public HttpResponseMessage AddStu([FromBody]ordinaryuser user)
        {
            user = repository.AddStu(user);
            var response = Request.CreateResponse<ordinaryuser>(HttpStatusCode.Created, user);
            return response;
        }

        // 批量添加学员
        [HttpPost]
        public HttpResponseMessage AddStu([FromBody]ordinaryuser[] users)
        {
            users = repository.AddStu(users);
            var response = Request.CreateResponse<IEnumerable<ordinaryuser>>(HttpStatusCode.Created, users);
            return response;
        }

        #endregion

        #region PUT
        // 更新学员
        [HttpPut]
        // PUT api/<controller>/5
        public bool UpdateStu(int id, [FromBody]ordinaryuser user)
        {
            return repository.UpdateStu(id,user);
        }
        #endregion

        #region DELETE
        // DELETE api/<controller>/5
        // 删除学员
        [HttpDelete]
        public ordinaryuser DeleteStu(int id)
        {
            ordinaryuser user;
            if (!repository.TryGet(id, out user))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            repository.DeleteStu(user);
            return user;
        }
        #endregion

        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }
    }
}