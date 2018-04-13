using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class StuGradeController : ApiController
    {
        IStuGradeRepository repository;

        public StuGradeController(IStuGradeRepository repository)
        {
            this.repository = repository;
        }
        #region GET
        [HttpGet]
        // 查询考生成绩
        public int GetScore(int stuID,int paperID,int state)
        {
            return repository.GetScore(stuID,paperID,state);
        }

        // 成绩统计
        [HttpGet]
        public GradeStatistic Count(int id)
        {
            return repository.Count(id) ;
        }

        // 补考考生成绩统计
        public GradeStatistic Count1(int id)
        {
            return repository.Count1(id);
        }
        #endregion
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }
    }
}