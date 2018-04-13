using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class ManageTestPaper1Repository : IManageTestPaper1Repository
    {
        DBEntities2 db;

        public ManageTestPaper1Repository()
        {
            db = new DBEntities2();
        }

        public testpaper Add(testpaper tp)
        {
            // 取机构用户id
            int organizationUserID = (int)tp.ID;
            // 向试卷表中添加
            tp = db.testpaper.Add(tp);
            // 向生成关系表中添加
            generate_testpaper_between_organizationuser_and_testpaper tmp = new generate_testpaper_between_organizationuser_and_testpaper
            {
                OrganizationUserID = organizationUserID,
                TestPaperID = (int)tp.ID,
                TimeOfGeneration = DateTime.Now
            };
            db.generate_testpaper_between_organizationuser_and_testpaper.Add(tmp);
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
            testpaper tp;
            if (TryGet(id, out tp))
            {
                // 过期试卷可以删除
                if(DateTime.Now>tp.OverTime)
                {
                    // 解除生成关系
                    generate_testpaper_between_organizationuser_and_testpaper tmp = db.generate_testpaper_between_organizationuser_and_testpaper.Where(p => p.TestPaperID == id).FirstOrDefault();
                    db.generate_testpaper_between_organizationuser_and_testpaper.Remove(tmp);
                    // 删除试卷
                    db.testpaper.Remove(tp);
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

        public IEnumerable<testpaper> GetAll(int organizationUserID)
        {
            var result = from t in db.testpaper
                         where (
                         from t1 in db.generate_testpaper_between_organizationuser_and_testpaper
                         where t1.OrganizationUserID == organizationUserID
                         select t1.TestPaperID
                         ).Contains((int)t.ID)
                         select t;
            return result.OrderByDescending(p => p.ID);
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
                result.Amount1 = tp.Amount1;
                result.Amount2 = tp.Amount2;
                result.Amount3 = tp.Amount3;
                result.Amount4 = tp.Amount4;
                result.Amount5 = tp.Amount5;
                result.Amount6 = tp.Amount6;
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