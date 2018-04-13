using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class StuGradeRepository : IStuGradeRepository
    {
        DBEntities2 db;

        public StuGradeRepository()
        {
            db = new DBEntities2();
        }

        public GradeStatistic Count(int id)
        {
            GradeStatistic gs = new GradeStatistic();
            gs.Examinee = db.arrange_testgame_between_ordinaryuser_and_testpaper.Where(p => p.TestPaperID == id).Count();
            // 及格分数
            var tmp = db.testpaper.Where(p => p.ID == id).FirstOrDefault();
            int passMark = tmp.PassMark;
            gs.Winner = db.arrange_testgame_between_ordinaryuser_and_testpaper.Where(p => p.TestPaperID == id && p.Grade >= passMark).Count();
            gs.Loser = db.arrange_testgame_between_ordinaryuser_and_testpaper.Where(p => p.TestPaperID == id && p.Grade < passMark).Count();
            gs.Rate = gs.Winner / (double)gs.Examinee;
            return gs;
        }

        public GradeStatistic Count1(int id)
        {
            GradeStatistic gs = new GradeStatistic();
            gs.Examinee = db.arrange_testgame_between_ordinaryuser_and_testpaper.Where(p => p.TestPaperID == id&&p.State==1).Count();
            // 及格分数
            var tmp = db.testpaper.Where(p => p.ID == id).FirstOrDefault();
            int passMark = tmp.PassMark;
            gs.Winner = db.arrange_testgame_between_ordinaryuser_and_testpaper.Where(p => p.TestPaperID == id && p.Grade >= passMark && p.State == 1).Count();
            gs.Loser = db.arrange_testgame_between_ordinaryuser_and_testpaper.Where(p => p.TestPaperID == id && p.Grade < passMark && p.State == 1).Count();
            gs.Rate = gs.Winner / (double)gs.Examinee;
            return gs;
        }

        public int GetScore(int stuID, int paperID, int state)
        {
            throw new NotImplementedException();
        }
    }
}