using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class TestPaper1Controller : ApiController
    {
        IManageTestPaper1Repository repository;

        public TestPaper1Controller(IManageTestPaper1Repository repository)
        {
            this.repository = repository;
        }
        #region GET
        // 查询机构用户下的全部试卷
        [HttpGet]
        public IQueryable<testpaper> GetAll(int organizationUserID)
        {
            return repository.GetAll(organizationUserID).AsQueryable();
        }

        // 查询试卷
        public testpaper Get(int id)
        {
            return repository.Get(id);
        }

        // 判定工种
        public bool Binding(int testPaperID,int[] type)
        {
            return repository.Binding(testPaperID, type);
        }
        #endregion
        #region POST
        // 添加试卷，这里使用tp.id存储organizationUserID
        [HttpPost]
        public testpaper Add([FromBody]testpaper tp)
        {
            return repository.Add(tp);
        }
        #endregion
        #region PUT
        // PUT api/<controller>/5
        public bool Put(int id, [FromBody]testpaper tp)
        {
            return repository.UpdateByID(id, tp);
        }
        #endregion
        #region DELETE
        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return repository.DeleteByID(id);
        }
        #endregion

        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }
    }
}