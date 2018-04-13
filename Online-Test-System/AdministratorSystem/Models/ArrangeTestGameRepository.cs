using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class ArrangeTestGameRepository : IArrangeTestGameRepository
    {
        DBEntities2 db;

        public ArrangeTestGameRepository()
        {
            db = new DBEntities2();
        }

        public bool ArrangeTestGame(arrange_testgame_between_ordinaryuser_and_testpaper tg)
        {
            var result = db.arrange_testgame_between_ordinaryuser_and_testpaper.Where(p => p.StartTime<tg.StartTime&&p.EndTime>tg.StartTime||(p.StartTime<=tg.EndTime&&p.EndTime>=tg.EndTime)).FirstOrDefault();
            if(result!=null) //考试安排冲突
            {
                return false;
            }
            db.arrange_testgame_between_ordinaryuser_and_testpaper.Add(tg);
            db.SaveChanges();
            return true;
        }
    }
}