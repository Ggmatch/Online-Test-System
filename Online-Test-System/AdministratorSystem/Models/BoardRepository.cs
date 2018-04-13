using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class BoardRepository : IBoardRepository
    {
        DBEntities2 db;

        public BoardRepository()
        {
            db = new DBEntities2();
        }

        public board Add(board b)
        {
            b = db.board.Add(b);
            db.SaveChanges();
            return b;
        }

        public board1 Add1(board1 b)
        {
            b = db.board1.Add(b);
            db.SaveChanges();
            return b;
        }

        public board2 Add2(board2 b)
        {
            b = db.board2.Add(b);
            db.SaveChanges();
            return b;
        }

        public IEnumerable<board> Get()
        {
            var result = db.board.OrderByDescending(p => p.ID);
            return result;
        }

        public IEnumerable<board1> Get1()
        {
            var result = db.board1.OrderByDescending(p => p.ID);
            return result;
        }

        public IEnumerable<board2> Get2()
        {
            var result = db.board2.OrderByDescending(p => p.ID);
            return result;
        }
    }
}