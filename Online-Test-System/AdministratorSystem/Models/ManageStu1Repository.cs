using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class ManageStu1Repository : IManageStu1Repository
    {
        DBEntities2 db;

        public ManageStu1Repository()
        {
            db = new DBEntities2();
        }

        public ordinaryuser AddStu(ordinaryuser user)
        {
            user = db.ordinaryuser.Add(user);
            db.SaveChanges();
            return user;
        }

        public ordinaryuser[] AddStu(ordinaryuser[] users)
        {
            for (int i = 0; i < users.Length; i++)
            {
                users[i] = db.ordinaryuser.Add(users[i]);
            }
            db.SaveChanges();
            return users;
        }

        public bool DeleteStu(int id)
        {
            ordinaryuser user;
            if (TryGet(id, out user))
            {
                db.ordinaryuser.Remove(user);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public IEnumerable<ordinaryuser> Get()
        {
            return db.ordinaryuser.OrderBy(ordinaryuser => ordinaryuser.ID);
        }

        public ordinaryuser Get(int id)
        {
            ordinaryuser user;
            if (TryGet(id, out user))
            {
                return user;
            }
            else
                return null;
        }

        public bool Lock(int id)
        {
            var user = db.ordinaryuser.Where(p => p.ID == id).FirstOrDefault<ordinaryuser>();
            if (user != null)
            {
                user.isLocking = 1;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Reset(int id)
        {
            var user = db.ordinaryuser.Where(p => p.ID == id).FirstOrDefault<ordinaryuser>();
            string pwd = Tools.HashPassword("888888");
            if (user != null)
            {
                user.Pwd = pwd;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool TryGet(int id, out ordinaryuser user)
        {
            user = db.ordinaryuser.Find(id);
            if (user != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool UnLock(int id)
        {
            var user = db.ordinaryuser.Where(p => p.ID == id).FirstOrDefault<ordinaryuser>();
            if (user != null)
            {
                user.isLocking = 1;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool UpdateStu(int id, ordinaryuser user)
        {
            var result = db.ordinaryuser.Where(s => s.ID == id).FirstOrDefault<ordinaryuser>();
            if (result != null)
            {
                result.IDCard = user.IDCard;
                result.PhoneNumber = user.PhoneNumber;
                result.Pwd = user.Pwd;
                result.RealName = user.RealName;
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