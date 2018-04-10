using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class Tools
    {
        /*
         * 使用sha1算法对密码散列化
         */
        public static string HashPassword(string str)
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