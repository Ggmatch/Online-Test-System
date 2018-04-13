using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdministratorSystem.Models;

namespace AdministratorSystem.Controllers
{
    public class BoardController : ApiController
    {
        IBoardRepository repository;

        public BoardController(IBoardRepository repository)
        {
            this.repository = repository;
        }
        #region GET
        // 得到网站首页的公告
        [HttpGet]
        public IQueryable<board> Get()
        {
            return repository.Get().AsQueryable();
        }
        // 得到机构端的公告
        [HttpGet]
        public IQueryable<board1> Get1()
        {
            return repository.Get1().AsQueryable();
        }
        // 得到学员端的公告
        [HttpGet]
        public IQueryable<board2> Get2()
        {
            return repository.Get2().AsQueryable();
        }
        #endregion
        #region POST
        // 添加网站首页的公告
        public board Add([FromBody]board b)
        {
            return repository.Add(b);
        }
        // 添加机构端的公告
        public board1 Add1([FromBody]board1 b)
        {
            return repository.Add1(b);
        }
        // 添加网站首页的公告
        public board2 Add2([FromBody]board2 b)
        {
            return repository.Add2(b);
        }
        #endregion
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}