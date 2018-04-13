using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class TestPaperController : ApiController
    {
        IManageTestPaperRepository repository;

        public TestPaperController(IManageTestPaperRepository repository)
        {
            this.repository = repository;
        }
        #region GET
        // GET api/<controller>
        public IQueryable<testpaper> Get()
        {
            return repository.Get().AsQueryable();
        }

        // GET api/<controller>/5
        public testpaper Get(int id)
        {
            return repository.Get(id);
        }
        #endregion
        #region POST
        // POST api/<controller>
        public testpaper Post([FromBody]testpaper tp)
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