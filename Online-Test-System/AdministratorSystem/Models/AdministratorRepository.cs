using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class AdministratorRepository : IAdministratorRepository
    {
        DBEntities db;

        public AdministratorRepository()
        {
            db = new DBEntities();
        }

        public bool ValidateLogOn(string id, string pwd)
        {
            // 转换id类型
            int Id;
            if (!int.TryParse(id, out Id))
                return false;
            // 密码hash化
            string Pwd = HashPassword(pwd);

            administrator admin = db.administrator.Where(p => p.ID == Id && p.Pwd == Pwd).FirstOrDefault();
            if(admin!=null)
            {
                // 验证成功
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
         * 使用sha1算法对密码散列化
         */
        private string HashPassword(string str)
        {
            string rethash = "";

            System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            byte[] combined = encoder.GetBytes(str);
            hash.ComputeHash(combined);
            rethash = Convert.ToBase64String(hash.Hash);

            return rethash;
        }
    }
}