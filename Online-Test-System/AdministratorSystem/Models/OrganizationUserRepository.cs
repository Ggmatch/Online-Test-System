using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class OrganizationUserRepository : IOrganizationUserRepository
    {
        DBEntities2 db;

        public OrganizationUserRepository()
        {
            db = new DBEntities2();
        }

        public organizationuser Add(organizationuser user)
        {
            user.Pwd = Tools.HashPassword(user.Pwd);
            
            user = db.organizationuser.Add(user);
            db.SaveChanges();
            return user;
        }

        public bool ValidateLogOn(organizationuser user)
        {
            string pwd = Tools.HashPassword(user.Pwd);
            var result = db.organizationuser.Where(p => p.ID == user.ID&&p.Pwd==pwd).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }
    }
}