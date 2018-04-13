using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class TypeOfWorkController : ApiController
    {
        ITypeOfWorkRepository repository;

        public TypeOfWorkController(ITypeOfWorkRepository repository)
        {
            this.repository = repository;
        }

        #region GET
        // 查询所有工种
        // GET api/<controller>
        public IQueryable<typeofwork> Get()
        {
            return repository.Get().AsQueryable();
        }

        // 查询某一工种
        // GET api/<controller>/5
        public typeofwork Get(string name)
        {
            return repository.Get(name);
        }
        #endregion
        #region POST
        // 增加工种
        // POST api/<controller>
        public typeofwork Post([FromBody]typeofwork tw)
        {
            return repository.Add(tw);
        }
        #endregion
        #region DELETE
        // 删除工种
        // DELETE api/<controller>/5
        public bool Delete(string name)
        {
            return repository.Delete(name);
        }
        #endregion

        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }
    }
}