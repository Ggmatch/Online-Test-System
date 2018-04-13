using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class OrganizationUserController : ApiController
    {
        IOrganizationUserRepository repository;

        public OrganizationUserController(IOrganizationUserRepository repository)
        {
            this.repository = repository;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        // 验证登录
        public bool Validate(organizationuser user)
        {
            return repository.ValidateLogOn(user);
        }
        [HttpPost]
        // 注册
        public organizationuser Register([FromBody]organizationuser user)
        {
            return repository.Add(user);
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