using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class LetterController : ApiController
    {
        ILetterRepository repository;

        public LetterController(ILetterRepository repository)
        {
            this.repository = repository;
        }
        #region GET
        // 管理员得到全部发送给机构用户的站内消息
        [HttpGet]
        public IQueryable<letter_between_administrator_organizationuser> Get()
        {
            return repository.Get().AsQueryable();
        }
        // 机构用户得到全部发送给普通用户的站内消息
        [HttpGet]
        public IQueryable<letter_between_organizationuser_ordinaryuser> Get1(int organizationUserID)
        {
            return repository.Get1(organizationUserID).AsQueryable();
        }
        // 机构用户查询接收来自管理员的站内消息
        [HttpGet]
        public IQueryable<letter_between_administrator_organizationuser> Receive(int organizationUserID)
        {
            return repository.Receive(organizationUserID).AsQueryable();
        }
        // 普通用户查询接收来自机构用户的站内消息
        [HttpGet]
        public IQueryable<letter_between_organizationuser_ordinaryuser> Receive1(int ordinaryUserID)
        {
            return repository.Receive1(ordinaryUserID).AsQueryable();
        }
        #endregion
        #region POST
        [HttpPost]
        // 管理员给机构用户发送站内消息
        public letter_between_administrator_organizationuser Add([FromBody]letter_between_administrator_organizationuser letter)
        {
            return repository.Add(letter);
        }
        // 机构用户给普通用户发送站内消息
        public letter_between_organizationuser_ordinaryuser Send([FromBody]letter_between_organizationuser_ordinaryuser letter)
        {
            return repository.Send(letter);
        }
        // 机构用户给普通用户发送短信
        public bool Send1([FromBody]letter_between_organizationuser_ordinaryuser letter)
        {
            return repository.Send1(letter);
        }
        #endregion
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }
        
        public string Options()
        {
            return null; // HTTP 200 response with empty body
        }
    }
}