using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class TypeOfWorkRepository : ITypeOfWorkRepository
    {
        DBEntities db;
        public TypeOfWorkRepository()
        {
            db = new DBEntities();
        }

        public typeofwork Add(typeofwork tw)
        {
            // 考虑是否已存在该工种
            typeofwork tmp;
            if (!TryGet(tw.Name, out tmp))
            {
                tw = db.typeofwork.Add(tw);
                db.SaveChanges();
                return tw;
            }
            else
                return null;
        }

        public bool Delete(string name)
        {
            typeofwork tw;
            if (TryGet(name, out tw))
            {
                db.typeofwork.Remove(tw);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool TryGet(string name, out typeofwork tw)
        {
            tw = db.typeofwork.Where(p => p.Name == name).FirstOrDefault();
            if (tw != null)
                return true;
            else
                return false;
        }

        public IEnumerable<typeofwork> Get()
        {
            return db.typeofwork.OrderBy(p => p.Name);
        }

        public typeofwork Get(string name)
        {
            typeofwork tw;
            if (TryGet(name, out tw))
            {
                return tw;
            }
            else
                return null;
        }
    }
}