﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class ManageTestPaperRepository : IManageTestPaperRepository
    {
        DBEntities2 db;

        public ManageTestPaperRepository()
        {
            db = new DBEntities2();
        }

        public testpaper Add(testpaper tp)
        {
            tp = db.testpaper.Add(tp);
            db.SaveChanges();
            return tp;
        }

        public bool Binding(int id, int[] types)
        {
            binding_typeofwork_between_testpaper_and_typeofwork tmp = new binding_typeofwork_between_testpaper_and_typeofwork();
            for(int i=0;i<types.Length;i++)
            {
                tmp.TestPaperID = id;
                tmp.IDOfTypeOfWork = types[i];
                db.binding_typeofwork_between_testpaper_and_typeofwork.Add(tmp);
            }
            db.SaveChanges();
            return true;
        }

        public bool DeleteByID(int id)
        {
            testpaper tmp;
            if (TryGet(id, out tmp))
            {
                // 过期试卷可以删除
                if(DateTime.Now>tmp.OverTime)
                {
                    db.testpaper.Remove(tmp);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public testpaper Get(int id)
        {
            testpaper tp;
            if (TryGet(id, out tp))
            {
                return tp;
            }
            else
                return null;
        }

        public IEnumerable<testpaper> Get()
        {
            return db.testpaper.OrderBy(p => p.ID);
        }

        public bool TryGet(int id, out testpaper tp)
        {
            tp = db.testpaper.Where(p => p.ID == id).FirstOrDefault();
            if (tp != null)
                return true;
            else
                return false;
        }

        public bool UpdateByID(int id, testpaper tp)
        {
            var result = db.testpaper.Where(p => p.ID == id).FirstOrDefault();
            if (result != null)
            {
                // 测试名字属性
                result.TestPaperName = tp.TestPaperName;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}