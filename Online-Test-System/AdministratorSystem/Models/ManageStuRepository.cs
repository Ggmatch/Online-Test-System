using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class ManageStuRepository : IManageStuRepository
    {
        DBEntities db;

        public ManageStuRepository()
        {
            db = new DBEntities();
        }

        public ordinaryuser AddStu(ordinaryuser user)
        {
            user=db.ordinaryuser.Add(user);
            db.SaveChanges();
            return user;
        }

        public ordinaryuser[] AddStu(ordinaryuser[] users)
        {
            for(int i=0;i<users.Length;i++)
            {
                users[i] = db.ordinaryuser.Add(users[i]);
            }
            db.SaveChanges();
            return users;
        }

        public IEnumerable<ordinaryuser> AddStuByExcel(IEnumerable<ordinaryuser> users)
        {
            throw new NotImplementedException();
        }

        public bool CanTestAgain(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStu(ordinaryuser user)
        {
            user = db.ordinaryuser.Remove(user);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<ordinaryuser> Get()
        {
            return db.ordinaryuser.OrderBy(ordinaryuser => ordinaryuser.ID);
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

        public bool ValidateStu(string idcard)
        {
            int[] weight = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };    //十七位数字本体码权重
            char[] validate = { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };    //mod11,对应校验码字符值 
            int sum = 0;
            int mode = 0;
            for (int i = 0; i < idcard.Length-1; i++)
            {
                sum = sum + (int)(idcard[i]-'0') * weight[i];
            }
            mode = sum % 11;
            if (validate[mode] == idcard[idcard.Length - 1])
            {
                return true;
            }
            else
                return false;
        }
    }
}