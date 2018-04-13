using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class QuestionBank1Controller : ApiController
    {
        IQuestionBank1Repository repository;

        public QuestionBank1Controller(IQuestionBank1Repository repository)
        {
            this.repository = repository;
        }
        #region GET
        // 查询题库
        [HttpGet]
        public IQueryable<questionbank> Get(int organizationUserId)
        {
            return repository.Get(organizationUserId).AsQueryable();
        }
        // 查询题库各类试题
        [HttpGet]
        public IQueryable<trueorfalse> Get1(int id)
        {
            return repository.Get1(id).AsQueryable();
        }
        [HttpGet]
        public IQueryable<completion> Get2(int id)
        {
            return repository.Get2(id).AsQueryable();
        }
        [HttpGet]
        public IQueryable<selection> Get3(int id)
        {
            return repository.Get3(id).AsQueryable();
        }
        [HttpGet]
        public IQueryable<questionandanswer> Get4(int id)
        {
            return repository.Get4(id).AsQueryable();
        }
        [HttpGet]
        public IQueryable<reading> Get5(int id)
        {
            return repository.Get5(id).AsQueryable();
        }
        [HttpGet]
        public IQueryable<composition> Get6(int id)
        {
            return repository.Get6(id).AsQueryable();
        }
        // 绑定工种
        [HttpGet]
        public bool Binding(int id,int type)
        {
            return repository.Binding(id, type);
        }
        #endregion
        #region POST
        [HttpPost]
        // 添加题库
        public questionbank Add(questionbank qb)
        {
            return repository.Add(qb);
        }
        // 增加试题，这里用了个技巧，用传入参数未用的id字段，当作题库id
        //[HttpPost]
        //public trueorfalse Add1([FromBody]trueorfalse question)
        //{
        //    return repository.Add1((int)question.ID,question);
        //}
        //[HttpPost]
        //public completion Add2([FromBody]completion question)
        //{
        //    return repository.Add2((int)question.ID, question);
        //}
        //[HttpPost]
        //public selection Add3([FromBody]selection question)
        //{
        //    return repository.Add3((int)question.ID, question);
        //}
        //[HttpPost]
        //public questionandanswer Add4([FromBody]questionandanswer question)
        //{
        //    return repository.Add4((int)question.ID, question);
        //}
        //[HttpPost]
        //public reading Add5([FromBody]reading question)
        //{
        //    return repository.Add5((int)question.ID, question);
        //}
        //[HttpPost]
        //public composition Add6([FromBody]composition question)
        //{
        //    return repository.Add6((int)question.ID, question);
        //}
        #endregion
        #region PUT
        // 修改试题
        [HttpPut]
        public bool Update1(int id,[FromBody]trueorfalse question)
        {
            return repository.Update1(id, question);
        }
        [HttpPut]
        public bool Update2(int id, [FromBody]completion question)
        {
            return repository.Update2(id, question);
        }
        [HttpPut]
        public bool Update3(int id, [FromBody]selection question)
        {
            return repository.Update3(id, question);
        }
        [HttpPut]
        public bool Update4(int id, [FromBody]questionandanswer question)
        {
            return repository.Update4(id, question);
        }
        [HttpPut]
        public bool Update5(int id, [FromBody]reading question)
        {
            return repository.Update5(id, question);
        }
        [HttpPut]
        public bool Update6(int id, [FromBody]composition question)
        {
            return repository.Update6(id, question);
        }
        #endregion
        #region DELETE
        [HttpDelete]
        // 删除题库
        public bool Delete(int id)
        {
            return repository.DeleteByID(id);
        }
        // 删除题库中试题
        [HttpDelete]
        public bool Delete1(int id,int questionID)
        {
            return repository.Delete1(id, questionID);
        }
        [HttpDelete]
        public bool Delete2(int id, int questionID)
        {
            return repository.Delete2(id, questionID);
        }
        [HttpDelete]
        public bool Delete3(int id, int questionID)
        {
            return repository.Delete3(id, questionID);
        }
        [HttpDelete]
        public bool Delete4(int id, int questionID)
        {
            return repository.Delete4(id, questionID);
        }
        [HttpDelete]
        public bool Delete5(int id, int questionID)
        {
            return repository.Delete5(id, questionID);
        }
        [HttpDelete]
        public bool Delete6(int id, int questionID)
        {
            return repository.Delete6(id, questionID);
        }
        #endregion

        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }
    }
}