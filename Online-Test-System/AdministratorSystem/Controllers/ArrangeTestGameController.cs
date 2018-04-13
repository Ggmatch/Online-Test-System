using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class ArrangeTestGameController : ApiController
    {
        IArrangeTestGameRepository repository;

        public ArrangeTestGameController(IArrangeTestGameRepository repository)
        {
            this.repository = repository;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        // 安排考试
        public bool Post([FromBody]arrange_testgame_between_ordinaryuser_and_testpaper tg)
        {
            return repository.ArrangeTestGame(tg);
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