using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        // 测试使用
        [HttpGet]
        public HttpResponseMessage Test()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("Pass the test!", Encoding.UTF8, "application/json");
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }

        // 验证登录信息
        [HttpPost]
        public bool CanLogOn([FromBody]administrator admin)
        {
            return repository.ValidateLogOn(admin);
        }

        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }
    }
}